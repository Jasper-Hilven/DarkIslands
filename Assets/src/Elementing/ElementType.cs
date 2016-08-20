using UnityEngine;

namespace DarkIslands
{
    public interface IElementType
    {
        string GetName();
        int GetIndex();
        float DamageMultiplierAgainst(IElementType other);
        Color GetColor();

        bool IsLightning { get; }
        bool IsMagma { get; }
        bool IsPsychic { get; }
        bool IsToxic { get; }
        bool IsWater { get; }
    }

}