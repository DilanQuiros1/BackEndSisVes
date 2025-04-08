namespace BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades
{
    public class BrandVehicleRequest
    {
        public int MAR_ID { get; set; }
        public int? MOD_ID { get; set; }
        public string? MAR_Marca { get; set; }
        public char? MAR_Estado { get; set; }

    }

    public class InsertBrandVehicleRequest
    {

        public int? MOD_ID { get; set; }
        public string? MAR_Marca { get; set; }


    }
}
