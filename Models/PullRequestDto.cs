namespace GithubApi.Models;

public record PullRequestDto
{
    public int Number { get; set; }
    public string Title { get; set; } = "";
    public string State { get; set; } = "";
    public DateTime? Closed_At { get; set; }
    public DateTime? Merged_At { get; set; }
}