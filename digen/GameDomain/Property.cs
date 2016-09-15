namespace DarkIslandGen
{
    public class Property
    {
        public Property(string name, GType type)
        {
            Name = name;
            Type = type;
        }
        public Property(string name, string type)
        {
            Name = name;
            Type = new GType { name = type };
        }
        public string Name { get; private set; }
        public GType Type { get; private set; }
        public bool UsedByChildren { get; set; }
    }
}