namespace BackEndSisVes.BackEndSisVesEntidades.CreditsEntidades
{
    public class CreditsRequest
    {

        public int CRE_Numero_Credito { get; set; }
        public string CRE_Fecha_Apertura { get; set; }
        public string CRE_Fecha_Vencimiento { get; set; }
        public int CRE_Plazo_Meses { get; set; }
        public decimal CRE_Tasa_Interes { get; set; }
        public decimal CRE_Intereses { get; set; }
        public string CRE_Detalle { get; set; }
        public string TIPCRE_Tipo_Credito { get; set; }
        public int CLI_ID { get; set; }
        public decimal CRE_Monto_Total { get; set; }


    }

    public class InsertCreditsRequest
    {

        public int CRE_ID { get; set; }
        public int? TIPCRE_ID { get; set; }
        public int? CRE_Numero_Credito { get; set; }
        public string? CRE_Fecha_Apertura { get; set; }
        public string? CRE_Fecha_Vencimiento { get; set; }
        public int? CRE_Plazo_Meses { get; set; }
        public decimal? CRE_Tasa_Interes { get; set; }
        public decimal? CRE_Intereses { get; set; }
        public string? CRE_Detalle { get; set; }
        public int? CLIE_ID { get; set; }
        public char? CRE_Estado { get; set; }


    }


}
