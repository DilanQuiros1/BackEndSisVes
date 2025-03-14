namespace BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades
{
    public class PrestacionesVehiclesRequest
    {
        public int PRES_ID { get; set; }
        public int PRES_Velocidad { get; set; }
        public decimal PRES_Aceleracion { get; set; }
        public int VEH_ID { get; set; }
        public int PRES_Modificado_Por { get; set; }
        public int PRES_Registrado_Por { get; set; }
        public string PRES_Fecha_Registro { get; set; }
        public string PRES_Fecha_Modificado { get; set; }
    }
}
