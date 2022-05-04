namespace MVCNewsAggregator.Models
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
