﻿using UnityEngine;

namespace DarkIslands
{
    public partial class IslandSizeController
    {
        private static float _minimumSize = 3f;
        public override void Init(Island Island, IslandSizeControllerFactory IslandSizeControllerFactory)
        {
            Island.SizeController = this;
            this.Island = Island;
            base.Init(Island, IslandSizeControllerFactory);
        }

        public Island Island { get; set; }

        public void SetInitialSize(float f)
        {
            SetSize(f);
        }

        private void SetSize(float size)
        {
            var dropOff = size < this.Island.Size;
            size = (size < _minimumSize) ? _minimumSize : size;
            this.Island.Size = size;
            var islandSize = Island.Size;
            this.Island.Mass = GetMass(islandSize);
            if (!dropOff)
                return;
            foreach (var islandElement in Island.ContainerControllerIsland.IslandElements)
                islandElement.DropOffController.DoDropOffIfOffIsland();
        }

        private static float GetMass(float islandSize)
        {
            return 1000f + islandSize * islandSize * 10000f;
        }

        public void RemoveByCollision(float f)
        {
            var oldSize = Island.Size;
            var oldSurface = oldSize * oldSize;
            var newSurface = oldSurface - f / 10000;
            var newSize = Mathf.Sqrt(newSurface < 0 ? 0 : newSurface);
            SetSize(newSize);
        }

        public bool CanRemoveByMagic()
        {
            return _minimumSize <  Island.Size;
        }

        public void RemoveByMagic(int i)
        {
            var oldSize = Island.Size;
            var oldSurface = oldSize * oldSize;
            var newSurface = oldSurface - i * 100;
            SetSize(Mathf.Sqrt(newSurface < 0 ? 0 : newSurface));
        }

        public void GiveByMagic(int i)
        {
            var oldSize = Island.Size;
            var oldSurface = oldSize * oldSize;
            var newSurface = oldSurface + i * 100;
            SetSize(Mathf.Sqrt(newSurface < 0 ? 0 : newSurface));
        }
    }
}