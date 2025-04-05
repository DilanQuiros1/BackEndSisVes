namespace BackEndSisVes.BackEndSisVesEntidades.SalesEntidades
{
    public class SaleRequest
    {
        public int VEN_ID { get; set; }
        public int CLI_ID { get; set; }
        public int TIPCODMON_ID { get; set; }
        public int FORPAG_ID { get; set; }
        public decimal VEN_Subtotal { get; set; }
        public decimal VEN_Descuento_Venta { get; set; }
        public decimal VEN_Total_Impuesto { get; set; }
        public decimal VEN_Total_Descuento { get; set; }
        public decimal VEN_SubTotal_Descuento_Aplicado { get; set; }
        public decimal VEN_Total_Inpuesto_Incluido { get; set; }
        public decimal VENVEH_Total_Descuento_Aplicado { get; set; }
        public List<SaleDetailRequest> DetallesVenta { get; set; } = new List<SaleDetailRequest>();

    }

    public class InsertSaleRequest
    {

        public int CLI_ID { get; set; }
        public int TIPCODMON_ID { get; set; }
        public int FORPAG_ID { get; set; }
        public List<InsertSaleDetail> salesDetail { get; set; } = new List<InsertSaleDetail>();
    }

    public class InsertSaleDetail
    {
        public int VEH_ID { get; set; }
        public decimal DETVEN_Descuento_Vehiculo { get; set; }
        public int DETVEN_Descuento_Venta { get; set; }
        public decimal DETVEN_Impuesto { get; set; }
    }
}
