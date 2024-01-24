using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Interfaces;
using Grzymska.EpicFootwear.WEB.Models;

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
        public ActionResult<IEnumerable<Brand>> GetAll()
        {
            var brands = _dataProvider.GetAllBrands();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public ActionResult<Brand> GetBrand(int id)
        {
            var brands = _dataProvider.GetAllBrands();
            var brand = brands.FirstOrDefault(b => b.ID == id);

            if (brand == null)
            {
                return NotFound("Brand not found");
            }

            return Ok(brand);
        }

        [HttpGet("new")]
        public ActionResult<Brand> GetNewBrand()
        {
            var brand = _dataProvider.NewBrand();

            return Ok(brand);
        }

        [HttpPost]
        public ActionResult<string> SaveBrand([FromBody] Brand newBrand)
        {
            _dataProvider.SaveBrand(newBrand);
            return Ok("Brand saved successfully.");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteBrand(int id)
        {
            var brands = _dataProvider.GetAllBrands();
            var brandToDelete = brands.FirstOrDefault(b => b.ID == id);

            if (brandToDelete == null)
            {
                return NotFound("Brand not found");
            }

            _dataProvider.DeleteBrand(brandToDelete);
            return Ok("Brand deleted successfully.");
        }
    }
}
