using UnityEngine;

namespace DarkIslands
{
    public partial class Island: ICircleElement
    {
        public Vector3 IndexPosition { get { return this.Position; } }
    }
}