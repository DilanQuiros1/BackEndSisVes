namespace BackEndSisVes.BackEndSisVesEntidades.OrderVehicleEntidades
{
    public class OrderVehicleRequest
    {
        public int CLI_ID { get; set; }
        public int VEH_ID { get; set; }
        public string PED_Fecha_Pedido { get; set; }
        public string PED_Fecha_Entrega { get; set; }
        public char PED_Estado { get; set; }
    }

    public class UpdateVehicleRequestorder
    {
        public int PED_ID { get; set; }
        public int? CLI_ID { get; set; }
        public int? VEH_ID { get; set; }
        public string? PED_Fecha_Pedido { get; set; }
        public string? PED_Fecha_Entrega { get; set; }
        public char? PED_Estado { get; set; }
    }

    public class InsertOrderVehicleRequest
    {
        public int? CLI_ID { get; set; }
        public int? VEH_ID { get; set; }
    }


}
