using System.Linq;
using UnityEngine;

namespace DarkIslands.Player
{
    public class FollowCamera
    {
        private Camera camera;
        public Unit toFollow;
        public FollowCamera(Unit unit)
        {
            this.toFollow = unit;
        }

        public void update()
        {
            if(camera == null)
                camera = Camera.allCameras.First();
            camera.transform.position = this.toFollow.Position + new Vector3(0, 4, 0);
        }
    }
}