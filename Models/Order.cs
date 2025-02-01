namespace QuartzExample.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public  DateTime CreatedDate { get; set; }= DateTime.Now;
        public DateTime DargoDeliveryDate => CreatedDate.AddDays(2);
        public string? Status { get; set; }
    }
}
