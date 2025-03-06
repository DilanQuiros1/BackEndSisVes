namespace BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades
{
    public class ProvinciaRequest
    {
        public int PRO_ID { get; set; }
        public string PRO_Nombre { get; set; }
        public int PRO_Registrado_Por { get; set; }
        public string PRO_Fecha_Registro { get; set; }

        public int PRO_Modificado_Por { get; set; }
        public string PRO_Fecha_Modificado { get; set; }
    }
}
