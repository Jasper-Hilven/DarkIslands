using UnityEngine;

namespace DarkIslands
{
    public interface ICircleElement
    {
        CircleElementProperties CircleElementProperties { get; }
        Vector3 CollisionPosition { get; }
    }

    public class CircleElementProperties
    {
        public CircleElementProperties(float radius)
        {
            Radius = radius;
        }

        public float Radius { get; private set; }

    }
}