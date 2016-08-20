using System;
using System.Threading;
using UnityEngine;

namespace DarkIslands
{
    public class Water: IElementType 
    {
        public static string SGetName()
        {
            return "Water";
        }

        string IElementType.GetName()
        {
            return Water.SGetName();
        }

        public int GetIndex()
        {
            return 4;
        }

        public Color GetColor()
        {
            return Color.blue;
        }

        public bool IsLightning { get; private set; }
        public bool IsMagma { get; private set; }
        public bool IsPsychic { get; private set; }
        public bool IsToxic { get; private set; }
        public bool IsWater { get { return true; } }

        public float DamageMultiplierAgainst(IElementType other)
        {
            if (other.GetName() == Water.SGetName())
                return 1;
            if (other.GetName() == Magma.SGetName())
                return 3;
            if (other.GetName() == Toxic.SGetName())
                return 0.5f;
            if (other.GetName() == Psychic.SGetName())
                return 1;
            if (other.GetName() == Lightning.SGetName())
                return 0.5f;
            throw new Exception();
        }
    }
}