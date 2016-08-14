using System;
using UnityEngine;

namespace DarkIslands
{
    public class Psychic:IElementType
    {
        public static string SGetName()
        {
            return "Psychic";
        }
        public string GetName()
        {
            return SGetName();
        }
        public Color GetColor()
        {
            return Color.white;
        }

        public float DamageMultiplierAgainst(IElementType other)
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