namespace BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades
{
    public class DistritoRequest
    {
        public int DIS_ID { get; set; }
        public int CAN_ID { get; set; }
        public string DIS_Distrito { get; set; }
        public int DIS_Registrado_Por { get; set; }
        public string DIS_Fecha_Registro { get; set; }

        public int DIS_Modificado_Por { get; set; }
        public string DIS_Fecha_Modificado { get; set; }
    }

}
