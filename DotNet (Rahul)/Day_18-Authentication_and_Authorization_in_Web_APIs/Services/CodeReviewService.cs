using Day_18_Authentication_and_Authorization_in_Web_APIs.Dtos;
using Day_18_Authentication_and_Authorization_in_Web_APIs.Models;

namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Services
{
    public class CodeReviewService : ICodeReviewService
    {
        private static readonly List<CodeReviewSession> _sessions = new List<CodeReviewSession>()
        {
            new CodeReviewSession { Id = 1, RepositoryName = "Niotechone-Admin-Portal", BranchName = "feature/jwt-auth", QualityScore = 88.5, IssuesCount = 3, ReviewStatus = "Approved" },
            new CodeReviewSession { Id = 2, RepositoryName = "TechFlow-n8n-Automation", BranchName = "bugfix/webhook-timeout", QualityScore = 42.0, IssuesCount = 14, ReviewStatus = "Rejected" },
            new CodeReviewSession { Id = 3, RepositoryName = "InnovateCQRS-Core-API", BranchName = "development", QualityScore = 75.0, IssuesCount = 5, ReviewStatus = "UnderReview" },
            new CodeReviewSession { Id = 4, RepositoryName = "Appliance-Shark-SEO-Worker", BranchName = "main", QualityScore = 98.2, IssuesCount = 0, ReviewStatus = "Pending" }
        };

        public List<CodeReviewSession> GetAllCodeReview()
        {
            return _sessions;
        }

        public CodeReviewSession? GetCodeReviewById(int id)
        {
            var find = _sessions.FirstOrDefault(session => session.Id == id);
            if (find == null)
                return null;
            return find;
        }

        public CodeReviewSession CreateCodeReview(CodeReviewDto codeReviewDto)
        {
            var codeReview = new CodeReviewSession
            {
                RepositoryName = codeReviewDto.RepositoryName,
                BranchName = codeReviewDto.BranchName,
                QualityScore = codeReviewDto.QualityScore,
                IssuesCount = codeReviewDto.IssuesCount,
                ReviewStatus = codeReviewDto.ReviewStatus
            };
            codeReview.Id = _sessions.Max(session => session.Id) + 1;
            _sessions.Add(codeReview);
            return codeReview;
        }

        public CodeReviewSession? UpdateCodeReview(int id, CodeReviewDto codeReviewDto)
        {
            var codeReview = new CodeReviewSession
            {
                RepositoryName = codeReviewDto.RepositoryName,
                BranchName = codeReviewDto.BranchName,
                QualityScore = codeReviewDto.QualityScore,
                IssuesCount = codeReviewDto.IssuesCount,
                ReviewStatus = codeReviewDto.ReviewStatus
            };

            var find = _sessions.FirstOrDefault(session => session.Id == id);
            if (find == null)
                return null;

            find.RepositoryName = codeReviewDto.RepositoryName;
            find.BranchName = codeReviewDto.BranchName;
            find.QualityScore = codeReviewDto.QualityScore;
            find.IssuesCount = codeReviewDto.IssuesCount;
            find.ReviewStatus = codeReviewDto.ReviewStatus;

            return find;
        }

        public bool DeleteCodeReview(int id)
        {
            var session = _sessions.FirstOrDefault(s => s.Id == id);
            if (session == null)
                return false;
            _sessions.Remove(session);
            return true;
        }
    }
}