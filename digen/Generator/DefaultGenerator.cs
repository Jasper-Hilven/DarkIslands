using System.Collections.Generic;
using System.Linq;

namespace DarkIslandGen
{
    public class DefaultGenerator
    {
        private CodeGenerator codeGenerator;

        public DefaultGenerator()
        {
            codeGenerator = new CodeGenerator();
        }

        public CodeFile GenerateModelClassFile(ModelClass mClass)
        {
            if (!mClass.IsChild)
                return null;
        var content = new List<string>
        {"namespace DarkIslands{",
                              "  public class " + mClass.Name+ "Default" + GetChangedInterfaceExtension(mClass),
                "  {",
                "    public virtual void Destroy(){",
                "    }"
                
                          };
            if(mClass.IsChild)
                content.AddRange(DefaultInitMethod(mClass));
            if(mClass.IsChild)
                content.AddRange(GetChangedInterfaceImplementation(mClass));
            content.Add("  }");
            content.Add("}");
            var fileName = mClass.Name+ "Default" + ".cs";
            return codeGenerator.GenerateCodeFile(content, mClass, fileName);
        }
        private string GetChangedInterfaceExtension(ModelClass mClass)
        {

            if (!mClass.IsChild)
                return "";
            if (mClass.UseFromParent.Count == 0)
                return "";
            var interfaceNames =
                mClass.UseFromParent
                    .Select(p => ChangedGenerator.GetInterfaceChangedName(mClass.ParentRelation, p)).Aggregate((a,b)=> a+ ", "+ b);
            return ": " + interfaceNames;
        }

        private List<string> GetChangedInterfaceImplementation(ModelClass mClass)
        {
            return mClass.UseFromParent.Select(p => "    public virtual void " + p.Name + "Changed(){}").ToList();
        }
        private List<string> DefaultInitMethod(ModelClass mClass)
        {
            var parentName = mClass.ParentRelation.Name;
            var factoryName = mClass.Name + "Factory";

            return new List<string>
            {
                       "    public virtual void Init("+parentName + " "+ parentName+ ", "+ factoryName + " "+ factoryName+ "){",
                       "    }"
                   };
        }
    }
}