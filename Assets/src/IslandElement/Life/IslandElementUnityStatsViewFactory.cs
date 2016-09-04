using System.Collections.Generic;
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

        private GameObject GetBarForStat(Color lowColor, Color neutralColor, Color highColor, float value, float maxValue)
        {
            float positiveValue = ((float)value) / maxValue;
            float negativeValue = 1f - positiveValue;

            var barPositive = gB.LoadViaResources("Bar");
            var barNegative = gB.LoadViaResources("Bar");
            var barHolder = gB.LoadViaResources("BarHolder");
            barPositive.GetComponent<Renderer>().material.color = Color.Lerp(neutralColor, highColor, positiveValue);
            barNegative.GetComponent<Renderer>().material.color = Color.Lerp(neutralColor, lowColor, negativeValue);
            barPositive.transform.SetParent(barHolder.transform);
            barPositive.transform.localScale = new Vector3(positiveValue, 0.1f, 0.1f);
            barNegative.transform.localScale = new Vector3(negativeValue, 0.1f, 0.1f);
            barPositive.transform.localPosition = new Vector3(-(negativeValue/2f), 0, 0);
            barNegative.transform.localPosition = new Vector3(positiveValue/2f, 0, 0);
            barNegative.transform.SetParent(barHolder.transform);
            return barHolder;
        }

        public GameObject GetManaVisualization(int manaPoints, int maxManaPoints)
        {
            return GetBarForStat(Color.black, Color.gray, Color.cyan, manaPoints, maxManaPoints);
        }
        public GameObject GetHydrationVisualization(int hydrationPoints, int maxHydrationPoints)
        {
            return GetBarForStat(Color.yellow, Color.gray, Color.blue, hydrationPoints, maxHydrationPoints);
        }

        public void DestroyGO(GameObject gO)
        {
            gB.DestroyObj(gO);
        }
    }
}