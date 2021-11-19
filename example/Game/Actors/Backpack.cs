using Merlin2d.Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public class Backpack : IInventory
    {
        private IItem[] items;
        private IEnumerator enumerator;
        
        private int capacity;
        private int current;

        public Backpack(int capacity)
        {
            this.capacity = capacity;
            current = -1;   
            items = new IItem[capacity];
            enumerator = items.GetEnumerator();
            enumerator.MoveNext();

        }

        public void AddItem(IItem item)
        {
            
            if (capacity > current+1)
            {
                items[current+1] = item;
                current++; 
            }
            else
            {
                throw new FullInventoryException();
            }
            
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public IItem GetItem()
        {
            /*
            IItem item = items[0];
            items[0] = null;
            return item;*/

            return (IItem)enumerator.Current;
        }

        public void RemoveItem(IItem item)
        {
            int index = ArrayContainsItem(item);
            if (index<capacity)
            {
                items[index] = null;

                int i = index;

                while(items[i+1] != null || i+1!=capacity)
                {
                    items[i] = items[i + 1];
                    items[i + 1] = null;
                    i++;
                }
            }
        }

        public int ArrayContainsItem(IItem item)
        {
            for(int i = 0; i<=current; i++)
            {
                if (items[i] == item)
                {
                    return i;
                }
            }
            return capacity;
        }

        public void RemoveItem(int index)
        {
            if (index < capacity)
            {
                items[index] = null;

                int i = index;

                while (items[i + 1] != null || i + 1 != capacity)
                {
                    items[i] = items[i + 1];
                    items[i + 1] = null;
                    i++;
                }
            }
        }

        public void ShiftLeft()
        {
            if (items[0] == null)
            {
                return;
            }
            IItem temp = items[0];
            Array.Copy(items, 1, items, 0, items.Length - 1);
            Array.Clear(items, items.Length - 1, 1);
            items[current] = temp;

            /*
            IItem itemlast = items[current];
            items[current] = null;
            int i = current;

            while (i - 1 >=0)
            {
                items[i] = items[i - 1];
                items[i - 1] = null;
                i--;
            }
            items[0] = itemlast;*/
        }

        public void ShiftRight()
        {
            if (items[0] == null)
            {
                return;
            }

            Array.Copy(items, 0, items, 1, items.Length - 1);
            Array.Clear(items, 0, 1);
            IItem temp = items[current + 1];
            items[0] = temp;
            items[current + 1] = null;

            /*
            IItem item0 = items[0];
            items[0] = null;
            int i = 0;

            while (i != current)
            {
                items[i] = items[i + 1];
                items[i + 1] = null;
                i++;
            }
            items[current] = item0;
            */
        }
     
        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return enumerator;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            for(int i =0; i < capacity; i++)
            {
                if (items[i] != null)
                {
                    yield return items[i];
                }
                else break;
            }
        }
    }
}
