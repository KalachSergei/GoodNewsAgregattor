namespace MVCNewsAggregator.Models
{
    public class ArticleDetailsModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public string SourceName { get; set; }
    }
}
