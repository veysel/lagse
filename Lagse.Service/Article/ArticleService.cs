using Lagse.Core.Interfaces.Services;
using Lagse.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lagse.Service.Article
{
    public class ArticleService : IArticleService
    {
        private readonly LagseContext _lagseContext;

        public ArticleService(LagseContext lagseContext)
        {
            _lagseContext = lagseContext;

            // For Article Table Create
            _lagseContext.Database.EnsureCreated();
        }

        public async Task<bool> Add(Model.Entities.Article model)
        {
            model.IsActive = true;
            model.RecordDate = DateTime.Now;

            var response = await _lagseContext.Article.AddAsync(model);
            _lagseContext.SaveChanges();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var responseAny = await _lagseContext.Article.AnyAsync(x => x.Id == id && x.IsActive == true);

            if (responseAny)
            {
                var responseModel = await _lagseContext.Article.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);

                responseModel.IsActive = false;
                _lagseContext.SaveChanges();

                return true;
            }

            return false;
        }

        public async Task<List<Model.Entities.Article>> List()
        {
            return await _lagseContext.Article.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<List<Model.Entities.Article>> Search(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                return await _lagseContext.Article.Where(x => x.IsActive == true && x.ContentText.ToLower().Contains(searchText.ToLower())).ToListAsync();
            }

            return null;
        }

        public async Task<bool> Update(Model.Entities.Article model)
        {
            var responseAny = await _lagseContext.Article.AnyAsync(x => x.Id == model.Id && x.IsActive == true);

            if (responseAny)
            {
                var responseModel = await _lagseContext.Article.FirstOrDefaultAsync(x => x.Id == model.Id && x.IsActive == true);

                responseModel.AuthorName = model.AuthorName;
                responseModel.Category = model.Category;
                responseModel.ContentText = model.ContentText;
                responseModel.Title = model.Title;

                _lagseContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}