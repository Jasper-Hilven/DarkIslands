using UnityEngine;

namespace DarkIslands
{
    public struct IntVector2
    {
        public int x, y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static IntVector2 operator +(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.x + b.x, a.y + b.y);
        }

        public static IntVector2 operator +(IntVector2 a, Vector2 b)
        {
            return new IntVector2(a.x + (int)b.x, a.y + (int)b.y);
        }

        public static IntVector2 operator -(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.x - b.x, a.y - b.y);
        }

        public static IntVector2 operator -(IntVector2 a, Vector2 b)
        {
            return new IntVector2(a.x - (int)b.x, a.y - (int)b.y);
        }

        public static IntVector2 operator *(IntVector2 a, int b)
        {
            return new IntVector2(a.x * b, a.y * b);
        }

        public override bool Equals(System.Object obj)
        {
            return obj is IntVector2 && this == (IntVector2)obj;
        }
        public override int GetHashCode()
        {
            return x ^ y;
        }
        public static bool operator ==(IntVector2 x, IntVector2 y)
        {
            return x.x == y.x && x.y == y.y;
        }
        public static bool operator !=(IntVector2 x, IntVector2 y)
        {
            return !(x == y);
        }
    }

}