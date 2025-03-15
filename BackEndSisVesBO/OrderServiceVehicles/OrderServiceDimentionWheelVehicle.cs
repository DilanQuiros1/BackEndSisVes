using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceDimentionWheelVehicle
    {

        private readonly DataContext dataContext;

        public OrderServiceDimentionWheelVehicle(DataContext dataContext)
        {
            this.dataContext = dataContext;
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
