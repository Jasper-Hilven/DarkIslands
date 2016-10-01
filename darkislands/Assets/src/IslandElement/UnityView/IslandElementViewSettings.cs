using System;
using UnityEngine;

namespace DarkIslands
{
    public class IslandElementViewSettings
    {
        public Func<GameObject> GetGameObject { get; set; }
        public int Seed { get; set; }
        public bool HasLifeStatVisualization { get; set; }
    }
}