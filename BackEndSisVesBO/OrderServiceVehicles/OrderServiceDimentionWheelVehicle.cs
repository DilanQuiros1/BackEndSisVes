using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceDimentionWheelVehicle
    {

        private readonly DataContext dataContext;

        public OrderServiceDimentionWheelVehicle(DataContext dataContext)
        {
            this.dataContext = dataContext;
           
        }

        public List<DimentionWheelsRequest>GetDimentionWheel()
        {
            string view = "SELECT * FROM vwSeleccionarDimencionesRuedas";
            List<DimentionWheelsRequest> dimention = new List<DimentionWheelsRequest>();
            DataTable response = dataContext.ExecuteQueryViews(view);
            foreach(DataRow row in response.Rows)
            {
                dimention.Add(new DimentionWheelsRequest
                {
                    RUEDIM_ID = Convert.ToInt32(row["RUEDIM_ID"]),
                    RUE_DIM_DEL = row["RUE_DIM_DEL"].ToString(),
                    RUE_DIM_TRAS = row["RUE_DIM_TRAS"].ToString()
                });
            }
            return dimention;
        }

        public bool InsertDimentionWheel(DimentionWheelsRequest dimention)
        {
            string procedure = "InsertarRuedasDimensiones";
            var parameters = new Dictionary<string, object>()
            {
                {"@RUE_DIM_TRAS",dimention.RUE_DIM_TRAS },
                {"@RUE_DIM_DEL",dimention.RUE_DIM_DEL },
            };

            int result = dataContext.ExecuteNonQuerySPs(procedure, parameters);
            return result > 0;
        }

    }
}
