using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceBrandVehicle
    {
        private readonly DataContext _context;
        public OrderServiceBrandVehicle(DataContext context)
        {
            _context = context;
        }

        public List<BrandVehicleRequest> getBrandVehicle()
        {
            string view = "SELECT * FROM vwSeleccionarMarcas";
            List<BrandVehicleRequest> brandVehicle = new List<BrandVehicleRequest>();
            DataTable response = _context.ExecuteQueryViews(view);

            foreach (DataRow row in response.Rows)
            {
                brandVehicle.Add(new BrandVehicleRequest
                    {
                        MAR_ID = Convert.ToInt32(row["MAR_ID"]),
                        MOD_ID = Convert.ToInt32(row["MOD_ID"]),
                        MAR_Marca = row["MAR_Marca"].ToString()
                    }
                );
            }
            return brandVehicle;
        }

        public bool InsertBrandVehicle(BrandVehicleRequest brandVehicle)
        {
            string procedure = "InsertarMarca"; 
            var parameters = new Dictionary<string, object>()
            {
                {"@MOD_ID",brandVehicle.MOD_ID },
                {"@MAR_Marca",brandVehicle.MAR_Marca }
            };

            int result = _context.ExecuteNonQuerySPs(procedure, parameters);
            return result > 0;
        }

        public bool UpdateBrandVehicle(BrandVehicleRequest brandVehicle)
        {
            string procedure = "ActualizarMarca";
            var parameters = new Dictionary<string, object?>
            {
                {"@MAR_ID", brandVehicle.MAR_ID }, 
                {"@MOD_ID", brandVehicle.MOD_ID ?? (object)DBNull.Value },
                {"@MAR_Marca", string.IsNullOrWhiteSpace(brandVehicle.MAR_Marca) ? (object)DBNull.Value : brandVehicle.MAR_Marca },
                {"@MAR_Estado", brandVehicle.MAR_Estado ?? (object)DBNull.Value }
            };

            int result = _context.ExecuteNonQuerySPs(procedure, parameters);
            return result > 0;
        }


    }
}
