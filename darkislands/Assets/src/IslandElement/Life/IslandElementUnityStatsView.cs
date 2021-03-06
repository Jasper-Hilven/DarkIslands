﻿using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementUnityStatsView
    {
        private IslandElement elem;
        private bool drawLifeStats;
        private GameObject lifeStats;
        private GameObject manaStats;
        private GameObject hydrationStats;
        private GameObject spawnStats;
        private IslandElementUnityStatsViewFactory fac;

        public override void Init(IslandElement IslandElement, IslandElementUnityStatsViewFactory IslandElementUnityStatsViewFactory)
        {
            drawLifeStats = false;
            elem = IslandElement;
            fac = IslandElementUnityStatsViewFactory;
            base.Init(IslandElement, IslandElementUnityStatsViewFactory);
        }

        public override void IslandElementViewSettingsChanged()
        {
            DrawAllStats();
        }


        void deleteStats()
        {
            if (drawLifeStats)
            {
                fac.DestroyGO(lifeStats);
                fac.DestroyGO(manaStats);
                fac.DestroyGO(hydrationStats);
                fac.DestroyGO(spawnStats);
            }

        }

        void DrawAllStats()
        {
            if (!elem.IslandElementViewSettings.HasLifeStatVisualization)
                return;
            deleteStats();
            drawLifeStats = true;
            if (elem.MaxLifePoints != 0)
                lifeStats = fac.GetLifeVisualization(elem.LifePoints, elem.MaxLifePoints);
            if (elem.MaxManaPoints != 0 && elem.CanUseMana)
                manaStats = fac.GetManaVisualization(elem.ManaPoints, elem.MaxManaPoints);
            if (elem.MaxHydrationPoints != 0 && elem.CanDehydrate)
                hydrationStats = fac.GetHydrationVisualization(elem.HydrationPoints, elem.MaxHydrationPoints);
            if (elem.SpawnController.IsSpawned)
                spawnStats = fac.GetSpawnVisualization(elem.SpawnTimeToLife, elem.MaxSpawnTimeToLife);
            SetLifeStatsCorrectPosition();
        }
        private void SetLifeStatsCorrectPosition()
        {
            if (lifeStats != null)
                lifeStats.transform.localPosition = elem.Position + new Vector3(0, 3.2f, 0);
            if (manaStats != null)
                manaStats.transform.localPosition = elem.Position + new Vector3(0, 2.8f, 0);
            if (hydrationStats != null)
                hydrationStats.transform.localPosition = elem.Position + new Vector3(0, 2.4f, 0);
            if (spawnStats != null)
                spawnStats.transform.localPosition = elem.Position + new Vector3(0, 2.8f, 0);
        }
        public override void PositionChanged()
        {
            SetLifeStatsCorrectPosition();
        }

        public override void LifePointsChanged()
        {
            DrawAllStats();
        }

        public override void MaxLifePointsChanged()
        {
            DrawAllStats();
        }

        public override void ManaPointsChanged()
        {
            DrawAllStats();
        }

        public override void MaxManaPointsChanged()
        {
            DrawAllStats();
        }

        public override void HydrationPointsChanged()
        {
            DrawAllStats();
        }

        public override void MaxHydrationPointsChanged()
        {
            DrawAllStats();
        }

        public override void MaxSpawnTimeToLifeChanged()
        {
            DrawAllStats();
        }

        public override void SpawnTimeToLifeChanged()
        {
            DrawAllStats();
        }

        public override void Destroy()
        {
            deleteStats();
        }
    }
}