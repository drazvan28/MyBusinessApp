namespace MyBusinessApp
{
    public class BusinessEntity
    {
        private int id;
        private string name;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public BusinessEntity(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + Name;
        }
    }
}