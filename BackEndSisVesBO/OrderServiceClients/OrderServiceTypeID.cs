using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceClients
{
    public class OrderServiceTypeID
    {

        private readonly DataContext dataContext;

        public OrderServiceTypeID(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public bool InsertTypeID(TypeIDRequest typeID)
        {
            string procedure = "InsertarTipoIdentificacion";

            int affectedRows = dataContext.ExecuteNonQuerySPs(procedure);
            return affectedRows > 0;

        }

        public List<TypeIDRequest> GetTypeID()
        {
            string view = "vw_SeleccionarTipoIdentificacion";
            List<TypeIDRequest> typeIDRequests = new List<TypeIDRequest>();

            DataTable types = dataContext.ExecuteQueryViews(view);

            foreach (DataRow row in types.Rows)
            {
                typeIDRequests.Add(new TypeIDRequest
                {
                    TIPIDE_ID = Convert.ToInt32(row["TIPIDE_ID"]),
                    TIPIDE_Tipo_identificacion = row["TIPIDE_Tipo_identificacion"].ToString()

                });
            }
            return typeIDRequests;
        }
        
    }
}
