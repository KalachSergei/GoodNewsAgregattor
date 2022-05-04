using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAggregator.Core.DTOs
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public float Rating { get; set; }
        public Guid SourceId { get; set; }

        //public List<CommentDto> CommentDtos { get; set; }
    }
}
