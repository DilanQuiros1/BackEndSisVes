namespace BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades
{
    public class VehicleRequest
    {
        public int VEH_ID { get; set;}
        public int TIPCOM_ID { get; set;}
        public int MAR_ID { get; set;}
        public int MOT_ID { get; set;}
        public int PESVEH_ID { get; set;}
        public int? VEH_Anio {  get; set;}
        public string? VEH_Img_Miniatura { get;set;}
        public string? VEH_Numero_Placa { get;set;}
        public string? VEH_Numero_VIN { get;set;}
        public string? VEH_Color { get;set;}
        public string? VEH_Observaciones { get;set;}
        public decimal? VEH_Precio_USD { get;set;}

        public PrestacionesVehiclesRequest? Prestaciones { get; set;}
        public RodajeVehRequest? RodajeVehicle { get; set;}

        public List<ImagesVehicleRequest>? ImagenesJSON { get; set; } = new List<ImagesVehicleRequest>();
    } 
    
    public class CatalogoRequest
    {
        public int VEH_ID { get; set;}

        public string? VEH_Img_Miniatura { get; set; }
        public string? VEH_Numero_Placa { get; set; }

        public decimal? VEH_Precio_USD { get; set; }

        public string MAR_Marca { get; set;}
        public string MOD_Modelo { get; set;}

       

    }
    
    public class UpdateVehicleRequest
    {
        public int VEH_ID { get; set;}
        public int? TIPCOM_ID { get; set;}
        public int? MAR_ID { get; set;}
        public int? MOT_ID { get; set;}
        public int? PESVEH_ID { get; set;}
        public int? VEH_Anio {  get; set;}
        public string? VEH_Img_Miniatura { get;set;}
        public string? VEH_Numero_Placa { get;set;}
        public string? VEH_Numero_VIN { get;set;}
        public string? VEH_Color { get;set;}
        public string? VEH_Observaciones { get;set;}
        public decimal? VEH_Precio_USD { get;set;}

    }

    public class RodajeVehRequest
    {
        public int ROD_Rodaje { get; set; }
        public int? ROD_Tipo_ID { get; set; }
    }

    public class ImagesVehicleRequest
    {
        public string? IMA_Imagen { get; set;}
    }

    public class UpdateImagesVehicleRequest
    {
        public int? IMA_ID { get; set; }
        public int? VEH_ID { get; set; }
        public string? IMA_Imagen { get; set; }
    }

    public class TypeRodaje()
    {
        public int? ROD_Tipo_ID { get; set; }
        public string? ROD_Tipo_Rodaje { get; set; }
    }

}
