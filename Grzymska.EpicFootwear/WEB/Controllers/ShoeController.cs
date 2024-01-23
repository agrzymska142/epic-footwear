using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/shoes")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private readonly DataProvider _dataProvider;

        public ShoeController(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IShoe>> Get()
        {
            var shoes = _dataProvider.GetAllShoes();
            return Ok(shoes);
        }

        [HttpPost]
        public ActionResult<IShoe> Post([FromBody] IShoe newShoe)
        {
            _dataProvider.SaveShoe(newShoe);
            return Ok(newShoe);
        }
    }
}
