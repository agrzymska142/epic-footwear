using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly DataProvider _dataProvider;

        public BrandController(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IBrand>> Get()
        {
            var brands = _dataProvider.GetAllBrands();
            return Ok(brands);
        }

        [HttpPost]
        public ActionResult<IBrand> Post([FromBody] IBrand newBrand)
        {
            _dataProvider.SaveBrand(newBrand);
            return Ok(newBrand);
        }
    }
}
