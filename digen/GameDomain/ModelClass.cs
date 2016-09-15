using System.Collections.Generic;
using System.Linq;

namespace DarkIslandGen
{
    public class ModelClass
    {
        public bool HasFactory { get; set; } //Defaults to true
        public string Name { get; set; }
        public List<Property> properties { get; set; }
        public List<TVariable> ConstructionInjected { get; set; }
        private ModelClass _ParentRelation { get; set; }
        private List<Property> _UseFromParent { get; set; }

        public List<Property> UseFromParent
        {
            get
            {
                return _UseFromParent.ToList();
            }
            set
            {
                foreach (var property in value)
                {
                    DoUseFromParent(property);
                }
            }
        }

        public ModelClass()
        {
            HasFactory = true;
            Children = new List<ModelClass>();
            _UseFromParent = new List<Property>();
            properties = new List<Property>();
            ConstructionInjected= new List<TVariable>();
        }

        public ModelClass(string Name):this()
        {
            this.Name = Name;
        }

        public ModelClass(string Name,ModelClass parent) : this(Name)
        {
            ParentRelation = parent;
        }

        public ModelClass ParentRelation
        {
            get { return _ParentRelation; }
            set
            {
                SetMeAsChildOfParent(value);
                _ParentRelation = value;
            }
        }
        public IEnumerable<string> GetDependencies()
        {
            return properties?.Select(p => p.Type.dep).Where(d => d != null).Distinct() ?? new List<string>();
        }
        public List<ModelClass> Children { get; set; }
        public bool IsParent {get { return Children.Count > 0; }}
        public bool IsChild { get { return ParentRelation!= null; } }
        private void SetMeAsChildOfParent(ModelClass parent)
        {
            parent.Children.Add(this);
        }
        public void DoUseFromParent(Property prop)
        {
            prop.UsedByChildren = true;
            _UseFromParent.Add(prop);
        }
    }
}
