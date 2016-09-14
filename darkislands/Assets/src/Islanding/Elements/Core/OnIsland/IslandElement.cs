using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElement : ICircleElement
    {
        public Vector3 IndexPosition { get { return RelativeToContainerPosition; } }
    }
}