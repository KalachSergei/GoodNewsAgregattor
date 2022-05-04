using MVCNewsAggregator.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAggregator.Core.Interfaces
{
    public interface IArticleService
    {
        public Task<IEnumerable<ArticleDto>> GetAllNewsAsync();
    }
}
