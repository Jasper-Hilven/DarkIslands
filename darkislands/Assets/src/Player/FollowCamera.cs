﻿using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public class FollowCamera
    {
        private Camera camera;
        public IslandElement toFollow;
        public FollowCamera()
        {
        }

        public void SetUnit(IslandElement unit)
        {
            this.toFollow = unit;
        }
        public void update()
        {
            if(camera == null)
                camera = Camera.allCameras.First();
            camera.transform.rotation= Quaternion.Euler(50,0,0);
            camera.transform.position = this.toFollow.Position + GetRelativePosition();
        }
        public Vector3 GetToFollowPosition()
        {
            return this.toFollow.Position;
        }

        public Vector3 GetRelativePosition()
        {
            return new Vector3(0, 17, -17);
        }
        public Vector3 GetPosition()
        {
            return camera.transform.position;
        }
    }
}