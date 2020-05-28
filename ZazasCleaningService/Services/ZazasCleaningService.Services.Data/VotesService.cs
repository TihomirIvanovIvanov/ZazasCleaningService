namespace ZazasCleaningService.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Votes;

    public class VotesService : IVotesService
    {
        private readonly ApplicationDbContext dbContext;

        public VotesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateVoteAsync(VotesServiceModel votesServiceModel)
        {
            var vote = await this.GetVoteByServiceAndUserId(votesServiceModel.ServiceId, votesServiceModel.UserId);

            if (vote != null)
            {
                vote.Type = votesServiceModel.IsUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = AutoMapperConfig.MapperInstance.Map<Vote>(votesServiceModel);

                // vote.Type = votesServiceModel.IsUpVote ? VoteType.UpVote : VoteType.DownVote;
                this.dbContext.Votes.Add(vote);
            }

            await this.dbContext.SaveChangesAsync();
            return vote.Id;
        }

        public async Task<int> GetVotesAsync(int serviceId)
        {
            var votesSum = await this.dbContext.Votes
                .Where(vote => vote.ServiceId == serviceId)
                .SumAsync(vote => (int)vote.Type);

            return votesSum;
        }

        private async Task<Vote> GetVoteByServiceAndUserId(int serviceId, string userId)
        {
            var vote = await this.dbContext.Votes
                .FirstOrDefaultAsync(service => service.ServiceId == serviceId && service.UserId == userId);

            if (vote == null)
            {
                throw new ArgumentNullException(nameof(vote));
            }

            return vote;
        }
    }
}
