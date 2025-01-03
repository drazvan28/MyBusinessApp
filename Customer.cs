namespace MyBusinessApp
{
    public class Customer : BusinessEntity
    {
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Customer(int id, string name, string email)
            : base(id, name)
        {
            this.Email = email;
        }

        public override string ToString()
        {
            return base.ToString() + ", Email: " + Email;
        }
    }
}
