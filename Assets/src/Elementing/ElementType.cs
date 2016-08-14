using UnityEngine;

namespace DarkIslands
{
    public interface IElementType
    {
        string GetName();
        float DamageMultiplierAgainst(IElementType other);
        Color GetColor();

    }

}