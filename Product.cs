namespace MyBusinessApp
{
    public class Product : BusinessEntity
    {
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Product(int id, string name, decimal price)
            : base(id, name)
        {
            this.Price = price;
        }

        public override string ToString()
        {
            return base.ToString() + ", Price: " + Price.ToString("C");
        }
    }
}
