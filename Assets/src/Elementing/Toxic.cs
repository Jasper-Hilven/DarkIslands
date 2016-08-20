using System;
using UnityEngine;

namespace DarkIslands
{
    public class Toxic:IElementType
    {
        public static string SGetName()
        {
            return "Toxic";
        }

        string IElementType.GetName()
        {
            return SGetName();
        }

        public int GetIndex()
        {
            return 3;
        }

        public Color GetColor()
        {
            return Color.cyan;
        }

        public bool IsLightning { get; private set; }
        public bool IsMagma { get; private set; }
        public bool IsPsychic { get; private set; }
        public bool IsToxic { get { return true; } }
        public bool IsWater { get; private set; }

        public float DamageMultiplierAgainst(IElementType other)
        {
            if (other.GetName() == Toxic.SGetName())
                return 1f;
            if (other.GetName() == Psychic.SGetName())
                return 3;
            if (other.GetName() == Lightning.SGetName())
                return 0.5f;
            if (other.GetName() == Water.SGetName())
                return 1;
            if (other.GetName() == Magma.SGetName())
                return 0.5f;
            throw new Exception();
        }
    }
}