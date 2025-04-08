using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceEngineVehicle
    {
        private readonly DataContext dataContext;
        public OrderServiceEngineVehicle(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<EngineVehicleRequest> getEngineVehicle()
        {
            string view = "SELECT * FROM vwSeleccionarMotor";
            List<EngineVehicleRequest> brandVehicle = new List<EngineVehicleRequest>();
            DataTable response = dataContext.ExecuteQueryViews(view);

            foreach (DataRow row in response.Rows)
            {
                    brandVehicle.Add(new EngineVehicleRequest
                    {
                        MOT_ID = Convert.ToInt32(row["MOT_ID"]),
                        MOT_Cilindros = Convert.ToInt32(row["MOT_Cilindros"]),
                        MOT_Valvulas = Convert.ToInt32(row["MOT_Valvulas"]),
                        MOT_Cilindrada = Convert.ToInt32(row["MOT_Cilindrada"]),
                        MOT_Carrera_Cilindro = Convert.ToInt32(row["MOT_Carrera_Cilindro"]),
                        MOT_Diametro_Cilindro = Convert.ToInt32(row["MOT_Diametro_Cilindro"]),
                        MOT_Potencia_Maxima_KW_CV = Convert.ToDecimal(row["MOT_Potencia_Maxima_KW_CV"]),
                        MOT_Par_maximo_Nm_rpm = Convert.ToInt32(row["MOT_Par_maximo_Nm_rpm"]),
                        MOT_Compresion = Convert.ToInt32(row["MOT_Compresion"]),
                  
                    }
                );
            }
            return brandVehicle;
        }

        public bool InsertEngineVehicle(EngineVehicleRequest engine)
        {
            string procedure = "InsertSisVeS_MOTOR";
            var parameters = new Dictionary<string, object>()
            {
                {"@MOT_ID",engine.MOT_ID },
                {"@MOT_Cilindros",  engine.MOT_Cilindros },
                {"@MOT_Valvulas",engine.MOT_Valvulas },
                {"@MOT_Cilindrada",engine.MOT_Cilindrada },
                {"@MOT_Carrera_Cilindro",engine.MOT_Carrera_Cilindro },
                {"@MOT_Diametro_Cilindro",engine.MOT_Diametro_Cilindro },
                {"@MOT_Potencia_Maxima_KW_CV",engine.MOT_Potencia_Maxima_KW_CV },
                {"@MOT_Par_maximo_Nm_rpm",engine.MOT_Par_maximo_Nm_rpm },
                {"@MOT_Compresion",engine.MOT_Compresion }
            };

            int result = dataContext.ExecuteNonQuerySPs(procedure, parameters);
            return result > 0;
        }

        public bool UpdateEngineVehicle(EngineVehicleRequest engine)
        {
            string procedure = "UpdateSisVeS_MOTOR";
            var parameters = new Dictionary<string, object>()
            {
                {"@MOT_ID",engine.MOT_ID },
                {"@MOT_Cilindros",  engine.MOT_Cilindros ?? (object)DBNull.Value },
                {"@MOT_Valvulas",engine.MOT_Valvulas ?? (object)DBNull.Value},
                {"@MOT_Cilindrada",engine.MOT_Cilindrada ?? (object)DBNull.Value},
                {"@MOT_Carrera_Cilindro",engine.MOT_Carrera_Cilindro ?? (object)DBNull.Value},
                {"@MOT_Diametro_Cilindro",engine.MOT_Diametro_Cilindro ?? (object)DBNull.Value},
                {"@MOT_Potencia_Maxima_KW_CV",engine.MOT_Potencia_Maxima_KW_CV ?? (object)DBNull.Value},
                {"@MOT_Par_maximo_Nm_rpm",engine.MOT_Par_maximo_Nm_rpm ?? (object)DBNull.Value},
                {"@MOT_Compresion",engine.MOT_Compresion?? (object)DBNull.Value }
            };

            int result = dataContext.ExecuteNonQuerySPs(procedure, parameters);
            return result > 0;
        }

    }
}
