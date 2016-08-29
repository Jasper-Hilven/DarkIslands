using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementElementalView
    {
        private List<GameObject> ElementBalls= new List<GameObject>();
        public override void Init(IslandElement IslandElement, IslandElementElementalViewFactory IslandElementElementalViewFactory)
        {
            this.IslandElement = IslandElement;
            this.UnitElementViewFactory = IslandElementElementalViewFactory;
        }

        public IslandElementElementalViewFactory UnitElementViewFactory { get; set; }

        public IslandElement IslandElement { get; set; }

        private float rotationTime = 0f;

        public override void hasElementalViewChanged()
        {
            UpdateView();
        }

        public override void ElementalInfoChanged()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            
            foreach (var ballz in ElementBalls.Where(eB => eB != null))
            {
                this.UnitElementViewFactory.DestroyElementView(ballz);
            }
            this.ElementBalls = new List<GameObject>();
            var elementInfo = this.IslandElement.ElementalInfo;
            this.UnitElementViewFactory.DeActivate(this);
            if (!this.IslandElement.hasElementalView)
            {
                return;
            }
            this.UnitElementViewFactory.Activate(this);
            for (int i = 0; i < elementInfo.GetLevels.Count; i++)
            {
                var levels = elementInfo.GetLevels;
                var size = levels[i];
                this.ElementBalls.Add(size == 0
                    ? null
                    : this.UnitElementViewFactory.GetElementView(elementInfo.GetLevelOrder[i], size));
            }
            UpdateBallPosition();
        }

        private void UpdateBallPosition()
        {
            const float rotationDiff = Mathf.PI/2.5f;
            for (int i = 0; i < ElementBalls.Count; i++)
            {
                if (ElementBalls[i] == null)
                    continue;
                var rotation = 4*(rotationTime+ rotationDiff*i);
                var rotTrans = 0.7f;
                var pos = IslandElement.Position + new Vector3(rotTrans*Mathf.Cos(rotation), 3, rotTrans*Mathf.Sin(rotation));
                ElementBalls[i].transform.localPosition = pos;
            }
        }
        public void Update(float deltaTime)
        {
            rotationTime += deltaTime;
            UpdateBallPosition();
        }
    }
}