namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Controllers
{
    public class CodeReviewRoute
    {
        public const string basic = "api";
        public class CodeReview
        {
            public const string GetAllCodeReview = basic + "/CodeReview";
            public const string GetCodeReviewById = basic + "/CodeReview/{id:int:min(1)}";
            public const string CreateCodeReview = basic + "/CodeReview";
            public const string UpdateCodeReview = basic + "/CodeReview/{id:int:min(1)}";
            public const string DeleteCodeReview = basic + "/CodeReview/{id:int:min(1)}";
        }
    }
}
