using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAgreggator.Data.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string SourceUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public float Rating { get; set; }

        public Guid SourceId { get; set; }
        public Source Source { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
