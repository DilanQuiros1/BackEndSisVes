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

        public List<SignalRequest> getAllSignals()
        {
            string view = "SELECT * FROM vw_SeleccionarSenales;";
            List<SignalRequest> signalRequests = new List<SignalRequest>();
            DataTable resut = dataContext.ExecuteQueryViews(view);
            foreach (DataRow row in resut.Rows)
            {
                signalRequests.Add(new SignalRequest
                {
                    SEN_ID = Convert.ToInt32(row["SEN_ID"]),
                    SEN_SENAL = row["SEN_SENAL"].ToString()
                });
            }
            return signalRequests;
        }


        public bool InsertSignalClient(InsertSignalRequest signal)
        {
            string StoreProcedure = "InsertarSenal";

            var parameters = new Dictionary<string, object>
            {
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
