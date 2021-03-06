﻿using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementUnityStatsViewFactory
    {
        private GameObjectManager gB = new GameObjectManager();

        public GameObject GetLifeVisualization(int lifePoints, int maxLifePoints)
        {
            return GetBarForStat(Color.red, Color.gray, Color.green, lifePoints,  maxLifePoints);
        }
        public GameObject GetManaVisualization(int manaPoints, int maxManaPoints)
        {
            return GetBarForStat(Color.black, Color.gray, Color.white, manaPoints, maxManaPoints);
        }
        public GameObject GetHydrationVisualization(int hydrationPoints, int maxHydrationPoints)
        {
            return GetBarForStat(Color.yellow, Color.gray, Color.blue, hydrationPoints, maxHydrationPoints);
        }

        private GameObject GetBarForStat(Color lowColor, Color neutralColor, Color highColor, float value, float maxValue)
        {
            float positiveValue = Mathf.Max(Mathf.Min(1f,value / (maxValue)),0);
            float negativeValue = 1.0001f - positiveValue;

            var barPositive = gB.LoadViaResources("Bar");
            var barNegative = gB.LoadViaResources("Bar");
            var barHolder = gB.LoadViaResources("BarHolder");
            barPositive.GetComponent<Renderer>().material.color = Color.Lerp(neutralColor, highColor, positiveValue*0.95f);
            barNegative.GetComponent<Renderer>().material.color = Color.Lerp(neutralColor, lowColor, negativeValue * 0.95f);
            barPositive.transform.SetParent(barHolder.transform);
            var size = 2f;
            barPositive.transform.localScale = size * new Vector3(positiveValue, 0.1f, 0.1f);
            barNegative.transform.localScale = size * new Vector3(negativeValue, 0.1f, 0.1f);
            barNegative.transform.localPosition = size * new Vector3(positiveValue /2f, 0, 0);
            barPositive.transform.localPosition = size * new Vector3(-(negativeValue / 2f), 0f, 0f);
            barNegative.transform.SetParent(barHolder.transform);
            return barHolder;
        }


        public void DestroyGO(GameObject gO)
        {
            gB.DestroyObj(gO);
        }

        public GameObject GetSpawnVisualization(int spawnTimeToLife, int maxSpawnTimeToLife)
        {
            return GetBarForStat(Color.blue, Color.gray, Color.red, spawnTimeToLife, maxSpawnTimeToLife);
        }
    }
}