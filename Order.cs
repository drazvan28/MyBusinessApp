namespace MyBusinessApp
{
    public class Order
    {
        private int orderId;
        private int customerId;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public Order(int orderId, int customerId)
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
        }

        public override string ToString()
        {
            return "Order ID: " + OrderId + ", Customer ID: " + CustomerId;
        }
    }
}