using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceWeighsVehicle
    {

        private readonly DataContext dataContext;
        public OrderServiceWeighsVehicle(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<WeighVehicleRequest> GetWheighsVehicle()
        {
            string view = "SELECT * FROM Wheihs";
            List<WeighVehicleRequest> weighVehicleRequests = new List<WeighVehicleRequest>();
            DataTable response = dataContext.ExecuteQueryViews(view);

            foreach (DataRow row in response.Rows)
            {
                weighVehicleRequests.Add(new WeighVehicleRequest()
                {
                    PESVEH_ID = Convert.ToInt32(row["PESVEH_ID"]),
                    PESVES_Peso_Total = Convert.ToDecimal(row["PESVES_Peso_Total"]),
                    PESVES_Admitible_Ejes = Convert.ToDecimal(row["PESVES_Admitible_Ejes"]),
                    PESVES_Admitible_Remolque = Convert.ToDecimal(row["PESVES_Admitible_Remolque"]),
                });
            }
            return weighVehicleRequests;
        }

    }
}
