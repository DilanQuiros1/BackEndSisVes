using BackEndSisVes.BackEndSisVesBO.OrderServiceSales;
using BackEndSisVes.BackEndSisVesEntidades.SalesEntidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BackEndSisVes.Controllers.SalesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillsController : Controller
    {

        private readonly OrderServiceBill _orderService;

        public BillsController(OrderServiceBill orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet("GetAllBills")]
        public IActionResult GetAllBills()
        {
            try
            {
                var bills = _orderService.GetAllBills();

                if (bills == null || bills.Count == 0)
                {
                    return NotFound("No se encontraron Facturas.");
                }

                return Ok(bills);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("InsertBill")]
        public IActionResult InsertBill([FromBody] InsertBillRequest bill)
        {
            try
            {
                bool result = _orderService.InsertBill(bill);
                if (result)
                {
                    return Ok(new { message = "bill inserted successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Failed to insert bill" });
                }
            }
            catch (SqlException ex) // Catch specific SQL exceptions
            {
                // Log the exception details for debugging
                Console.WriteLine($"SQL Exception in Controller: {ex.Message}");
                return BadRequest(new { message = $"Failed to insert bill: {ex.Message}" }); // Return detailed error message
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                Console.WriteLine($"General Exception in Controller: {ex.Message}");
                return BadRequest(new { message = $"Failed to insert bill: {ex.Message}" }); // Return detailed error message
            }
        }

        [HttpPost("UpdateBill")]
        public IActionResult UpdateBill([FromBody] BillRequest bill)
        {
            try
            {
                bool result = _orderService.UpdateBill(bill);
                if (result)
                {
                    return Ok(new { message = "bill updated successfully" + result });
                }
                else
                {
                    return BadRequest(new { message = "Failed to updated bill: " + result });

                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
