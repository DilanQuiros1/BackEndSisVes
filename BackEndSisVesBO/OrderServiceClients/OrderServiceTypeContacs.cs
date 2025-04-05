using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceClients
{
    public class OrderServiceTypeContacs
    {

        private readonly DataContext _dbContext;
        public OrderServiceTypeContacs(DataContext _dataContext)
        {
            this._dbContext = _dataContext;
        }
        public string getSession()
        {
            string query = "SELECT SESSION_CONTEXT(N'UsuarioID') AS UsuarioEnSesion;";
            string result = _dbContext.GetUserSession(query);
            return result;
        }
        public List<TypeContactRequest> GetAllTypeContacts()
        {
            List<TypeContactRequest> typecontactos = new List<TypeContactRequest>();

            string query = "SELECT * FROM vw_TipoContacto";
            DataTable result = _dbContext.ExecuteQueryViews(query);

            foreach (DataRow row in result.Rows)
            {
                typecontactos.Add(new TypeContactRequest
                {
                    TIPCON_ID = Convert.ToInt32(row["TIPCON_ID"]),
                    TIPCON_Tipo_Contacto = row["TIPCON_Tipo_Contacto"].ToString()
                });
            }

            return typecontactos;
        }

        public bool InsertTypeContact(TypeContactRequest typecontacto)
        {
            string StoreProcedure = "InsertarTipoContacto";

            var parameters = new Dictionary<string, object>
            {
                { "@TIPCON_Tipo_Contacto", typecontacto.TIPCON_Tipo_Contacto }
            };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

        public bool UpdateTypeContact(TypeContactRequest typecontacto)
        {
            string StoreProcedure = "ActualizarTipoContacto";
            var parameters = new Dictionary<string, object>
            {
                { "@TIPCON_ID", typecontacto.TIPCON_ID },
                { "@TIPCON_Tipo_Contacto", typecontacto.TIPCON_Tipo_Contacto }
             };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

    }
}
