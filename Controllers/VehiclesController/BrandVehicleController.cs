using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandVehicleController : Controller
    {

        private readonly OrderServiceBrandVehicle orderServiceBrand;
        public BrandVehicleController(OrderServiceBrandVehicle orderServiceBrand)
        {
            this.orderServiceBrand = orderServiceBrand;
        }

        [HttpGet("GetBrandVehicles")]
        public IActionResult GetBrandVehicles()
        {
            try
            {
                List<BrandVehicleRequest> result = orderServiceBrand.getBrandVehicle();
                if (result == null || result.Count < 0)
                {
                    return NotFound("There aren't Brand vehicles");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("InsertBrandVehicles")]
        public IActionResult InsertBrandVehicles([FromBody] InsertBrandVehicleRequest brand)
        {
            try
            {
                bool result = orderServiceBrand.InsertBrandVehicle(brand);
                if (result)
                {
                    return Ok(new { message = "Brand vehicle Inserted successfully" });
                }
                else
                {
                    return BadRequest(new { message = "There is an error Inserted Brand vehicle" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("UpdateBrandVehicles")]
        public IActionResult UpdateBrandVehicles([FromBody] BrandVehicleRequest brand)
        {
            try
            {
                bool result = orderServiceBrand.UpdateBrandVehicle(brand);
                if (result)
                {
                    return Ok(new { message = "Brand vehicle Updated successfully" });
                }
                else
                {
                    return BadRequest(new { message = "There is an error Updating Brand vehicle" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
