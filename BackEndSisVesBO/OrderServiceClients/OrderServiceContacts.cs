using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceClients
{
    public class OrderServiceContacts
    {

        private readonly DataContext _dbContext;
        public OrderServiceContacts(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

       

        public bool InsertContact(ContactsRequest contacto)
        {
            string StoreProcedure = "InsertarContacto";

            var parameters = new Dictionary<string, object>
            {
                { "@CLI_ID", contacto.CLI_ID },
                { "@TIPCON_ID", contacto.TIPCON_ID  },
                { "@CON_Contacto", contacto.CON_Contacto }
            };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

        public bool UpdateContact(ContactsRequest contacto)
        {
            string StoreProcedure = "ActualizarContacto";
            var parameters = new Dictionary<string, object>
            {
                { "@CON_ID", contacto.CON_ID },
                { "@CLI_ID", contacto.CLI_ID },
                { "@TIPCON_ID", contacto.TIPCON_ID  },
                { "@CON_Contacto", contacto.CON_Contacto },
                { "@CON_Estado", contacto.CON_Estado}
             };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }


    }
}
