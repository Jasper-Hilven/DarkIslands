using System;
using UnityEngine;

namespace DarkIslands
{
    public class Psychic:IElementalType
    {
        public static string SGetName()
        {
            return "Psychic";
        }
        public string GetName()
        {
            return SGetName();
        }

        public int GetIndex()
        {
            return 2;
        }

        public Color GetColor()
        {
            return Color.white;
        }

        public bool IsLightning { get; private set; }
        public bool IsMagma { get; private set; }
        public bool IsPsychic { get { return true; } }
        public bool IsToxic { get; private set; }
        public bool IsWater { get; private set; }

        public float DamageMultiplierAgainst(IElementalType other)
        {
            if (other.GetName() == Psychic.SGetName())
                return 1f;
            if (other.GetName() == Lightning.SGetName())
                return 3f;
            if (other.GetName() == Water.SGetName())
                return 0.5f;
            if (other.GetName() == Magma.SGetName())
                return 1;
            if (other.GetName() == Toxic.SGetName())
                return 0.5f;
            throw new Exception();
        }
    }
}