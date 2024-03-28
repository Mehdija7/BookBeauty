using BookBeauty.Model.SearchObjects;
using BookBeauty.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using BookBeauty.Model;

namespace BookBeauty.Services
{
    public class BaseService<TModel, TSearch,TDbEntity> : IService<TModel, TSearch> where TSearch : BaseSearchObject where TDbEntity : class where TModel : class

    {
        protected _200101Context Context { get; set; }
        protected IMapper Mapper { get; set; }
        public BaseService(IMapper mapper, _200101Context context ) {
            Mapper = mapper;
            Context = context;
        }

        public virtual async Task <Model.PagedResult<TModel>>GetPaged(TSearch? search=null)
        {
            List<TModel> result = new List<TModel>();

            var query = Context.Set<TDbEntity>().AsQueryable();

            query = AddFilter(search, query);

            int count = query.Count();

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }

            var list = query.ToList();

            result = Mapper.Map(list, result);

            Model.PagedResult<TModel> pagedResult = new Model.PagedResult<TModel>();
            pagedResult.Result = result;
            pagedResult.Count = count;

            return pagedResult;
        }

        public virtual  IQueryable<TDbEntity> AddFilter (TSearch search, IQueryable<TDbEntity> query) {
            return query;
        
        }
        public virtual IQueryable<TDbEntity> AddInclude(IQueryable<TDbEntity> query, TSearch? search = null)
        {
            return query;
        }

        public virtual async Task<TModel> GetById(int id)
        {
            var entity = await Context.Set<TDbEntity>().FindAsync(id);
            if (entity != null)
            {
                return Mapper.Map<TModel>(entity);
            }
            else
            {
                return null;
            }
        }
    }
}
