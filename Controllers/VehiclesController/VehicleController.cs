using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly OrderServiceVehicle orderServiceVehicle;

        public VehicleController(OrderServiceVehicle orderServiceVehicle)
        {
            this.orderServiceVehicle = orderServiceVehicle;
        }

        [HttpPost("InsertVehicle")]
        public IActionResult InsertVehicle([FromBody] VehicleRequest vehicle)
        {
            try
            {
                bool response = orderServiceVehicle.InsertVehicle(vehicle);
                if(response)
                {
                    return Json(new {message = "Vehicle Inserted Successfully"});
                }
                else
                {
                    return BadRequest("Error inserting Vehicle");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetImagesVehicle")]
        public IActionResult GetImagesVehicle(int VEH_ID)
        {
            try
            {
                List<ImagesVehicleRequest> response = orderServiceVehicle.ImagesVehicle(VEH_ID);
                if (response.Count > 0 && response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Error get images of Vehicle");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetVehicles")]
        public IActionResult GetVehicles()
        {
            try
            {
                var vehicles = orderServiceVehicle.GetInfoVehicles("");

                if (vehicles == null || !vehicles.Any())
                {
                    return NotFound("No se encontraron vehículos.");
                }

                var response = vehicles.Select(v => new
                {
                    v.Item1.VEH_Anio,
                    v.Item1.VEH_Img_Miniatura,
                    v.Item1.VEH_Numero_Placa,
                    v.Item1.VEH_Numero_VIN,
                    v.Item1.VEH_Color,
                    v.Item1.VEH_Observaciones,
                    v.Item1.VEH_Precio_USD,
                    v.Item2.ROD_Rodaje,
                    v.Item3.ROD_Tipo_Rodaje,
                    v.Item4.TIPCOM_Tipo_Combustible,
                    v.Item5.MAR_Marca,
                    v.Item6.MOD_Modelo,
                    v.Item7.MOT_Cilindros,
                    v.Item7.MOT_Valvulas,
                    v.Item7.MOT_Cilindrada,
                    v.Item7.MOT_Carrera_Cilindro,
                    v.Item7.MOT_Diametro_Cilindro,
                    v.Item7.MOT_Potencia_Maxima_KW_CV,
                    v.Item7.MOT_Par_maximo_Nm_rpm,
                    v.Item7.MOT_Compresion,
                    v.Item8.PESVES_Peso_Total,
                    v.Item8.PESVES_Total_Admitible,
                    v.Item8.PESVES_Admitible_Remolque,
                    v.Item8.PESVES_Admitible_Ejes
                }).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetVehiclesByID")]
        public IActionResult GetVehiclesByID(string VEH_Numero_Placa)
        {
            try
            {
                var vehicles = orderServiceVehicle.GetInfoVehicles(VEH_Numero_Placa);

                if (vehicles == null || !vehicles.Any())
                {
                    return NotFound("No se encontraron vehículos.");
                }

                var response = vehicles.Select(v => new
                {
                    v.Item1.VEH_Anio,
                    v.Item1.VEH_Img_Miniatura,
                    v.Item1.VEH_Numero_Placa,
                    v.Item1.VEH_Numero_VIN,
                    v.Item1.VEH_Color,
                    v.Item1.VEH_Observaciones,
                    v.Item1.VEH_Precio_USD,
                    v.Item2.ROD_Rodaje,
                    v.Item3.ROD_Tipo_Rodaje,
                    v.Item4.TIPCOM_Tipo_Combustible,
                    v.Item5.MAR_Marca,
                    v.Item6.MOD_Modelo,
                    v.Item7.MOT_Cilindros,
                    v.Item7.MOT_Valvulas,
                    v.Item7.MOT_Cilindrada,
                    v.Item7.MOT_Carrera_Cilindro,
                    v.Item7.MOT_Diametro_Cilindro,
                    v.Item7.MOT_Potencia_Maxima_KW_CV,
                    v.Item7.MOT_Par_maximo_Nm_rpm,
                    v.Item7.MOT_Compresion,
                    v.Item8.PESVES_Peso_Total,
                    v.Item8.PESVES_Total_Admitible,
                    v.Item8.PESVES_Admitible_Remolque,
                    v.Item8.PESVES_Admitible_Ejes
                }).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


    }
}
