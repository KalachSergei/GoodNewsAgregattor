using AutoMapper;
using MVCNewsAggregator.Core.DTOs;
using MVCNewsAggregator.Models;
using MVCNewsAgreggator.Data.Entities;

namespace MVCNewsAggregator.Mappers
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleListItemViewModel>();
            CreateMap<Article, ArticleDto>();
        }
    }
}
