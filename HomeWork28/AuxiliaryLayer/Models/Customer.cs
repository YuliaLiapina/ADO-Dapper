namespace AuxiliaryLayer.Models
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(string custFN, string custLN, string custId, string orderId, string product, int seg)
        {
            Customer_first_name = custFN;
            Customer_last_name = custLN;
            Customer_id = custId;
            Order_id = orderId;
            Product_name = product;
            segment_id = seg;
        }
        public Customer(string custFN, string custLN, string custId, string orderId, string product)
        {
            Customer_first_name = custFN;
            Customer_last_name = custLN;
            Customer_id = custId;
            Order_id = orderId;
            Product_name = product;
        }
        public string Customer_first_name { get; set; }
        public string Customer_last_name { get; set; }
        public string Customer_id { get; set; }
        public string Order_id { get; set; }
        public string Product_name { get; set; }
        public int segment_id { get; set; }

        public override string ToString()
        {
            return $"Customer: {Customer_id} {Customer_first_name} {Customer_last_name} Order: {Order_id} Product: {Product_name}";
        }
    }
}
