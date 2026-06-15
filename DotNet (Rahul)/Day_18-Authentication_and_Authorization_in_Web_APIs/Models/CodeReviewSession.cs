namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Models
{
    public class CodeReviewSession
    {
        public int Id { get; set; }
        public string RepositoryName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public double QualityScore { get; set; }
        public int IssuesCount { get; set; }
        public string ReviewStatus { get; set; } = "Pending";
    }
}
