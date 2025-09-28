using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GithubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubApiController(Interfaces.GithubApi api) : ControllerBase
    {
        [HttpGet("pullrequests/{owner}/{repo}")]
        public IActionResult GetPullRequests(string owner, string repo)
        {
            var pullRequests = api.GetPullRequests(owner, repo);
            return Ok(pullRequests);
        }
    }
}
