namespace MVCNewsAggregator.Models
{
    public class ArticleDetailsViewModel
    {
        public ArticleDetailsModel ArticleDetailsModel { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
