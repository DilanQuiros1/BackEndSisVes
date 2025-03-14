namespace BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades
{
    public class BrandVehicleRequest
    {
        public int MAR_ID { get; set; }
        public int MOD_ID { get; set; }
        public string MAR_Marca { get; set; }
        public int MAR_Modificado_Por { get; set; }
        public int MAR_Registrado_Por { get; set; }
        public string MAR_Fecha_Registro { get; set; }
        public string MAR_Fecha_Modificado { get; set; }
    }
}
