using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public partial class UnitELementView
    {
        private List<GameObject> ElementBalls= new List<GameObject>();
        public override void Init(Unit Unit, UnitELementViewFactory UnitELementViewFactory)
        {
            this.Unit = Unit;
            this.UnitElementViewFactory = UnitELementViewFactory;
            base.Init(Unit, UnitELementViewFactory);
        }

        public UnitELementViewFactory UnitElementViewFactory { get; set; }
        public Unit Unit { get; set; }
        private float rotationTime = 0f;

        public override void hasElementViewChanged()
        {
            UpdateView();
        }

        public override void ElementInfoChanged()
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
            var elementInfo = this.Unit.ElementInfo;
            this.UnitElementViewFactory.DeActivate(this);
            if (!this.Unit.hasElementView)
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
                var rotTrans = 0.4f;
                var pos = Unit.Position + new Vector3(rotTrans*Mathf.Cos(rotation), 2, rotTrans*Mathf.Sin(rotation));
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