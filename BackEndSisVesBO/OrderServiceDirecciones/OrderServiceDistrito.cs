using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones
{
    public class OrderServiceDistrito
    {
        private readonly DataContext dataContext;

        public OrderServiceDistrito(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<DistritoRequest> GetAllDistritos()
        {
            List<DistritoRequest> distritoRequests = new List<DistritoRequest>();
            string query = "SELECT * FROM vw_SeleccionarDistrito";
            DataTable distritos = dataContext.ExecuteQueryViews(query);

            foreach (DataRow row in distritos.Rows)
            {
                distritoRequests.Add(new DistritoRequest
                {
                    DIS_ID = Convert.ToInt32(row["DIS_ID"]),
                    CAN_ID = Convert.ToInt32(row["CAN_ID"]),
                    DIS_Distrito = row["DIS_Distrito"].ToString(),


                });
            }

            return distritoRequests;

        }

      


    }
}
