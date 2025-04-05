using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using Newtonsoft.Json;
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

        public List<(ClientesRequest, TypeIDRequest)> GetClients(string? CLI_Identificacion)
        {
            var clients = new List<(ClientesRequest, TypeIDRequest)>();
            string query;
            if (CLI_Identificacion == null || CLI_Identificacion == "")
                query = "SELECT * FROM vw_ClienteDatos";
            else
                query = $"SELECT * FROM vw_ClienteDatos WHERE CLI_Identificacion = ${CLI_Identificacion}";
            DataTable result = _dbContext.ExecuteQueryViews(query);

            foreach (DataRow row in result.Rows)
            {
                var client = new ClientesRequest
                {
                    CLI_Identificacion = row["CLI_Identificacion"].ToString(),
                    CLI_Nombre = row["CLI_Nombre"].ToString(),
                    CLI_Apellidos = row["CLI_Apellidos"].ToString()
                };
                var typeID = new TypeIDRequest
                {
                    TIPIDE_Tipo_identificacion = row["TIPIDE_Tipo_identificacion"].ToString(),
                };
                clients.Add((client, typeID));
            }

            return clients;
        } 
        
        public List<(DistritoRequest, CantonRequest, ProvinciaRequest)> GetDirectionClient(int CLI_ID)
        {
            var directions = new List<(DistritoRequest, CantonRequest, ProvinciaRequest)>();

            string query = $"SELECT * FROM vw_DireccionesClientes WHERE CLI_Identificacion = ${CLI_ID};";
            DataTable result = _dbContext.ExecuteQueryViews(query);

            foreach (DataRow row in result.Rows)
            {
                var distrito = new DistritoRequest
                {
                    DIS_Distrito = row["DIS_Distrito"].ToString(),
                };
                var canton = new CantonRequest
                {
                    CAN_Canton = row["CAN_Canton"].ToString(),
                };

                var province = new ProvinciaRequest
                {
                    PRO_Nombre = row["PRO_Nombre"].ToString(),
                };
                directions.Add((distrito, canton, province));
            }

            return directions;
        }

        public List<(Contacto, TypeContactRequest)> GetContactsClient(int CLI_Identificacion)
        {
            var contacts = new List<(Contacto, TypeContactRequest)>();

            string query = $"SELECT * FROM vw_ContactosCliente WHERE CLI_Identificacion = {CLI_Identificacion};";
            DataTable result = _dbContext.ExecuteQueryViews(query);

            foreach (DataRow row in result.Rows)
            {
                var contacto = new Contacto
                {
                    CON_Contacto = row["CON_Contacto"].ToString(),
                };

                var tipoContacto = new TypeContactRequest
                {
                    TIPCON_Tipo_Contacto = row["TIPCON_Tipo_Contacto"].ToString()
                };

                contacts.Add((contacto, tipoContacto));
            }

            return contacts;
        }


        public bool insertClient(ClientesRequest clients)
        {
            string procedure = "InsertarClienteConContactosYDirecciones";

            // Convert Contactos and Direcciones lists to JSON strings
            string contactosJson = JsonConvert.SerializeObject(clients.Contactos);
            string direccionesJson = JsonConvert.SerializeObject(clients.Direcciones);

            var parameter = new Dictionary<string, object>()
            {
                {"@CLI_ID", clients.CLI_ID},
                {"@TIPIDE_ID", clients.TIPIDE_ID},
                {"@CLI_Identificacion", clients.CLI_Identificacion},
                {"@CLI_Nombre", clients.CLI_Nombre},
                {"@CLI_Apellidos", clients.CLI_Apellidos},
                 {"@Contactos", contactosJson},   
                {"@Direcciones", direccionesJson} 
            };

            int affectedRows = _dbContext.ExecuteNonQuerySPs(procedure, parameter);
            
            return affectedRows > 0;

        }


    }
}
