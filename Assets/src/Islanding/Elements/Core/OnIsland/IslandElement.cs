using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElement : ICircleElement
    {
        public Vector3 CollisionPosition { get { return this.RelativeToContainerPosition; } }
    }
}