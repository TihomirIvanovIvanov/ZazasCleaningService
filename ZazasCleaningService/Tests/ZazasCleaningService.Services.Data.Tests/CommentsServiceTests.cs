﻿namespace ZazasCleaningService.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;
    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Data.Tests.Common;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Comments;

    public class CommentsServiceTests
    {
        private ICommentsService commentsService;

        public CommentsServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task Create_WithCorrectData_ShouldSuccsessfullyCreate()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.commentsService = new CommentsService(dbContext);

            var testCommentService = new CommentsServiceModel
            {
                Content = "comment3",
            };

            var expectedResultId = 3;
            var actualResultId = await this.commentsService.CreateCommentsAsync(testCommentService);

            Assert.Equal(actualResultId, expectedResultId);
        }

        [Fact]
        public async Task GetAll_WithDummyData_ShouldReturnCorrectResult()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.commentsService = new CommentsService(dbContext);

            var expectedResult = dbContext.Comments.To<CommentsServiceModel>().ToList();
            var actualResult = this.commentsService.GetAllCommentsAsync<CommentsServiceModel>().ToList();

            Assert.Equal(expectedResult, actualResult);
        }

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            await dbContext.AddRangeAsync(this.GetDummyData());
            await dbContext.SaveChangesAsync();
        }

        private List<Comment> GetDummyData()
        {
            return new List<Comment>()
            {
                new Comment
                {
                    Content = "comment1",
                },
                new Comment
                {
                    Content = "comment2",
                },
            };
        }
    }
}
