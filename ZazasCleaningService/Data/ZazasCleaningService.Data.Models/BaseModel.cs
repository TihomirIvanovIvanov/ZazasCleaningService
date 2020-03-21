namespace ZazasCleaningService.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BaseModel<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
