using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkIslandGen
{
    public class FactoryGenerator
    {
        private CodeGenerator codeGen = new CodeGenerator();

        private List<string> GetElementFactoryInterface(ModelClass mClass)
        {
            var content = new List<string> { "    public interface" + GetSubFactoryType(mClass) };
            content.Add("  {");
            content.Add("    void Extend" + mClass.Name + "(" + mClass.Name + " " + mClass.Name + ");");
            content.Add("    void RemoveExtension" + "(" + mClass.Name + " " + mClass.Name + ");");
            content.Add("  }");
            return content;
        }

        public string GetSubFactoryType(ModelClass mClass)
        {
            return "I" + mClass.Name + "ElementFactory";
        }

        public List<string> GetElementInterface(ModelClass mClass)
        {
            var name = mClass.Name;
            return new List<string>
            {
                "  public interface I"+name + "ElementFactory{",
                "    void Extend"+ name + "("+ name + " " + name + ");",
                "    void RemoveExtension"+ "("+ name + " " + name + ");",
                "  }"

            };
        }
        
        

        public CodeFile GenerateFactory(ModelClass mClass)
        {
            if (!mClass.HasFactory)
                throw new Exception("No factory required");
            var parentElements = "    public List<" + mClass.Name + "> elements= new List<" + mClass.Name + ">();";
            var subFactoryTypeListType = "List<" + GetSubFactoryType(mClass) + ">";
            var subFactories = "    public " + subFactoryTypeListType + " SubFactories= new " + subFactoryTypeListType + "();";
            var elementInterface = GetElementInterface(mClass);
            var build = GenerateCreate(mClass);
            var destroy = GenerateDestroy(mClass);
            var childLine = mClass.IsChild ? (": " + GetSubFactoryType(mClass.ParentRelation)) : "";

            var ret = codeGen.GetDeps(mClass);
            ret.Add("namespace DarkIslands");
            ret.Add("{");
            ret.Add("  public partial class " + mClass.Name + "Factory" + childLine);
            ret.Add("  {");
            if (mClass.IsParent)
            {
                ret.AddRange(GenerateFactoryConstructorAndFields(mClass));
                ret.Add(parentElements);
                ret.Add(subFactories);
                ret.AddRange(build);
                ret.AddRange(destroy);
            }
            if (mClass.IsChild)
            {
                ret.Add(GenerateElementsForChild(mClass));
                ret.AddRange(GenerateFactoryConstructorAndFields(mClass));
                ret.AddRange(GenerateRemoveExtension(mClass));
                ret.AddRange(GenerateExtend(mClass));
            }
            ret.Add("  }");
            if (mClass.IsParent)
                ret.AddRange(elementInterface);
            ret.Add("}");
            var fileName = mClass.Name + "Factory.cs";
            return codeGen.GenerateCodeFile(ret, mClass, fileName);
        }


        private List<string> GenerateFactoryConstructorAndFields(ModelClass mClass)
        {
            if (mClass.ConstructionInjected.Count == 0)
                return new List<string>();
            var fields = mClass.ConstructionInjected.Select(f => "    public " + f.Draw() + ";");
            var paramz = mClass.ConstructionInjected.Select(p => p.GType.name + " " + p.Name).Aggregate((a, b) => a + ", " + b);
            var assignField = mClass.ConstructionInjected.Select(p => "      this." + p.Name + "= " + p.Name+";");
            var ret = new List<string>();
            ret.AddRange(fields);
            ret.Add("");
            ret.Add("    public " + mClass.Name + "Factory("+paramz+"){");
            ret.AddRange(assignField);
            ret.Add("    }");
            return ret;
        } 

        private string GenerateElementsForChild(ModelClass mClass)
        {
            var dType = "Dictionary<" + mClass.ParentRelation.Name + "," + mClass.Name + ">";
            return "public "+dType+" Elements= new "+dType+"();";
        }
        //ParentOnly
        private List<string> GenerateCreate(ModelClass mClass)
        {
            var ret = new List<string>();
            var parentLines = new List<string>
            {
                "foreach (var subFactory in SubFactories)",
                "  subFactory.Extend"+mClass.Name+"(ret);"
            };
            var content = new List<string>
            {   "var ret= new " + mClass.Name + "();",
                "elements.Add(ret);"
            };
            var retLine = "return ret;";
            ret.AddRange(content);
            if (mClass.IsParent)
                ret.AddRange(parentLines);
            ret.Add(retLine);
            return codeGen.CreateMethod("Create", mClass.Name, ret);
        }
        //Parent only
        private List<string> GenerateDestroy(ModelClass mClass)
        {
            var name = "Destroy" + mClass.Name;
            var paramz = new List<TVariable> { TVariable.FromMClass(mClass) };
            var ret = new List<string>();
            var parentLines = new List<string>
            {
                "foreach (var subFactory in SubFactories)",
                "  subFactory.RemoveExtension("+mClass.Name+");"
            };
            var content = new List<string>
            {
                "elements.Remove("+mClass.Name+");"
            };
            ret.AddRange(content);
            if (mClass.IsParent)
                ret.AddRange(parentLines);
            return codeGen.CreateMethod(name, "void", paramz, ret);
        }
        //Child only
        private List<string> GenerateRemoveExtension(ModelClass mClass)
        {
            var parent = mClass.ParentRelation;
            var paramz = TVariable.FromMClass(parent);
            var mContent = new List<string> {
                "var element = Elements[" + paramz.Name + "];",
            "element.Destroy();",
            "Elements.Remove("+paramz.Name+");"};
            return codeGen.CreateMethod("RemoveExtension", "void", new List<TVariable> { paramz }, mContent);
        }
        //Child only
        private List<string> GenerateExtend(ModelClass mClass)
        {
            var parent = mClass.ParentRelation;
            var paramz = TVariable.FromMClass(parent);
            var mContent = new List<string> {
                "var element =new "+mClass.Name + "("+ paramz.Name + ", this);",
            "Elements.Add("+paramz.Name+",element);"
            };
            mContent.AddRange(mClass.UseFromParent.Select(p=> paramz.Name + ".Change"+p.Name+"Listeners.Add(element);"));
            return codeGen.CreateMethod("Extend"+parent.Name, "void", new List<TVariable> { paramz }, mContent);
        }
    }
}