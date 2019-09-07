using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagse.Core.Interfaces.Services;
using Lagse.Model.Entities;
using Lagse.Service.Article;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lagse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Start");
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            List<Article> list = await _articleService.List();
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string text)
        {
            List<Article> list = await _articleService.Search(text);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Article model)
        {
            var response = await _articleService.Add(model);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody]Article model)
        {
            var response = await _articleService.Update(model);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _articleService.Delete(id);
            return Ok(response);
        }
    }
}