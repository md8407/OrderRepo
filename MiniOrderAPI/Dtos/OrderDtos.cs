namespace MiniOrderAPI.Dtos
{
    public class OrderDtos
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
    }
}
