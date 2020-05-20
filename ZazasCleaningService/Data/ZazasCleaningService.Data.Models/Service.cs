namespace ZazasCleaningService.Data.Models
{
    using System.Collections.Generic;

    using ZazasCleaningService.Data.Common.Models;

    public class Service : BaseDeletableModel<int>
    {
        public Service()
        {
            this.Votes = new HashSet<Vote>();
        }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
