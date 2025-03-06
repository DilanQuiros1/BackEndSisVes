using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using Microsoft.AspNetCore.Identity.Data;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones
{
    public class OrderServiceCanton
    {
           private readonly DataContext _dbContext;
            public OrderServiceCanton(DataContext dataContext)
            {
                _dbContext = dataContext;
            }

        public string getSession()
        {
            string query = "SELECT SESSION_CONTEXT(N'UsuarioID') AS UsuarioEnSesion;";
            string result = _dbContext.GetUserSession(query);
            return result;
        }

        public List<CantonRequest> GetCantones()
        {
            List<CantonRequest> cantones = new List<CantonRequest>();

            string query = "SELECT * FROM vw_SeleccionarCanton;";
            DataTable result = _dbContext.ExecuteQueryViews(query);

            foreach (DataRow row in result.Rows)
            {
                cantones.Add(new CantonRequest
                {
                    CAN_ID = Convert.ToInt32(row["CAN_ID"]),
                    PRO_ID = Convert.ToInt32(row["PRO_ID"]),
                    CAN_Canton = row["CAN_Canton"].ToString()
                });
            }

            return cantones;
        }

        public bool InsertCanton(CantonRequest canton)
        {
            string StoreProcedure = "InsertarCanton";

            var parameters = new Dictionary<string, object>
            {
                { "@CAN_ID", canton.CAN_ID },
                { "@PRO_ID", canton.PRO_ID },
                { "@CAN_Canton", canton.CAN_Canton }
            };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

        public bool UpdateCanton(CantonRequest canton)
        {
            string StoreProcedure = "ActualizarCanton";
            var parameters = new Dictionary<string, object>
            {
                { "@CAN_ID", canton.CAN_ID },
                { "@PRO_ID", canton.PRO_ID },
                { "@CAN_Canton", canton.CAN_Canton }
             };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

 

    }
}
