using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAgreggator.Data.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
