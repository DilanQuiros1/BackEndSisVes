namespace BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades
{
    public class WeighVehicleRequest
    {
        public int PESVEH_ID {  get; set; }
        public decimal PESVES_Peso_Total {  get; set; } 
        public decimal PESVES_Total_Admitible {  get; set; } 
        public decimal PESVES_Admitible_Remolque{  get; set; } 
        public decimal PESVES_Admitible_Ejes{  get; set; } 
    }
}
