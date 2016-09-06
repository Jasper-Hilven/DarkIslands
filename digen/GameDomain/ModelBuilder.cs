using System.Collections.Generic;
using System.Linq;

namespace DarkIslandGen
{
    public class ModelBuilder
    {
        public List<ModelClass> BuildModel()
        {
            var circleProps = new Property("CircleElementProperties", "CircleElementProperties");
            var position = new Property("Position", new GType { name = "Vector3", dep = "UnityEngine" });
            var modelToEntity = new TVariable() { Name = "ModelToEntity", GType = new GType() { name = "ModelToEntity" } };
            var islandParts = IslandBuilder.GetIslandParts(position, circleProps, modelToEntity);
            var worldObjectParts = IslandElementBuilder.GetIslandElementParts(position, circleProps,modelToEntity);
            var all = new List<List<ModelClass>>() {islandParts,worldObjectParts};
            return all.SelectMany(c => c).ToList();
        }

        public List<string> GetDependencies()
        {
            return new List<string>
            {
            };
        }

        public List<string> GetFactoryGenerator()
        {
            return new List<string>() { "public ModelToEntity ModelToEntity= new ModelToEntity();" };
        }
    }
}