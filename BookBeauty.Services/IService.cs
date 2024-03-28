using BookBeauty.Model.SearchObjects;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace BookBeauty.Services
{
    public interface IService<TModel,TSearch> where TSearch : BaseSearchObject
    {
        Task<Model.PagedResult<TModel>> GetPaged(TSearch seacrh); 

        Task<TModel>  GetById(int id);
    }
}
