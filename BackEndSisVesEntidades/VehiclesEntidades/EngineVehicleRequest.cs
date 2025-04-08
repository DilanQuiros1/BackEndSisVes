namespace BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades
{
    public class EngineVehicleRequest
    {

        public int MOT_ID { get; set; }
        public int? MOT_Cilindros { get; set; }
        public int? MOT_Valvulas { get; set; }
        public int? MOT_Cilindrada { get; set; }
        public int? MOT_Carrera_Cilindro { get; set; }
        public int? MOT_Diametro_Cilindro { get; set; }
        public decimal? MOT_Potencia_Maxima_KW_CV { get; set; }
        public int? MOT_Par_maximo_Nm_rpm { get; set; }
        public int? MOT_Compresion { get; set; }


    }
}
