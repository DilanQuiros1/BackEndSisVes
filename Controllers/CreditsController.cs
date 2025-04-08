using BackEndSisVes.BackEndSisVesBO.OrderServiceCredits;
using BackEndSisVes.BackEndSisVesEntidades.CreditsEntidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BackEndSisVes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditsController : Controller
    {
        private readonly OrderServiceCredits orderServiceCredits;
        public CreditsController(OrderServiceCredits orderServiceCredits)
        {
            this.orderServiceCredits = orderServiceCredits;
        }

        [HttpGet("GetAllCredits")]
        public IActionResult GetAllCredits()
        {
            try
            {
                List<CreditsRequest> credits = orderServiceCredits.GetAllCredits("");
                if(credits == null || credits.Count<1)
                {
                    return NotFound("There aren't credits yet");
                }
                else
                {
                    return Ok(credits);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
        [HttpGet("GetAllCreditsByClient")]
        public IActionResult GetAllCreditsByClient(string CLI_ID)
        {
            try
            {
                if (CLI_ID.IsNullOrEmpty())
                {
                    return BadRequest("You must enter the CLI_ID");
                }
                List<CreditsRequest> credits = orderServiceCredits.GetAllCredits(CLI_ID);
                
                if(credits == null || credits.Count<1)
                {
                    return NotFound("There aren't credits yet");
                }
                else
                {
                    return Ok(credits);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("GetAllTypesOfCredits")]
        public IActionResult GetAllTypesOfCredits()
        {
            try
            {
               
                List<TypeOfCredits> credits = orderServiceCredits.GetTypeOfCredits();
                
                if(credits == null || credits.Count<1)
                {
                    return NotFound("There aren't types of credits yet");
                }
                else
                {
                    return Ok(credits);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertCredit")]
        public IActionResult InsertCredit([FromBody] InsertCreditsRequest credits)
        {
            try
            {

                bool result = orderServiceCredits.InsertCredit(credits);

                if (result)
                {
                    return Ok("inserted successfully");
                  
                }
                else
                {
                    return BadRequest("Error inserting credit");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut("UpdateCredit")]
        public IActionResult UpdateCredit([FromBody] InsertCreditsRequest credits)
        {
            try
            {

                bool result = orderServiceCredits.UpdateCredit(credits);

                if (result)
                {
                    return Ok("Updated successfully");
                  
                }
                else
                {
                    return BadRequest("Error Updating credit");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
