﻿using System;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementLifeController
    {
        private IslandElement elem;

        public override void Init(IslandElement IslandElement, IslandElementLifeControllerFactory IslandElementLifeControllerFactory)
        {
            
            this.elem = IslandElement;
            this.elem.LifePoints = 10;
            this.elem.MaxLifePoints = 10;
            this.elem.LifeController = this;
        }

        public void DieDueToFalling()
        {
            Die();
        }

        public void Die()
        {
            elem.IsAlive = false;
            elem.Factory.DestroyIslandElement(elem);
        }

        private void CheckDie()
        {
            if (this.elem.LifePoints > 0)
                return;
            Die();
        }
        public void Hurt(int lifePoints)
        {
            var oldLifePoints = this.elem.LifePoints;
            var newLifePoints = Math.Max((oldLifePoints - lifePoints),0);
            this.elem.LifePoints = newLifePoints;
            CheckDie();
        }

        public void HurtDueToDeHydration(int i)
        {
            Hurt(i);
        }
    }
}