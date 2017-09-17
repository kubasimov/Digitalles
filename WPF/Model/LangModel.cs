namespace WPF.Model
{
    public class LangModel
    {
        public string Name { get; set; }
        public string Shortname { get; set; }

        public LangModel(string name, string shortname)
        {
            Name = name;
            Shortname = shortname;
        }

        public override string ToString()
        {
            return Name;
        }

        public string ToStringShortName()
        {
            return Shortname;
        }

    }
}