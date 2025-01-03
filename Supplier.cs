namespace MyBusinessApp
{
    public class Supplier
    {
        private int supplierId;
        private string companyName;

        public int SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public Supplier(int supplierId, string companyName)
        {
            this.SupplierId = supplierId;
            this.CompanyName = companyName;
        }

        public override string ToString()
        {
            return "Supplier ID: " + SupplierId + ", Company Name: " + CompanyName;
        }
    }
}