using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServicePrestacionesVehicle
    {

        private readonly DataContext dataContext;
        public OrderServicePrestacionesVehicle(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        public bool UpdatePrestacionesVehicle(PrestacionesVehiclesRequest prestaciones)
        {
            string sp = "UpdateSisVeS_PRESTACIONES";
            var parameters = new Dictionary<string, object>
            {

                 {"@VEH_ID", prestaciones.VEH_ID},
                 {"@PRES_Velocidad", prestaciones.PRES_Velocidad ?? (object)DBNull.Value},
                 {"@PRES_Aceleracion", prestaciones.PRES_Aceleracion ?? (object)DBNull.Value}
            
            };
            int result = dataContext.ExecuteNonQuerySPs(sp, parameters);
            return result > 0;
        }

    }
}
