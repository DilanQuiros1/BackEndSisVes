using BackEndSisVes.BackEndSisVesBO.OrderServiceSales;
using BackEndSisVes.BackEndSisVesEntidades.SalesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.SalesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : Controller
    {
       private readonly OrderServiceSales orderServiceSales;
        public SalesController(OrderServiceSales orderServiceSales)
        {
            this.orderServiceSales = orderServiceSales;
        }

        [HttpPost("InsertSale")]
        public IActionResult InsertSale([FromBody] InsertSaleRequest sale)
        {
            try
            {
                bool response = orderServiceSales.InsertSale(sale);
                if (response)
                {
                    return Json(new {success = true, message="Sale Inserted Successfully"});
                }
                else
                {
                    return BadRequest("Error Inserting Sale, try again");

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSalesWithDetails")]
        public IActionResult GetSalesWithDetails()
        {
            try
            {
                List<SaleRequest> response = orderServiceSales.GetSaleWithDetails("all","");
                if(response == null || response.Count <1)
                {
                    return NotFound("There aren't sales yet");
                }
                else
                {
                    return Ok(response);
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSalesWithDetailsByVENID")]
        public IActionResult GetSalesWithDetailsByVENID(string VEN_ID)
        {
            try
            {
                List<SaleRequest> response = orderServiceSales.GetSaleWithDetails("VEN_ID",VEN_ID);
                if (response == null || response.Count < 1)
                {
                    return NotFound("There isn't a sale with Venta ID: "+VEN_ID);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetSalesWithDetailsByCLIEID")]
        public IActionResult GetSalesWithDetailsByCLIEID(string CLIE_ID)
        {
            try
            {
                List<SaleRequest> response = orderServiceSales.GetSaleWithDetails("CLIE_ID", CLIE_ID);
                if (response == null || response.Count < 1)
                {
                    return NotFound("There isn't a sale with Client ID: " + CLIE_ID);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
