using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones
{
    public class OrderServiceDirections
    {

        private readonly DataContext dataContext;

        public OrderServiceDirections(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool InsertDirection(DirectionsRequest direction)
        {
            string StoreProcedure = "InsertarDireccion";

            var parameters = new Dictionary<string, object>
            {
                { "@CLI_ID", direction.CLI_ID },
                { "@DIS_ID", direction.DIS_ID },
                { "@SEN_Senal", direction.SEN_Senal },
            };

            int rowsAffected = dataContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

        public bool updateDirection(DirectionsRequest direction)
        {
            string StoreProcedure = "ActualizarDireccion";

            var parameters = new Dictionary<string, object>
            {
                { "@CLI_ID", direction.CLI_ID },
                { "@DIS_ID", direction.DIS_ID },
                { "@SEN_Senal", direction.SEN_Senal },
            };

            int rowsAffected = dataContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

    }
}
