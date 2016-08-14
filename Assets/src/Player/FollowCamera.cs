using System.Linq;
using UnityEngine;

namespace DarkIslands.Player
{
    public class FollowCamera
    {
        private Camera camera;
        public Ship ship;
        public FollowCamera(Ship ship)
        {
            this.ship = ship;
        }

        public void update()
        {
            if(camera == null)
                camera = Camera.allCameras.First();
            camera.transform.position = this.ship.Position + new Vector3(0, 0, -10);
        }
    }
}