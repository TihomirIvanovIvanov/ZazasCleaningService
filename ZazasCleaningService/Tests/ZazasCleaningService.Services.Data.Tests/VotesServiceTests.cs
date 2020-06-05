namespace ZazasCleaningService.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;
    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Data.Tests.Common;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Votes;

    public class VotesServiceTests
    {
        private IVotesService votesService;

        public VotesServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetVotes_WithDummyData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "VotesService GetVotesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.votesService = new VotesService(dbContext);

            var expectedResult = dbContext.Votes.First().ServiceId;
            var actualResult = await this.votesService.GetVotesAsync<VotesServiceModel>(expectedResult);

            Assert.True(expectedResult == actualResult.Id, errorMessagePrefix + " " + "Id is not return properly.");
        }

        [Fact]
        public async Task Create_WithDummyData_ShouldReturnCorrectResult()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.votesService = new VotesService(dbContext);

            var testVotesService = new VotesServiceModel
            {
                Type = VoteType.UpVote,
                ServiceId = 1,
                UserId = Guid.NewGuid().ToString(),
            };

            var expectedResult = 3;
            var actualResult = await this.votesService.CreateVoteAsync(testVotesService);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task Create_WithNoVotes_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.votesService = new VotesService(dbContext);

            var testVotesService = new VotesServiceModel
            {
                Type = VoteType.UpVote,
                ServiceId = 1,
                UserId = Guid.NewGuid().ToString(),
            };

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                  await this.votesService.CreateVoteAsync(testVotesService));
        }

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            await dbContext.AddRangeAsync(this.GetDummyData());
            await dbContext.SaveChangesAsync();
        }

        private List<Vote> GetDummyData()
        {
            return new List<Vote>()
            {
                new Vote
                {
                     Type = VoteType.UpVote,
                     ServiceId = 1,
                     UserId = Guid.NewGuid().ToString(),
                },
                new Vote
                {
                     Type = VoteType.DownVote,
                     ServiceId = 2,
                     UserId = Guid.NewGuid().ToString(),
                },
            };
        }
    }
}
