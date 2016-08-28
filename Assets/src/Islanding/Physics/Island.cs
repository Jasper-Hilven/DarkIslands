using UnityEngine;

namespace DarkIslands
{
    public partial class Island: ICircleElement
    {
        public Vector3 CollisionPosition { get { return this.Position; } }
    }
}