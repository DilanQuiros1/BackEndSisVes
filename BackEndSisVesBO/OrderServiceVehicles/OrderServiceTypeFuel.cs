using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceTypeFuel
    {
        private readonly DataContext _dataContext;
        public OrderServiceTypeFuel(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<TypeFuelRequest> getTypesFuel()
        {
            string view = "SELECT * FROM vwSeleccionarTipoCombustible";
            List<TypeFuelRequest> typeFuelRequests = new List<TypeFuelRequest>();
            DataTable response = _dataContext.ExecuteQueryViews(view);

            foreach (DataRow row in response.Rows)
            {
                typeFuelRequests.Add(new TypeFuelRequest    
                    {
                    TIPCOM_ID = Convert.ToInt32(row["TIPCOM_ID"]),
                    TIPCOM_Tipo_Combustible = row["TIPCOM_Tipo_Combustible"].ToString()
                     }
                );
            }
            return typeFuelRequests;
        }

        public bool InsertTypeFuel(TypeFuelRequest typeFuel)
        {
            string procedure = "InsertarTipoCombustible";
            var parameters = new Dictionary<string, object>()
            {
                {"@TIPCOM_ID",typeFuel.TIPCOM_ID },
                {"@TIPCOM_Tipo_Combustible",typeFuel.TIPCOM_Tipo_Combustible }
            };

            int result = _dataContext.ExecuteNonQuerySPs(procedure, parameters);
           return result >0;
        }

        public bool UpdateTypeFuel(TypeFuelRequest typeFuel)
        {
            string procedure = "ActualizarTipoCombustible";
            var parameters = new Dictionary<string, object>()
            {
                {"@TIPCOM_ID",typeFuel.TIPCOM_ID },
                {"@TIPCOM_Tipo_Combustible",typeFuel.TIPCOM_Tipo_Combustible }
            };

            int result = _dataContext.ExecuteNonQuerySPs(procedure, parameters);
            return result > 0;
        }

    }
}
