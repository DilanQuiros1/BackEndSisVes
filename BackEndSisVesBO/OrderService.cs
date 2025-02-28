using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO
{
    public class OrderService
    {

        private readonly DataContext _dbContext;
        public OrderService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ClientesRequest> GetClients()
        {
            List<ClientesRequest> clients = new List<ClientesRequest>();

            string query = "SELECT * FROM vw_ClienteDatos";
            DataTable result = _dbContext.ExecuteQuery(query);

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

    }
}
