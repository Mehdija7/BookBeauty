using BookBeauty.Model.SearchObjects;
using BookBeauty.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookBeautyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<TModel, TSearch> : ControllerBase where TSearch : BaseSearchObject
    {
        protected IService<TModel,TSearch> _service;    

        public BaseController(IService<TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] TSearch searchObject) { 
            return Ok(_service.GetPaged(searchObject));
        }

        [HttpGet("[id]")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
    }
}
