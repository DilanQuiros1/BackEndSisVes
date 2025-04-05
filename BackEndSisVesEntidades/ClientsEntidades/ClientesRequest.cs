namespace BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades
{
    public class ClientesRequest
    {
        public int CLI_ID { get; set; }
        public int TIPIDE_ID { get; set; }
        public string? CLI_Identificacion { get; set; }
        public string? CLI_Nombre { get; set; }
        public string? CLI_Apellidos { get; set; }

        public List<Contacto> Contactos { get; set; } = new List<Contacto>();  
        public List<Direccion> Direcciones { get; set; } = new List<Direccion>(); 

    }

    public class Contacto
    {
        public int TIPCON_ID { get; set; }
        public string CON_Contacto { get; set; }
    }

    public class Direccion
    {
        public int DIS_ID { get; set; }
        public string SEN_Senal { get; set; }
    }
}
