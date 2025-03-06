namespace BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades
{
    public class DirectionsRequest
    {
        public int DIR_ID { get; set; }
        public int SEN_ID { get; set; }
        public int CLI_ID { get; set; }
        public int DIS_ID { get; set; }
        public int DIR_Registrado_Por { get; set; }
        public string DIR_Fecha_Registro { get; set; }

        public int DIR_Modificado_Por { get; set; }
        public string DIR_Fecha_Modificado { get; set; }
    }
}
