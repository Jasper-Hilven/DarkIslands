using System.Collections.Generic;
using System.Linq;

namespace DarkIslandGen
{
    public class ChangedGenerator
    {
        private CodeGenerator codeGenerator = new CodeGenerator();

        public List<CodeFile> GenerateChanged(ModelClass mClass)
        {
            return mClass.properties.Select(p => GenerateChanged(mClass, p)).Where(c => c != null).ToList();
        }


        public CodeFile GenerateChanged(ModelClass mClass,Property prop)
        {
            if (!mClass.IsParent)
                return null;
            var content = new List<string>
            {
                              "public interface "+GetInterfaceChangedName(mClass, prop),
                              "{"

                          };
            content.Add("void " + prop.Name + "Changed();");
            content.Add("}");
            var fileName = GetInterfaceChangedName(mClass,prop)+".cs";
            return codeGenerator.GenerateCodeFile(content, mClass, fileName);
        }

        public static string GetInterfaceChangedName(ModelClass mClass, Property prop)
        {
            return "I"+mClass.Name+prop.Name+"Changed";
        }
    }
}