namespace BackEndSisVes.BackEndSisVesEntidades.SalesEntidades
{
    public class SaleDetailRequest
    {

        public int DETVEN_ID { get; set; }
        public int VEH_ID { get; set; }
        public decimal DETVEN_Descuento_Vehiculo { get; set; }
        public int DETVEN_Descuento_Venta { get; set; }
        public decimal DETVEN_Total_Descuento { get; set; }
        public decimal DETVEN_Total_Descuento_Aplicado_Venta { get; set; }
        public decimal DETVEN_Inpuesto { get; set; }
        public decimal DETVEN_Total_Inpuesto_Cobrar { get; set; }
        public decimal DETVEN_Total_Con_Inpuesto { get; set; }
        public decimal DETVEN_Total_Descuento_Vehiculo { get; set; }
        public decimal DETVEN_Descuento_Aplicado_Vehiculo { get; set; }


    }
}
