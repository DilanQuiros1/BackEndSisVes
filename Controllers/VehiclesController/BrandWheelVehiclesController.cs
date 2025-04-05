using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandWheelVehiclesController : Controller
    {
        private readonly OrderServiceBrandWheelVehicles bradnwheels;
        public BrandWheelVehiclesController(OrderServiceBrandWheelVehicles brand)
        {
            bradnwheels = brand;
        }

        [HttpGet("GetWheelsVehicle")]
        public IActionResult GetWheelsVehicle()
        {
            try
            {
                List < BrandWheelVehiclesRequest > response = bradnwheels.GetBrandsWheel();
                if(response != null && response.Count>0)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound("There aren't brands");
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertBrandWheelVehicle")]
        public IActionResult InsertBrandWheelVehicle([FromBody] BrandWheelVehiclesRequest brand)
        {
            try
            {
                bool response = bradnwheels.InsertBrandWheelVehicle( brand);
                if(response)
                {
                    return Json(new { message = "Brand Wheel Inserted Successfully" });
                }
                else
                {
                    return Json(new { message = "Error inserted Brand Wheel" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
