using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVCNewsAggregator.Core.DTOs;
using MVCNewsAggregator.Core.Interfaces;
using MVCNewsAggregator.Core.Interfaces.Data;
using MVCNewsAggregator.Models;
using MVCNewsAgreggator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAggregator.Domain.Services
{
    public class ArticleService : IArticleService
    {
        private readonly NewsAggregatorContext _db;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(NewsAggregatorContext db, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _db = db;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ArticleDto>> GetAllNewsAsync()
        {
            return await _unitOfWork.Articles.Get()
                                       .Select(article => _mapper.Map<ArticleDto>(article))
                                       .ToArrayAsync();
        }
    }
}
