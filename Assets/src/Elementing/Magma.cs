using System;
using UnityEngine;

namespace DarkIslands
{
    public class Magma:IElementType
    {
        public string GetName()
        {
            return SGetName();
        }
        public static string SGetName()
        {
            return "Magma";
        }
        public Color GetColor()
        {
            return Color.red;
        }


        public float DamageMultiplierAgainst(IElementType other)
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