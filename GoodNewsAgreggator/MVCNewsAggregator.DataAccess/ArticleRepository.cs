using MVCNewsAggregator.Core.Interfaces.Data;
using MVCNewsAgreggator.Data;
using MVCNewsAgreggator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAggregator.DataAccess
{
    public class ArticleRepository : Repository<Article>, IRepository<Article>
    {
        public ArticleRepository(NewsAggregatorContext context) : base(context)
        {
        }
    }
}
