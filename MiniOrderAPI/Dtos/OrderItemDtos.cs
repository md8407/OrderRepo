namespace MiniOrderAPI.Dtos
{
    public class OrderItemDtos
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Int64 Quantity { get; set; }
        public Int64 Price { get; set; }
        public Int64 OrderId { get; set; }
    }
}
