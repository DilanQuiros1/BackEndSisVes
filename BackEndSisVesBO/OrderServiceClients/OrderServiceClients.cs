using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceClients
{
    public class OrderServiceClients
    {

        private readonly DataContext _dbContext;
        public OrderServiceClients(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ClientesRequest> GetClients()
        {
            List<ClientesRequest> clients = new List<ClientesRequest>();

            string query = "SELECT * FROM vw_ClienteDatos";
            DataTable result = _dbContext.ExecuteQueryViews(query);

            foreach (DataRow row in result.Rows)
            {
                clients.Add(new ClientesRequest
                {
                    CLI_ID = Convert.ToInt32(row["CLI_ID"]),
                    CLI_Nombre = row["CLI_Nombre"].ToString(),
                    CLI_Apellidos = row["CLI_Apellidos"].ToString()
                });
            }

            return clients;
        }

        public bool insertClient(ClientesRequest clients)
        {
            string procedure = "InsertarCliente";
            var parameter = new Dictionary<string, object>()
            {
                {"@CLI_ID", clients.CLI_ID},
                {"@TIPIDE_ID", clients.CLI_ID},
                {"@CLI_Identificacion", clients.CLI_ID},
                {"@CLI_Nombre", clients.CLI_ID},
                {"@CLI_Apellidos", clients.CLI_ID},
            };

            int affectedRows = _dbContext.ExecuteNonQuerySPs(procedure, parameter);
            
            return affectedRows > 0;

        }

    }
}
