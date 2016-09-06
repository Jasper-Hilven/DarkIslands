using UnityEngine;

namespace DarkIslands
{
    public interface IElementalType
    {
        string GetName();
        int GetIndex();
        float DamageMultiplierAgainst(IElementalType other);
        Color GetColor();

        bool IsLightning { get; }
        bool IsMagma { get; }
        bool IsPsychic { get; }
        bool IsToxic { get; }
        bool IsWater { get; }
    }

}