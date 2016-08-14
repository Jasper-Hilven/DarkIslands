using System;
using UnityEngine;

namespace DarkIslands
{
    public class Lightning:IElementType
    {
        public static string SGetName()
        {
            return "Lightning";
        }
        public string GetName()
        {
            return SGetName();
        }

        public Color GetColor()
        {
            return Color.yellow;
        }

        public float DamageMultiplierAgainst(IElementType other)
        {
            if (other.GetName() == Lightning.SGetName())
                return 1f;
            if (other.GetName() == Water.SGetName())
                return 3;
            if (other.GetName() == Magma.SGetName())
                return 0.5f;
            if (other.GetName() == Toxic.SGetName())
                return 1f;
            if (other.GetName() == Psychic.SGetName())
                return 0.5f;
            throw new Exception();
        }
    }
}