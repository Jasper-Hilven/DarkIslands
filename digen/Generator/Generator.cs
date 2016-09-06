using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkIslandGen.Generator
{
    class Generator
    {
        private readonly DefaultGenerator dGenerator = new DefaultGenerator();
        private readonly FactoryGenerator fGenerator = new FactoryGenerator();
        private readonly ChangedGenerator changedGenerator = new ChangedGenerator();
        private readonly ModelClassGenerator mClassGenerator = new ModelClassGenerator();
        private readonly FactoryProviderGenerator factoryProviderGenerator = new FactoryProviderGenerator();
        public List<CodeFile> Generate(List<ModelClass> modelClasses, List<string> dependencies,List<string> factoryFields)
        {
            var codeFiles = modelClasses
                .SelectMany(mC =>
                            {
                                var files = new List<CodeFile>()
                                            {
                                                fGenerator.GenerateFactory(mC),
                                                mClassGenerator.GenerateModelClassFile(mC),
                                                dGenerator.GenerateModelClassFile(mC)
                                            };
                                files.AddRange(changedGenerator.GenerateChanged(mC));
                                return files;
                            })
                .Where(c => c != null).ToList();
            codeFiles.Add(factoryProviderGenerator.GenerateProvider(modelClasses, dependencies, factoryFields));
            return codeFiles;
        }


    }
}
