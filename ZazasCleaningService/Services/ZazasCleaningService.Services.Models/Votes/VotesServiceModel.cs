namespace ZazasCleaningService.Services.Models.Votes
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class VotesServiceModel : IMapFrom<Vote>, IMapTo<Vote>
    {
        public int Id { get; set; }

        public bool IsUpVote { get; set; }

        public VoteType Type { get; set; }

        public int ServiceId { get; set; }

        public ServicesServiceModel Services { get; set; }

        public string UserId { get; set; }

        public ApplicationUserServiceModel User { get; set; }
    }
}
