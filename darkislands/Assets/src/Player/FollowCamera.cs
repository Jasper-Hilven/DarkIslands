using System.Linq;
using UnityEngine;

namespace DarkIslands.Player
{
    public class FollowCamera
    {
        private Camera camera;
        public IslandElement toFollow;
        public FollowCamera(IslandElement unit)
        {
            this.toFollow = unit;
        }

        public void update()
        {
            if(camera == null)
                camera = Camera.allCameras.First();
            camera.transform.rotation= Quaternion.Euler(50,0,0);
            camera.transform.position = this.toFollow.Position + new Vector3(0, 19, -19);
            
        }
    }
}