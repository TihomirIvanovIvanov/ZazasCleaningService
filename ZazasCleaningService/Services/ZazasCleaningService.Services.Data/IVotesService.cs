﻿namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Votes;

    public interface IVotesService
    {
        Task<int> CreateVoteAsync(VotesServiceModel votesServiceModel);

        Task<T> GetVotesAsync<T>(int serviceId);
    }
}
