using System.Collections.Generic;
using System.Linq;

namespace DarkIslandGen
{
    public class CodeGenerator
    {

        //Add properties
        public List<string> GetDeps(ModelClass mClass)
        {

            var deps = mClass.GetDependencies();
            var knownDeps = deps.Select(d => "using " + d + ";").ToList();
            knownDeps.Add("using System.Collections.Generic;");
            return knownDeps;
        }

        public List<string> CreateMethod(string name, string type, List<TVariable> parameters, List<string> content)
        {
            var paramString = parameters.Count == 0 ? "" :
                parameters.Select(tv => tv.Draw())
                    .Aggregate((string a, string b) => a + ", " + b);
            var ret = new List<string> { "", "    public " + type + " " + name + "(" + paramString + "){" };
            ret.AddRange(content.Select(c => "      " + c));
            ret.Add("    }");
            return ret;

        }
        public List<string> CreateMethod(string name, string type, List<string> content)
        {
            return CreateMethod(name, type, new List<TVariable>(), content);
        }

        private string GenerateRelativePath(ModelClass mClass)
        {
            var prefix = (mClass.ParentRelation == null) ? "" : GenerateRelativePath(mClass.ParentRelation);
            return prefix + mClass.Name + @"\";
        }
        public CodeFile GenerateCodeFile(List<string> Content, ModelClass mClass, string FileName)
        {
            var fileName = GenerateRelativePath(mClass) + FileName;
            return new CodeFile { Content = Content, FileName = fileName };
        }
    }
}