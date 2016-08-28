using System.Collections.Generic;

namespace DarkIslands
{
    public class ElementalInfo
    {
        public ElementalInfo(IElementalType mainType, int level)
        {
            if (mainType.IsLightning)
                LightningLevel = level;
            if (mainType.IsMagma)
                MagmaLevel = level;
            if (mainType.IsToxic)
                ToxicLevel = level;
            if (mainType.IsWater)
                WaterLevel = level;
            if (mainType.IsPsychic)
                PsychicLevel = level;
        }
        public ElementalInfo(int lightningLevel, int magmaLevel, int psychicLevel, int toxicLevel, int waterLevel)
        {
            LightningLevel = lightningLevel;
            MagmaLevel = magmaLevel;
            PsychicLevel = psychicLevel;
            ToxicLevel = toxicLevel;
            WaterLevel = waterLevel;
        }
        public List<int> GetLevels { get { return new List<int> {LightningLevel,MagmaLevel,PsychicLevel,ToxicLevel,WaterLevel};} }
        public List<IElementalType> GetLevelOrder { get { return new List<IElementalType>
                                                               {
                                                                   new Lightning(),new Magma(), new Psychic(), new Toxic(), new Water()
                                                               }; } }
        public int LightningLevel { get; private set; }
        public int MagmaLevel { get; private set; }
        public int PsychicLevel { get; private set; }
        public int ToxicLevel { get; private set; }
        public int WaterLevel { get; private set; }
    }
}