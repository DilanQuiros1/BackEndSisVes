using BackEndSisVes.BackEndSisVesBO.OrderServiceClients;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.ClientsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeIDController : Controller
    {

        private readonly OrderServiceTypeID orderServiceTypeID;

        public TypeIDController(OrderServiceTypeID orderServiceTypeId)
        {
            orderServiceTypeID  = orderServiceTypeId;
        }

        [HttpPost("InsertTypeID")]
        public IActionResult InsertTypeID(TypeIDRequest typeID)
        {
            try
            {
                bool result = orderServiceTypeID.InsertTypeID(typeID);
                if (result)
                {
                    return Ok(new {message = "Type ID inserted successfully"});
                }
                else
                {
                    return BadRequest(new {message = "Failed to insert Type ID"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("GetTypesID")]
        public IActionResult getTypesID()
        {
            try
            {
                List<TypeIDRequest> types = new List<TypeIDRequest>();
                types = orderServiceTypeID.GetTypeID();
                if(types == null || types.Count < 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(types);
                }
               
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message });
            }
        }

    }
}
