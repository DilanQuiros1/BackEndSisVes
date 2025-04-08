using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceModelBrandVehicle
    {
        private readonly DataContext dataContext;
        public OrderServiceModelBrandVehicle(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<ModelBrandVehicleRequest> getModelVehicle()
        {
            string view = "SELECT * FROM vwSeleccionarModelos";
            List<ModelBrandVehicleRequest> brandVehicle = new List<ModelBrandVehicleRequest>();
            DataTable response = dataContext.ExecuteQueryViews(view);

            foreach (DataRow row in response.Rows)
            {
                brandVehicle.Add(new ModelBrandVehicleRequest
                {
                    MOD_ID = Convert.ToInt32(row["MOD_ID"]),
                    MOD_Modelo = row["MOD_Modelo"].ToString(),
                }
                );
            }
            return brandVehicle;
        }

        public bool InsertModelVehicle(ModelBrandVehicleRequest modelVehicle)
        {
            string procedure = "InsertarModelo";
            var parameters = new Dictionary<string, object>()
            {
                {"@MOD_ID",modelVehicle.MOD_ID },
                {"@MOD_Modelo",modelVehicle.MOD_Modelo }, 
            };

            int result = dataContext.ExecuteNonQuerySPs(procedure, parameters);
            return result > 0;
        }

        public bool UpdateModelVehicle(ModelBrandVehicleRequest modelVehicle)
        {
            string procedure = "ActualizarModelo";
            var parameters = new Dictionary<string, object>()
            {
                {"@MOD_ID",modelVehicle.MOD_ID },
                {"@MOD_Modelo",modelVehicle.MOD_Modelo },
                {"@MOD_Estado",modelVehicle.MOD_Estado },
            };

            int result = dataContext.ExecuteNonQuerySPs(procedure, parameters);
            return result > 0;
        }


    }
}
