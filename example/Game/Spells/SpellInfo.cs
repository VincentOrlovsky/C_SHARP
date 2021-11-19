using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Spells
{
    public class SpellInfo
    {
        public string Name { get; set; }
        public SpellType SpellType { get; set; }
        public IEnumerable<string> EffectNames { get; set; }
        public string AnimationPath { get; set; }
        public int AnimationWidth { get; set; }
        public int AnimationHeight { get; set; }

        public static implicit operator SpellInfo(string line)
        {
            string[] values = line.Split(';');
            SpellInfo info = new SpellInfo { Name = values[0], AnimationPath = values[2], AnimationWidth = Int32.Parse(values[3]) ,AnimationHeight = Int32.Parse(values[4]) };

            if (values[1].ToLower().Equals("projectile"))
            {
                info.SpellType = SpellType.Projectile;
            }
            else
            {
                info.SpellType = SpellType.SelfCast;
            }

            string[] effects = values[5].Split(',');
            info.EffectNames = effects;

            return info;
        }
    }

}
