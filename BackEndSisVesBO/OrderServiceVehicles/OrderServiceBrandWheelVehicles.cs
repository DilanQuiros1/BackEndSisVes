using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceBrandWheelVehicles
    {
        public readonly DataContext dataContext;
        public OrderServiceBrandWheelVehicles(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<BrandWheelVehiclesRequest> GetBrandsWheel()
        {
            string view = "SELECT * FROM vw_marcasRuedas";
            List<BrandWheelVehiclesRequest> dimention = new List<BrandWheelVehiclesRequest>();
            DataTable response = dataContext.ExecuteQueryViews(view);
            foreach (DataRow row in response.Rows)
            {
                dimention.Add(new BrandWheelVehiclesRequest
                {
                    MARRUE_ID = Convert.ToInt32(row["MARRUE_ID"]),
                    MARRUE_Marca = row["MARRUE_MARCA"].ToString()
                });
            }
            return dimention;
        }

        public bool InsertBrandWheelVehicle(BrandWheelVehiclesRequest brandWheels)
        {
            try
            {
                string procedure = "InsertSisVeS_MARCAS_RUEDAS";
                var parameters = new Dictionary<string, object>()
                {
                    {"@MARRUE_Marca", brandWheels.MARRUE_Marca}
                };
                int result = dataContext.ExecuteNonQuerySPs(procedure, parameters);
                return result > 0;
            }
            catch(Exception)
            {
                return false;
            }
        }

      

    }

}
