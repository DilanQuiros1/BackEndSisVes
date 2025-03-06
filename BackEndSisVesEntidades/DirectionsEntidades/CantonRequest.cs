namespace BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades
{
    public class CantonRequest
    {
        public int CAN_ID { get; set; }
        public int PRO_ID { get; set;}

        public string CAN_Canton { get; set;}
        public int CAN_Registrado_Por { get; set;}
        public string CAN_Fecha_Registro { get; set;}
        
        public int CAN_Modificado_Por { get; set; }
        public string CAN_Fecha_Modificado { get; set;}
        
    }
}
