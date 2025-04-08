using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.OrderVehicleEntidades;
using BackEndSisVes.BackEndSisVesEntidades.SalesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceOrderVehicles
{
    public class OrderServiceOrderVehicles
    {
        private readonly DataContext _dbContext;
        public OrderServiceOrderVehicles(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

        public List<OrderVehicleRequest> GetAllOrdersOfVehicle()
        {
            List<OrderVehicleRequest> orders = new List<OrderVehicleRequest>();

            string query = "SELECT * FROM vw_SeleccionarPedidos;";
            DataTable result = _dbContext.ExecuteQueryViews(query);

            foreach (DataRow row in result.Rows)
            {
                orders.Add(new OrderVehicleRequest
                {
                    CLI_ID = Convert.ToInt32(row["CLI_ID"]),
                    VEH_ID = Convert.ToInt32(row["VEH_ID"]),
                    PED_Fecha_Pedido = row["PED_Fecha_Pedido"].ToString(),
                    PED_Fecha_Entrega = row["PED_Fecha_Entrega"].ToString(),

                });
            }

            return orders;
        }

        public bool InsertOrderOfVehicle(InsertOrderVehicleRequest order)
        {
            string StoreProcedure = "InsertarSisVeS_PEDIDOS";

            var parameters = new Dictionary<string, object>
            {
                { "@CLI_ID", order.CLI_ID },
                { "@VEH_ID", order.VEH_ID  }
            };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
        } 
        
       public bool UpdateOrderOfVehicle(UpdateVehicleRequestorder order)
        {
            string StoreProcedure = "Actualizar_SisVeS_PEDIDOS";

            var parameters = new Dictionary<string, object>
            {
                { "@CLI_ID", order.PED_ID },
                { "@CLI_ID", order.CLI_ID ?? (object)DBNull.Value },
                { "@VEH_ID", order.VEH_ID ?? (object)DBNull.Value },
                { "@PED_Estado", order.PED_Estado  ?? (object)DBNull.Value},
                { "@PED_Fecha_Pedido", order.PED_Fecha_Pedido ?? (object)DBNull.Value },
                { "@PED_Fecha_Entrega", order.PED_Fecha_Entrega ?? (object)DBNull.Value }
            };

            int rowsAffected = _dbContext.ExecuteNonQuerySPs(StoreProcedure, parameters);
            return rowsAffected > 0;
       }

    }
}
