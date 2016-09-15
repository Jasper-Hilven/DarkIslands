using System.Collections.Generic;
using System.Linq;

namespace DarkIslandGen.Generator
{
    public class FactoryProviderGenerator
    {

        public List<string> GenerateAllFields(List<ModelClass> mClassList)
        {
            return mClassList.Where(mC => mC.HasFactory)
                .Select(mc =>
                        {
                            var facName = mc.Name + "Factory";
                            return "    public " + facName + " " + facName + ";";
                        }).ToList();
        }
        public CodeFile GenerateProvider(List<ModelClass> mClassList,List<string> dependencies,List<string> factoryFields)
        {
            var content =
                new List<string>
                {
                    "namespace DarkIslands",
                    "{",
                    "  public class FactoryProvider",
                    "  {"

                  };

            content.AddRange(GenerateAllFields(mClassList));
            content.AddRange(factoryFields);
            content.AddRange(BuildInitialize(mClassList,dependencies));
            content.Add("  }");
            content.Add("}");
            return new CodeFile { Content = content, FileName = "FactoryProvider.cs" };
        }

        private List<string> BuildInitialize(List<ModelClass> mClassList,List<string> dependencies)
        {
            var initializations = mClassList.Select(mC =>
            {
                var paramz = mC.ConstructionInjected.Count == 0? ""
                    : mC.ConstructionInjected.Select(cI => cI.Name).Aggregate((a, b) => a + "," + b);
                return "      this." + mC.Name + "Factory= new " + mC.Name + "Factory(" + paramz + ");";
            });

            var childAdding =
                mClassList.Where(mC => mC.IsChild)
                .Select(mC => "      " + mC.ParentRelation.Name + "Factory.SubFactories.Add(" + mC.Name + "Factory);");
            var content = new List<string>
            { "    public void Initialize(){"};
            content.AddRange(dependencies);
            content.AddRange(initializations);
            content.AddRange(childAdding);
            content.Add("    }");
            return content;

        }
    }
}