namespace ZazasCleaningService.Data.Models
{
    using System;

    public class ServiceOrder : Order
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }
    }
}
