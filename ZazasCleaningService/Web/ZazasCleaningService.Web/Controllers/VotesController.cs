namespace ZazasCleaningService.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Votes;
    using ZazasCleaningService.Web.ViewModels.Votes;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;

        public VotesController(IVotesService votesService)
        {
            this.votesService = votesService;
        }

        [HttpPost]
        public async Task<ActionResult<VoteResponseViewModel>> Post(VoteInputModel voteInputModel)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var votesServiceModel = AutoMapperConfig.MapperInstance.Map<VotesServiceModel>(voteInputModel);
            votesServiceModel.UserId = userId;
            await this.votesService.CreateVoteAsync<int>(votesServiceModel);

            var votes = await this.votesService.GetVotesAsync<int>(voteInputModel.ServiceId);

            return new VoteResponseViewModel { VotesCount = votes };
        }
    }
}
