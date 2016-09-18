using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementFightingController
    {
        public override void Init(IslandElement IslandElement, IslandElementFightingControllerFactory IslandElementFightingControllerFactory)
        {
            IslandElement.FightingController = this;
            DefenseValue = 1;
            this.DisableAttack();
            CanBeAttacked = false;
            this.IslandElement = IslandElement;
            base.Init(IslandElement, IslandElementFightingControllerFactory);
        }

        public void EnableCanBeAttacked(int defenseValue)
        {
            this.DefenseValue = defenseValue;
            this.CanBeAttacked = true;

        }

        public void DisableCanBeAttacked()
        {
            this.CanBeAttacked = false;
        }

        public void EnableAttack(int attackValue, int attackRange)
        {
            this.CanAttack = true;
            this.AttackValue = attackValue;
            this.AttackRange = attackRange;
        }

        public void DisableAttack()
        {
            this.CanAttack = false;
        }

        public IslandElement IslandElement { get; private set; }

        public int DefenseValue { get; set; }
        public int AttackValue { get; set; }
        public int AttackRange { get; set; } //Expressed in 10th of meters
        public bool CanAttack { get; set; }
        public bool CanBeAttacked { get; set; }
        public void GetAttacked(int Damage)
        {
            var damage = (float)Damage;
            damage = damage / DefenseValue;
            IslandElement.LifeController.Hurt(Mathf.CeilToInt(damage));
        }

        public void Attack(IslandElement other)
        {
            if (!CanAttackOther(other))
                return;
            other.FightingController.GetAttacked(AttackValue);
        }

        public bool CouldAttackIfCloseEnough(IslandElement other)
        {
            return IslandElement.IsAlive && other != null && other.IsAlive && CanAttack && other.FightingController.CanBeAttacked;
        }
        public bool IsCloseEnoughToAttack(IslandElement other)
        {
            var otherRadius = other.CircleElementProperties.Radius;
            var myRadius = IslandElement.CircleElementProperties.Radius;

            var maxRange = otherRadius + myRadius + AttackRange * 0.1f + 0.1f;
            return maxRange * maxRange > (other.Position - IslandElement.Position).sqrMagnitude;
        }

        public bool CanAttackOther(IslandElement other)
        {
            return CouldAttackIfCloseEnough(other) && IsCloseEnoughToAttack(other);
        }
    }
}