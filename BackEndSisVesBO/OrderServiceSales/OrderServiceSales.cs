using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.SalesEntidades;
using Newtonsoft.Json;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceSales
{
    public class OrderServiceSales
    {
        private readonly DataContext dataContext;
        public OrderServiceSales(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<SaleRequest> GetSaleWithDetails(string by, string ID)
        {
            string view="";
            if (by == "all" && ID == null || ID == "")
            {
                view = "SELECT * FROM vw_VentasConDetalles;";
            }
            else if (by == "VEN_ID" && ID != null)
            {
               view = $"SELECT * FROM vw_VentasConDetalles WHERE VEN_ID = {ID};";
            }
            else if (by == "CLIE_ID" && ID != null)
            {
                view = $"SELECT * FROM vw_VentasConDetalles WHERE CLIE_ID = {ID};";
            }

            List<SaleRequest> saleRequests = new List<SaleRequest>();
            DataTable response = dataContext.ExecuteQueryViews(view);

            foreach (DataRow row in response.Rows)
            {
                // Convert JSON string to List<SaleDetailRequest>
                string jsonDetallesVenta = row["DetallesVenta"] != DBNull.Value ? row["DetallesVenta"].ToString() : "[]";
                List<SaleDetailRequest> detallesVenta = JsonConvert.DeserializeObject<List<SaleDetailRequest>>(jsonDetallesVenta);

                saleRequests.Add(new SaleRequest
                {
                    VEN_ID = Convert.ToInt32(row["VEN_ID"]),
                    CLI_ID = Convert.ToInt32(row["CLIE_ID"]),
                    FORPAG_ID = Convert.ToInt32(row["FORPAG_ID"]),
                    TIPCODMON_ID = Convert.ToInt32(row["TIPCODMON_ID"]),
                    VEN_Subtotal = Convert.ToDecimal(row["VEN_Subtotal"]),
                    VEN_Descuento_Venta = Convert.ToDecimal(row["VEN_Descuento_Venta"]),
                    VEN_Total_Impuesto = Convert.ToDecimal(row["VEN_Total_Impuesto"]),
                    VEN_Total_Descuento = Convert.ToDecimal(row["VEN_Total_Descuento"]),
                    VEN_SubTotal_Descuento_Aplicado = Convert.ToDecimal(row["VEN_SubTotal_Descuento_Aplicado"]),
                    VEN_Total_Inpuesto_Incluido = Convert.ToDecimal(row["VEN_Total_Inpuesto_Incluido"]),
                    VENVEH_Total_Descuento_Aplicado = Convert.ToDecimal(row["VENVEH_Total_Descuento_Aplicado"]),
                    DetallesVenta = detallesVenta 
                });
            }

            return saleRequests;
        }


        public bool InsertSale(InsertSaleRequest sale)
        {
            string procedure = "InsertarSisVeS_VENTAS";
            string salesDetail = JsonConvert.SerializeObject(sale.salesDetail);

            var parameters = new Dictionary<string, object>()
            {
                {"@CLIE_ID", sale.CLI_ID},
                {"@FORPAG_ID", sale.FORPAG_ID},
                {"@TIPCODMON_ID", sale.TIPCODMON_ID},
                {"@DETALLEVENTAJSON", salesDetail}
            };
            int response = dataContext.ExecuteNonQuerySPs(procedure, parameters);

            return response >0;
        }

        public List<TypeOfPaymentRequest> GetITypeOfPayments()
        {
            string view = "SELECT * FROM vwSeleccionarFormaPago";
            List<TypeOfPaymentRequest> typeOfPaymentRequests = new List<TypeOfPaymentRequest>();

            DataTable response = dataContext.ExecuteQueryViews(view);
            
            foreach(DataRow row in response.Rows)
            {
                typeOfPaymentRequests.Add(new TypeOfPaymentRequest
                {
                    FORPAG_ID = Convert.ToInt32(row["FORPAG_ID"]),
                    FORPAG_Forma_Pago = row["FORPAG_Forma_Pago"].ToString(),
                });
            }
            return typeOfPaymentRequests;
        }

    }
}
