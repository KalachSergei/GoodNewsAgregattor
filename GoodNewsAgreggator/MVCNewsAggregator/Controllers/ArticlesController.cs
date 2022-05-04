using MVCNewsAgreggator.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCNewsAggregator.Models;
using AutoMapper;
using MVCNewsAggregator.Core.Interfaces;

namespace MVCNewsAggregator
{
    public class ArticlesController : Controller
    {
        
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;

        public ArticlesController(IMapper mapper, IArticleService articleService)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var articles = (await _articleService.GetAllNewsAsync())
                .OrderByDescending(a => a.CreationDate)
                .Select(a => _mapper.Map<ArticleListItemViewModel>(a))
                .ToList();

            return View(articles);
        }



    }
}
