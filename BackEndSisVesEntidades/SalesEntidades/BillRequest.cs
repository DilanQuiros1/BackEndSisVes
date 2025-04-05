namespace BackEndSisVes.BackEndSisVesEntidades.SalesEntidades
{
    public class BillRequest
    {
        public int FAC_ID { get; set; }
        public int VEN_ID { get; set; }
        public int CRE_ID { get; set; }
        public string FAC_Fecha_Compra { get; set; }
        public int FAC_Registrado_Por { get; set; }
        public string FAC_Fecha_Registro { get; set; }
        public int FAC_Modificado_Por { get; set; }
        public string FAC_Fecha_Modificado { get; set; }

    }
}
