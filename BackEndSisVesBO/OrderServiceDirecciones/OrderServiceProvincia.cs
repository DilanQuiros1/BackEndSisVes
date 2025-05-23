﻿using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones
{
    public class OrderServiceProvincia
    {

        private readonly DataContext dataContext;

        public OrderServiceProvincia(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<ProvinciaRequest> GetAllProvinces()
        {
            List<ProvinciaRequest> distritoRequests = new List<ProvinciaRequest>();
            string query = "SELECT * FROM vw_SeleccionarProvincia;";
            DataTable distritos = dataContext.ExecuteQueryViews(query);

            foreach (DataRow row in distritos.Rows)
            {
                distritoRequests.Add(new ProvinciaRequest
                {
                    PRO_ID = Convert.ToInt32(row["PRO_ID"]),
                    PRO_Nombre = row["PRO_Nombre"].ToString()

                });
            }

            return distritoRequests;

        }

       

    }
}
