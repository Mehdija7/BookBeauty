using BookBeauty.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBeauty.Services
{
    public interface ICRUDService<T,TSearch,TInsert,TUpdate>:IService<T,TSearch> where TSearch : BaseSearchObject
    {
        Task<T> Insert(TInsert insert);
        Task<T> Update(int id, TUpdate update);
    }
}
