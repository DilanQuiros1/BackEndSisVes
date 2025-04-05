using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceWheelVehicles
    {
        private readonly DataContext dataContext;
        public OrderServiceWheelVehicles(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<WheelsVehiclesRequest> GetWheelsVehicles()
        {
            List<WheelsVehiclesRequest> wheels = new List<WheelsVehiclesRequest>();

            string view = "SELECT * FROM vwSeleccionarRuedasVehicles";

            DataTable result = dataContext.ExecuteQueryViews(view);
            foreach (DataRow row in result.Rows)
            {
                wheels.Add(new WheelsVehiclesRequest
                {
                    VEH_ID = Convert.ToInt32(row["VEH_ID"]),
                    TIPRUE_ID = Convert.ToInt32(row["TIPRUE_ID"]),
                    MARRUE_ID = Convert.ToInt32(row["MARRUE_ID"]),
                    RUEDIM_ID = Convert.ToInt32(row["RUEDIM_ID"])
                });
            }

            return wheels;

        }

        public bool InsertWheelVehicles(WheelsVehiclesRequest wheels)
        {

            try
            {
                string procedure = "InsertSisVeS_RUEDAS";
                var parameters = new Dictionary<string, object>()
                {
                    {"@VEH_ID", wheels.VEH_ID },
                    {"@TIPRUE_ID", wheels.TIPRUE_ID },
                    {"@MARRUE_ID", wheels.MARRUE_ID },
                    {"@RUEDIM_ID", wheels.RUEDIM_ID }

                };
                int response = dataContext.ExecuteNonQuerySPs(procedure, parameters);
                return response > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
