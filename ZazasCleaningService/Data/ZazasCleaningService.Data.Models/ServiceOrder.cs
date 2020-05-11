namespace ZazasCleaningService.Data.Models
{
    using System;

    public class ServiceOrder : Order
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public int StatusId { get; set; }

        public virtual OrderStatus Status { get; set; }
    }
}
