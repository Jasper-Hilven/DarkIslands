using System.Linq;


namespace DarkIslands
{
    public class AttackIfNearOthersNotifier:INearOthersNotifier
    {
        private IslandElement elem;

        public AttackIfNearOthersNotifier(IslandElement elem)
        {
            this.elem = elem;
        }


        public void NotifyChanges()
        {
            var elems=  elem.NearOthersController.GetNearElements().Where(e => elem.TeamController.IsHostileTowards(e)).ToList();
            if (elems.Count == 0)
            {
                elem.ActionHandler.SetNextCommand(null);
                return;
            }
            elem.ActionHandler.SetNextCommand(new OtherIslandElementCommand(elem,elems[0]));
        }
    }
}