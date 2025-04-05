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
               
                {"@PRES_Aceleracion", prestaciones.PRES_Aceleracion},
                {"@PRES_Velocidad", prestaciones.PRES_Velocidad},
                {"@VEH_ID", prestaciones.VEH_ID},

            };
            int result = dataContext.ExecuteNonQuerySPs(sp, parameters);
            return result > 0;
        }

    }
}
