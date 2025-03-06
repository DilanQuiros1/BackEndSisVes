using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones
{
    public class OrderServiceSignals
    {

        private readonly DataContext dataContext;

        public OrderServiceSignals(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }



        public bool InsertSignalClient(SignalRequest signal)
        {
            string StoreProcedure = "InsertarSenal";

            var parameters = new Dictionary<string, object>
            {
                { "@SEN_ID", signal.SEN_ID },
                { "@SEN_Senal", signal.SEN_SENAL },
    
            };

            int rowsAffected = dataContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

        public bool updateSignalClient(SignalRequest signal)//REVISAR
        {
            string StoreProcedure = "ActualizarProvincia";

            var parameters = new Dictionary<string, object>
            {
             { "@SEN_ID", signal.SEN_ID },
                { "@SEN_Senal", signal.SEN_SENAL },
            };

            int rowsAffected = dataContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

    }
}
