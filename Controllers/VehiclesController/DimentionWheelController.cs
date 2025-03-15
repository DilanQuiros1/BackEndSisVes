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

        [HttpPost("InsertDimentionWheel")]
        public IActionResult InsertDimentionWheel(DimentionWheelsRequest dimention)
        {
            try
            {

                bool result = orderServiceDimentionWheelVehicle.InsertDimentionWheel(dimention);
                if(result)
                {
                    return Json(new { message = "Dimention inserted successfully" });
                }else
                {
                    return BadRequest(new { message = "Dimention error Inserted" });
                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
