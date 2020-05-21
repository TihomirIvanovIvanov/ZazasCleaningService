namespace ZazasCleaningService.Web.ViewModels.Votes
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Votes;

    public class VoteInputModel : IMapTo<VotesServiceModel>
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public bool IsUpVote { get; set; }
    }
}
