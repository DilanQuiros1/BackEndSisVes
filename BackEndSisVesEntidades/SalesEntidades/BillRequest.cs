namespace BackEndSisVes.BackEndSisVesEntidades.SalesEntidades
{
    public class BillRequest
    {
        public int FAC_ID { get; set; }
        public int VEN_ID { get; set; }
        public int CRE_ID { get; set; }
        public string FAC_Fecha_Compra { get; set; }

        public int CLI_ID { get; set; }

    }

    public class UpdateBillRequest
    {
        public int FAC_ID { get; set; }
        public int? VEN_ID { get; set; }
        public int? CRE_ID { get; set; }


    }

    public class InsertBillRequest
    {
        public int VEN_ID { get; set; }
        public int CRE_ID { get; set; }


    }
}
