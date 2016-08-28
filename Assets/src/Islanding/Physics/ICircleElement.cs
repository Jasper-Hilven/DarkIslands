using UnityEngine;

namespace DarkIslands
{
    public interface ICircleElement
    {
        CircleElementProperties CircleElementProperties { get; }
    }

    public class CircleElementProperties
    {
        public CircleElementProperties(float radius, Vector3 position)
        {
            Radius = radius;
            Position = position;
        }

        public float Radius { get; private set; }
        public Vector3 Position { get; private set; }

    }
}