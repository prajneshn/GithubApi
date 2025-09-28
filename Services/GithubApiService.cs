using GithubApi.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GithubApi.Services
{
    public class GithubApiService(HttpClient httpClient) : Interfaces.GithubApi
    {
        public async Task<List<PullRequestDto>> GetPullRequests(string owner, string repo)
        {
            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("MyApp", "1.0")); // Required by GitHub
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("token", "");

            var url = $"https://api.github.com/repos/{owner}/{repo}/pulls?state=closed";

            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var prs = JsonSerializer.Deserialize<List<PullRequestDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return prs ?? new List<PullRequestDto>();
        }
    }
}
