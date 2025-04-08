using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Newtonsoft.Json;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceRodajeVehicle
    {
        private readonly DataContext  dataContext;

        public OrderServiceRodajeVehicle(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool UpdateRodajeVehicle(RodVehicleRequest rod)
        {
            try
            {

               
                string procedure = "Actualizar_SisVeS_RODAJE";
                var parameter = new Dictionary<string, object>()
                {
                    
                    {"@ROD_Rodaje", rod.VEH_ID},
                    {"@ROD_Rodaje", rod.ROD_Rodaje},
                    {"@ROD_Tipo_ID",rod.ROD_Tipo_ID},

                };
                int response = dataContext.ExecuteNonQuerySPs(procedure, parameter);

                return response > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
