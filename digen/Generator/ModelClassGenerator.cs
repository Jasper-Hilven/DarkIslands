using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkIslandGen
{
    public class ModelClassGenerator
    {
        private CodeGenerator codeGen = new CodeGenerator();
        public CodeFile GenerateModelClassFile(ModelClass mClass)
        {
            var ret = codeGen.GetDeps(mClass);
            ret.Add("namespace DarkIslands");
            ret.Add("{");
            ret.Add("  public partial class " + mClass.Name + DefaultInherit(mClass));
            ret.Add("  {");
            if(mClass.IsChild)
                ret.AddRange(GenerateChildConstructor(mClass));
            if (mClass.IsParent)
            {
                ret.AddRange(mClass.properties.Select(
                    p =>
                        "  public List<I" + mClass.Name + p.Name + "Changed> Change" + p.Name + "Listeners= new List<I" +
                        mClass.Name + p.Name + "Changed>();"));
                ret.AddRange(GenerateParentProperties(mClass));
            }
            
            ret.Add("  }");
            ret.Add("}");
            return codeGen.GenerateCodeFile(ret, mClass, mClass.Name + ".cs");
            //(new CodeFile() { Content = ret, FileName =  });
        }

        private string DefaultInherit(ModelClass mClass)
        {
            return mClass.IsChild ? ":" + mClass.Name + "Default" : "";
        }

        private List<string> GenerateParentProperties(ModelClass mClass)
        {

            return mClass.properties.Select(p => GetPropertyGetSet(mClass, p)).SelectMany(p => p).ToList();
        }

        private static List<string> GetPropertyGetSet(ModelClass mClass, Property p)
        {
            return new List<string>
                   {
                       "    public " + p.Type.name + " " + p.Name,
                       "    {",
                       "      get{",
                       "        return _" + p.Name + ";",
                       "      }",
                       "      set",
                       "      {",
                       "        this._" + p.Name + "= value;",
                       "        foreach( var v" + mClass.Name + p.Name+ "Changed in "+("Change"+ p.Name+"Listeners")+")",
                       "          v" + mClass.Name + p.Name+ "Changed." + p.Name + "Changed();",
                       "      }",
                       "    }",
                       "      private "+p.Type.name + " _"+p.Name + "{get;set;}"
                   };
        }

        private List<string> GenerateChildContainsParent(ModelClass parentClass)
        {
            return new List<string> { "public " + parentClass.Name + " " + parentClass.Name };
        }

        private List<string> GenerateParentPropertiesConstructor()
        {
            throw new NotImplementedException();
        }
        private List<string> GenerateChildConstructor(ModelClass mClass)
        {
            var parentName = mClass.ParentRelation.Name;
            var factoryName = mClass.Name + "Factory";
            return new List<string>
               {
                   "    public " + mClass.Name + "(" + parentName + " " + parentName + ", " + factoryName + " " +
                   factoryName + "){",
                   "    Init("+parentName+ ", "+ factoryName+");",
                   "    }"
               };
        }
    }
}