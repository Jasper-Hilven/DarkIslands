namespace DarkIslandGen
{
    public class TVariable
    {
        public string Name { get; set; }
        public GType GType { get; set; }

        public static TVariable FromMClass(ModelClass mClass)
        {
            return new TVariable
            {
                Name = mClass.Name,
                GType = new GType
                {
                    dep = "",
                    name = mClass.Name
                }
            };
        }

        public string Draw()
        {
            return GType.name + " " + Name;
        }
    }

}