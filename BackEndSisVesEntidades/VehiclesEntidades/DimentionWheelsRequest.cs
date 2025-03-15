namespace BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades
{
    public class DimentionWheelsRequest
    {

        public int RUEDIM_ID {  get; set; }
        public string RUE_DIM_TRAS { get; set; }
        public string RUE_DIM_DEL { get; set; }


        public int RUEDIM_Modificado_Por { get; set; }
        public int RUEDIM_Registrado_Por { get; set; }
        public string RUEDIM_Fecha_Registro { get; set; }
        public string RUEDIM_Fecha_Modificado { get; set; }

    }
}
