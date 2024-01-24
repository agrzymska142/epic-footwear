using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Interfaces;
using Grzymska.EpicFootwear.WEB.Models;

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
        public ActionResult<IEnumerable<Shoe>> GetAll()
        {
            var shoes = _dataProvider.GetAllShoes(); 
            return Ok(shoes);
        }

        [HttpGet("{id}")]
        public ActionResult<Shoe> GetShoe(int id)
        {
            var shoes = _dataProvider.GetAllShoes();
            var shoe = shoes.FirstOrDefault(s => s.ID == id);

            if (shoe == null)
            {
                return NotFound("Shoe not found");
            }

            return Ok(shoe);
        }

        [HttpGet("new")]
        public ActionResult<Shoe> GetNewShoe()
        {
            var shoe = _dataProvider.NewShoe();

            return Ok(shoe);
        }

        [HttpPost]
        public ActionResult<string> SaveShoe([FromBody] Shoe newShoe)
        {
            _dataProvider.SaveShoe(newShoe);
            return Ok("Shoe saved successfully.");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteShoe(int id)
        {
            var shoes = _dataProvider.GetAllShoes();
            var shoeToDelete = shoes.FirstOrDefault(s => s.ID == id);

            if (shoeToDelete == null)
            {
                return NotFound("Shoe not found");
            }

            _dataProvider.DeleteShoe(shoeToDelete);
            return Ok("Shoe deleted successfully.");
        }
    }
}
