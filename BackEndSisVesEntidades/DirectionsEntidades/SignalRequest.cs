namespace BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades
{
    public class SignalRequest
    {
        public int SEN_ID { get; set; }
        public string SEN_SENAL { get; set; }

        public int SEN_Registrado_Por { get; set; }
        public string SEN_Fecha_Registro { get; set; }

        public int SEN_Modificado_Por { get; set; }
        public string SEN_Fecha_Modificado { get; set; }
    }
}
