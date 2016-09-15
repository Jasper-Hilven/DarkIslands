
using System.IO;

namespace DarkIslandGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelBuilder = new ModelBuilder();
            var model = modelBuilder.BuildModel();
            var dependencies = modelBuilder.GetDependencies();
            var factoryGeneratorFields = modelBuilder.GetFactoryGenerator();
            var codeGenerator = new Generator.Generator();
            var allFiles = codeGenerator.Generate(model,dependencies, factoryGeneratorFields);

            foreach (var codeFile in allFiles)
            {
                const string relativeFilePath = @"../../../darkislands/Assets/Gen/";
                var path = relativeFilePath + codeFile.FileName;
                var directory = Path.GetDirectoryName(path);
                Directory.CreateDirectory(directory);
                File.WriteAllLines(path, codeFile.Content);
            }
            //Factory
            //View controllers
            //ViewControllerFactory
            //Creation of subs when created
            //Updated of subs when updating properties

        }

    }
}
