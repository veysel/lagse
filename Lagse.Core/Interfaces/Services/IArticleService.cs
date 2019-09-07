using Lagse.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lagse.Core.Interfaces.Services
{
    public interface IArticleService
    {
        Task<List<Article>> List();

        Task<List<Article>> Search(string searchText);

        Task<bool> Add(Article model);

        Task<bool> Update(Article model);

        Task<bool> Delete(int id);
    }
}