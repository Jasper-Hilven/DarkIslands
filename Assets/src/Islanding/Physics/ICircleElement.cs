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
        public CircleElementProperties(float radius,float originalRadius)
        {
            Radius = radius;
            OriginalRadius = radius;
        }

        public float OriginalRadius { get; set; }

        public float Radius { get; private set; }

    }
}