namespace ZazasCleaningService.Data.Models
{
    public class ServiceOrder : Order
    {
        public int ServiceId { get; set; }

        public Service Service { get; set; }
    }
}
