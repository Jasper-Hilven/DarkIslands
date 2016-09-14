using UnityEngine;

namespace DarkIslands
{

    public interface IIndexedElement
    {
        Vector3 IndexPosition { get; }
    }

    public interface ICircleElement: IIndexedElement
    {
        CircleElementProperties CircleElementProperties { get; }
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