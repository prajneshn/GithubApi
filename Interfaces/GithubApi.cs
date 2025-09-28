using GithubApi.Models;

namespace GithubApi.Interfaces
{
    public interface GithubApi
    {
        public Task<List<PullRequestDto>> GetPullRequests(string owner, string repo);
    }

}
