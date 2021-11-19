using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game.Spells
{
    public class SpellDataProvider : ISpellDataProvider   //treba aplikovat Singleton pattern 
    {
        private static SpellDataProvider instance = null;

        private static readonly string spellsPath = "resources/spells.csv";
        private static readonly string effectsPath = "resources/effects.json";

        private Dictionary<string, int> spellEffects;
        private Dictionary<string, SpellInfo> spellInfo;

        private SpellDataProvider()
        {

        }

        public static SpellDataProvider GetInstance()
        {
            if(instance == null)
            {
                instance = new SpellDataProvider();
            }

            return instance;
        }

        public Dictionary<string, int> GetSpellEffects()
        {
            
            if(spellEffects == null)
            {
               spellEffects =  LoadSpellEffects();
            }
            return spellEffects;
        }

        public Dictionary<string, SpellInfo> GetSpellInfo()
        {
            if(spellInfo == null)
            {
                spellInfo = LoadSpellInfo();
            }
            return spellInfo;
        }

        private Dictionary<string, SpellInfo> LoadSpellInfo()
        {
            List<string> lines = File.ReadAllLines(spellsPath).Skip(1).ToList();
            Dictionary<string, SpellInfo> dictionary = new Dictionary<string, SpellInfo>();

            foreach (string line in lines)
            {
                try
                {
                    SpellInfo spellInfo = line;
                    dictionary.Add(spellInfo.Name, spellInfo);
                }catch(ArgumentException e)
                {

                }    
            }

            return dictionary;
        }

        private Dictionary<string, int> LoadSpellEffects()
        {
            string json = File.ReadAllText(effectsPath);
            List<SpellEffect> effects = JsonConvert.DeserializeObject<List<SpellEffect>>(json);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach(SpellEffect effect in effects)
            {
                dic.Add(effect.Name, effect.Cost);
            }
            return dic;
        }

        private class SpellEffect
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("cost")]  
            public int Cost { get; set; }
        }

        

        
    }
}
