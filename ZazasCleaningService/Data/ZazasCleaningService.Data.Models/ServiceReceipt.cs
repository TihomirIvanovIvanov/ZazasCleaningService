namespace ZazasCleaningService.Data.Models
{
    using System.Collections.Generic;

    public class ServiceReceipt : Receipt
    {
        public ServiceReceipt()
        {
            this.ServiceOrders = new List<ServiceOrder>();
        }

        public virtual List<ServiceOrder> ServiceOrders { get; set; }
    }
}
