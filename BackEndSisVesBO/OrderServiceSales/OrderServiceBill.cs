using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.SalesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceSales
{
    public class OrderServiceBill
    {

        private readonly DataContext _dbContext;
        public OrderServiceBill(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public string getSession()
        {
            string query = "SELECT SESSION_CONTEXT(N'UsuarioID') AS UsuarioEnSesion;";
            string result = _dbContext.GetUserSession(query);
            return result;
        }
        public List<BillRequest> GetAllBills()
        {
            List<BillRequest> bills = new List<BillRequest>();

            string query = "SELECT * FROM vw_FacturasCliente";
            DataTable result = _dbContext.ExecuteQueryViews(query);

            foreach (DataRow row in result.Rows)
            {
                bills.Add(new BillRequest
                {
                    FAC_ID = Convert.ToInt32(row["FAC_ID"]),
                    VEN_ID = Convert.ToInt32(row["VEN_ID"]),
                    CRE_ID = Convert.ToInt32(row["CRE_ID"]),
                    FAC_Fecha_Compra = row["FAC_Fecha_Compra"].ToString()
                });
            }

            return bills;
        }

        public bool InsertBill(BillRequest bill)
        {
            string StoreProcedure = "InsertSisVeS_FACTURACION";

            var parameters = new Dictionary<string, object>
            {
                { "@VEN_ID", bill.VEN_ID },
                { "@CRE_ID", bill.CRE_ID  }
            };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }


        public bool UpdateBill(BillRequest bill)
        {
            string StoreProcedure = "UpdateSisVeS_FACTURACION";
            var parameters = new Dictionary<string, object>
            {
                { "@FAC_ID", bill.FAC_ID },
                { "@VEN_ID", bill.VEN_ID },
                { "@CRE_ID", bill.CRE_ID  }
            };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        }

    }
}
