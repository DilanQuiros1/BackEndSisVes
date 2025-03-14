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

        public List<PrestacionesVehiclesRequest> GetPrestacionesVehicles()
        {
            List<PrestacionesVehiclesRequest> prestaciones = new List<PrestacionesVehiclesRequest>();

            string view = "vw_VehicleInfoPrestaciones";

            DataTable result = dataContext.ExecuteQueryViews(view);
            foreach(DataRow row in result.Rows)
            {
                prestaciones.Add(new PrestacionesVehiclesRequest
                {
                    PRES_ID = Convert.ToInt32(row["ID"]),
                    PRES_Aceleracion = Convert.ToInt32(row[""]),
                    PRES_Velocidad = Convert.ToInt32(row[""]),
                    VEH_ID = Convert.ToInt32(row[""])
                });
            }

            return prestaciones;

        }

        public bool InsertPrestacionesVehicle(PrestacionesVehiclesRequest prestaciones)
        {
            string sp = "InsertSisVeS_PRESTACIONES";
            var parameters = new Dictionary<string, object>
            {
                {"@PRES_ID", prestaciones.PRES_ID},
                {"@PRES_Aceleracion", prestaciones.PRES_Aceleracion},
                {"@PRES_Velocidad", prestaciones.PRES_Velocidad},
                {"@VEH_ID", prestaciones.VEH_ID},

            };
            int result = dataContext.ExecuteNonQuerySPs(sp, parameters);
            return result > 0;
        }

        public bool UpdatePrestacionesVehicle(PrestacionesVehiclesRequest prestaciones)
        {
            string sp = "UpdateSisVeS_PRESTACIONES";
            var parameters = new Dictionary<string, object>
            {
                {"@PRES_ID", prestaciones.PRES_ID},
                {"@PRES_Aceleracion", prestaciones.PRES_Aceleracion},
                {"@PRES_Velocidad", prestaciones.PRES_Velocidad},
                {"@VEH_ID", prestaciones.VEH_ID},

            };
            int result = dataContext.ExecuteNonQuerySPs(sp, parameters);
            return result > 0;
        }

    }
}
