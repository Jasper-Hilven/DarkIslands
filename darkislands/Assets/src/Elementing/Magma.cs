using System;
using UnityEngine;

namespace DarkIslands
{
    public class Magma:IElementalType
    {
        public string GetName()
        {
            return SGetName();
        }

        public int GetIndex()
        {
            return 1;
        }

        public static string SGetName()
        {
            return "Magma";
        }
        public Color GetColor()
        {
            return Color.red;
        }

        public bool IsLightning { get; private set; }
        public bool IsMagma { get { return true; } }
        public bool IsPsychic { get; private set; }
        public bool IsToxic { get; private set; }
        public bool IsWater { get; private set; }


        public float DamageMultiplierAgainst(IElementalType other)
        {
            if (other.GetName() == Magma.SGetName())
                return 1f;
            if (other.GetName() == Toxic.SGetName())
                return 3f;
            if (other.GetName() == Psychic.SGetName())
                return 0.5f;
            if (other.GetName() == Lightning.SGetName())
                return 1f;
            if (other.GetName() == Water.SGetName())
                return 1;
            throw new Exception();
        }
    }
}