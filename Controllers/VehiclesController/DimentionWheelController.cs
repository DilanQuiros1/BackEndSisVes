using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class DimentionWheelController : Controller
    {
        private readonly OrderServiceDimentionWheelVehicle orderServiceDimentionWheelVehicle;

        public DimentionWheelController(OrderServiceDimentionWheelVehicle orderServiceDimentionWheelVehicle)
        {
            this.orderServiceDimentionWheelVehicle = orderServiceDimentionWheelVehicle;
        }

        [HttpGet("GetDimentionWheel")]
        public IActionResult GetDimentionWheel()
        {
            try
            {
                List < DimentionWheelsRequest> response= orderServiceDimentionWheelVehicle.GetDimentionWheel();
                if(response.Count > 0 && response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return Json(new { message = "There aren't dimentions" });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertDimentionWheel")]
        public IActionResult InsertDimentionWheel([FromBody] DimentionWheelsRequest dimention)
        {
            try
            {

                bool result = orderServiceDimentionWheelVehicle.InsertDimentionWheel(dimention);
                if(result)
                {
                    return Json(new { message = "Dimention inserted successfully "+result });
                }else
                {
                    return Json(new { message = "Dimention error inserted "+result });
                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpPut("UpdateDimentionWheel")]
        public IActionResult UpdateDimentionWheel([FromBody] DimentionWheelsRequest dimention)
        {
            try
            {

                bool result = orderServiceDimentionWheelVehicle.UodateDimentionWheel(dimention);
                if(result)
                {
                    return Json(new { message = "Dimention inserted successfully "+result });
                }else
                {
                    return Json(new { message = "Dimention error inserted "+result });
                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
