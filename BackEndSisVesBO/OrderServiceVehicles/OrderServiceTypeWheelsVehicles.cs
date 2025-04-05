using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceTypeWheelsVehicles
    {

        private readonly DataContext dataContext;
        public OrderServiceTypeWheelsVehicles(DataContext dataContext)
        {
            this.dataContext = dataContext;

        }

        public List<TypeWheelsVehicleRequest> GetTypeWheelsVehicle()
        {
            string view = "SELECT * FROM vwSeleccionarTiposRuedas";
            List<TypeWheelsVehicleRequest> dimention = new List<TypeWheelsVehicleRequest>();
            DataTable response = dataContext.ExecuteQueryViews(view);
            foreach (DataRow row in response.Rows)
            {
                dimention.Add(new TypeWheelsVehicleRequest
                {
                    TIPRUE_ID = Convert.ToInt32(row["TIPRUE_ID"]),
                    TIPRUE_Tipo = row["TIPRUE_Tipo"].ToString(),
                });
            }
            return dimention;
        }

        public bool InsertTypeWheelVehicle(TypeWheelsVehicleRequest typesWheels)
        {
            try
            {
                string procedure = "InsertSisVeS_TIPOS_RUEDAS";
                var parameters = new Dictionary<string, object>()
                {
                    {"@TIPRUE_Tipo", typesWheels.TIPRUE_Tipo }
                };

                int result = dataContext.ExecuteNonQuerySPs(procedure, parameters);
                return result>0;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
