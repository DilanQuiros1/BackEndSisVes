using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Newtonsoft.Json;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles
{
    public class OrderServiceVehicle
    {
        private readonly DataContext dataContext;
        public OrderServiceVehicle(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<(VehicleRequest, RodajeVehRequest, TypeRodaje, TypeFuelRequest, BrandVehicleRequest, ModelBrandVehicleRequest,
       EngineVehicleRequest, WeighVehicleRequest)> GetInfoVehicles(string VEH_Numero_Placa)
        {
            var vehicles = new List<(VehicleRequest, RodajeVehRequest, TypeRodaje, TypeFuelRequest, BrandVehicleRequest, ModelBrandVehicleRequest,
            EngineVehicleRequest, WeighVehicleRequest)>();
            string view;
            if (VEH_Numero_Placa == null)
            {
                view = "SELECT * FROM vw_VehicleInfo;";
            }
            else
            {
                view = $"SELECT * FROM vw_VehicleInfo WHERE VEH_Numero_Placa = ${VEH_Numero_Placa};";
            }
            

            try
            {
                DataTable response = dataContext.ExecuteQueryViews(view);

                foreach (DataRow row in response.Rows)
                {
                    var vehicle = new VehicleRequest
                    {
                        VEH_Anio = row["VEH_Anio"] != DBNull.Value ? Convert.ToInt32(row["VEH_Anio"]) : 0,
                        VEH_Img_Miniatura = row["VEH_Img_Miniatura"]?.ToString() ?? "",
                        VEH_Numero_Placa = row["VEH_Numero_Placa"]?.ToString() ?? "",
                        VEH_Numero_VIN = row["VEH_Numero_VIN"]?.ToString() ?? "",
                        VEH_Color = row["VEH_Color"]?.ToString() ?? "",
                        VEH_Observaciones = row["VEH_Observaciones"]?.ToString() ?? "",
                        VEH_Precio_USD = row["VEH_Precio_USD"] != DBNull.Value ? Convert.ToInt32(row["VEH_Precio_USD"]) : 0,
                    };

                    var rodaje = new RodajeVehRequest
                    {
                        ROD_Rodaje = row["ROD_Rodaje"] != DBNull.Value ? Convert.ToInt32(row["ROD_Rodaje"]) : 0
                    };

                    var typeRodaje = new TypeRodaje
                    {
                        ROD_Tipo_Rodaje = row["ROD_Tipo_Rodaje"]?.ToString() ?? ""
                    };

                    var typeFuel = new TypeFuelRequest
                    {
                        TIPCOM_Tipo_Combustible = row["TIPCOM_Tipo_Combustible"]?.ToString() ?? ""
                    };

                    var brand = new BrandVehicleRequest
                    {
                        MAR_Marca = row["MAR_Marca"]?.ToString() ?? ""
                    };

                    var model = new ModelBrandVehicleRequest
                    {
                        MOD_Modelo = row["MOD_Modelo"]?.ToString() ?? ""
                    };

                    var engine = new EngineVehicleRequest
                    {
                        MOT_Cilindros = row["MOT_Cilindros"] != DBNull.Value ? Convert.ToInt32(row["MOT_Cilindros"]) : 0,
                        MOT_Valvulas = row["MOT_Valvulas"] != DBNull.Value ? Convert.ToInt32(row["MOT_Valvulas"]) : 0,
                        MOT_Cilindrada = row["MOT_Cilindrada"] != DBNull.Value ? Convert.ToInt32(row["MOT_Cilindrada"]) : 0,
                        MOT_Carrera_Cilindro = row["MOT_Carrera_Cilindro"] != DBNull.Value ? Convert.ToInt32(row["MOT_Carrera_Cilindro"]) : 0,
                        MOT_Diametro_Cilindro = row["MOT_Diametro_Cilindro"] != DBNull.Value ? Convert.ToInt32(row["MOT_Diametro_Cilindro"]) : 0,
                        MOT_Potencia_Maxima_KW_CV = row["MOT_Potencia_Maxima_KW_CV"] != DBNull.Value ? Convert.ToInt32(row["MOT_Potencia_Maxima_KW_CV"]) : 0,
                        MOT_Par_maximo_Nm_rpm = row["MOT_Par_maximo_Nm_rpm"] != DBNull.Value ? Convert.ToInt32(row["MOT_Par_maximo_Nm_rpm"]) : 0,
                        MOT_Compresion = row["MOT_Compresion"] != DBNull.Value ? Convert.ToInt32(row["MOT_Compresion"]) : 0,
                    };

                    var weigh = new WeighVehicleRequest
                    {
                        PESVES_Peso_Total = row["PESVEH_Peso_Total"] != DBNull.Value ? Convert.ToInt32(row["PESVEH_Peso_Total"]) : 0,
                        PESVES_Total_Admitible = row["PESVEH_Total_Admitible"] != DBNull.Value ? Convert.ToInt32(row["PESVEH_Total_Admitible"]) : 0,
                        PESVES_Admitible_Remolque = row["PESVEH_Admitible_Remolque"] != DBNull.Value ? Convert.ToInt32(row["PESVEH_Admitible_Remolque"]) : 0,
                        PESVES_Admitible_Ejes = row["PESVEH_Admisible_Ejes"] != DBNull.Value ? Convert.ToInt32(row["PESVEH_Admisible_Ejes"]) : 0,
                    };

                    vehicles.Add((vehicle, rodaje, typeRodaje, typeFuel, brand, model, engine, weigh));
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Registra en logs o lanza una excepción
                Console.WriteLine($"Error en GetInfoVehicles: {ex.Message}");
            }

            return vehicles;
        }
        
        
        public List<CatalogoRequest> GetCatalogoVehicles(string VEH_Numero_Placa)
        {
            List<CatalogoRequest> catalogo = new List<CatalogoRequest> ();
            string view;
            if (VEH_Numero_Placa == null)
            {
                view = "SELECT * FROM vw_VehicleCatalogo;";
            }
            else
            {
                view = $"SELECT * FROM vw_VehicleCatalogo WHERE VEH_Numero_Placa = ${VEH_Numero_Placa};";
            }
            

            try
            {
                DataTable response = dataContext.ExecuteQueryViews(view);

                foreach (DataRow row in response.Rows)
                {
                    catalogo.Add(new CatalogoRequest
                    {
                        VEH_ID = Convert.ToInt32(row["VEH_ID"]),
                        VEH_Img_Miniatura = row["VEH_Img_Miniatura"]?.ToString() ?? "",
                        VEH_Numero_Placa = row["VEH_Numero_Placa"]?.ToString() ?? "",
                        VEH_Precio_USD = row["VEH_Precio_USD"] != DBNull.Value ? Convert.ToInt32(row["VEH_Precio_USD"]) : 0,
                        MAR_Marca = row["MAR_Marca"]?.ToString() ?? "",
                        MOD_Modelo = row["MOD_Modelo"]?.ToString() ?? "",
                    });

                    
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Registra en logs o lanza una excepción
                Console.WriteLine($"Error en GetInfoVehicles: {ex.Message}");
            }

            return catalogo;
        }


        public bool InsertVehicle(VehicleRequest vehicle)
        {
            try
            {

                string Images = JsonConvert.SerializeObject(vehicle.ImagenesJSON);
                string procedure = "InsertSisVeS_VEHICULOS";
                var parameter = new Dictionary<string, object>()
                {
                    {"@TIPCOM_ID",vehicle.TIPCOM_ID },
                    {"@MAR_ID",vehicle.MAR_ID },
                    {"@MOT_ID",vehicle.MOT_ID },
                    {"@PESVEH_ID",vehicle.PESVEH_ID },
                    {"@VEH_Anio",vehicle.VEH_Anio },
                    {"@VEH_Img_Miniatura",vehicle.VEH_Img_Miniatura },
                    {"@VEH_Numero_Placa",vehicle.VEH_Numero_Placa },
                    {"@VEH_Numero_VIN",vehicle.VEH_Numero_VIN },
                    {"@VEH_Color",vehicle.VEH_Color },
                    {"@VEH_Observaciones",vehicle.VEH_Observaciones },
                    {"@VEH_Precio_USD",vehicle.VEH_Precio_USD },
                    {"@PRES_Velocidad",vehicle.Prestaciones.PRES_Velocidad },
                    {"@PRES_Aceleracion",vehicle.Prestaciones.PRES_Aceleracion },
                    {"@ROD_Rodaje",vehicle.RodajeVehicle.ROD_Rodaje},
                    {"@ROD_Tipo_ID",vehicle.RodajeVehicle.ROD_Tipo_ID },
                    {"@ImagenesJSON ",Images },

                };
                int response = dataContext.ExecuteNonQuerySPs(procedure, parameter);

                return response > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool UpdateVehicle(UpdateVehicleRequest vehicle)
        {
            try
            {

              
                string procedure = "Actualizar_SisVeS_VEHICULOS";
                var parameter = new Dictionary<string, object>()
                {
                    {"@TIPCOM_ID",vehicle.VEH_ID },
                    {"@TIPCOM_ID",vehicle.TIPCOM_ID ??(object) DBNull.Value },
                    {"@MAR_ID",vehicle.MAR_ID ?? (object)DBNull.Value},
                    {"@MOT_ID",vehicle.MOT_ID ?? (object)DBNull.Value},
                    {"@PESVEH_ID",vehicle.PESVEH_ID ?? (object)DBNull.Value},
                    {"@VEH_Anio",vehicle.VEH_Anio ?? (object)DBNull.Value},
                    {"@VEH_Img_Miniatura",vehicle.VEH_Img_Miniatura ?? (object)DBNull.Value},
                    {"@VEH_Numero_Placa",vehicle.VEH_Numero_Placa ?? (object)DBNull.Value},
                    {"@VEH_Numero_VIN",vehicle.VEH_Numero_VIN ?? (object)DBNull.Value},
                    {"@VEH_Color",vehicle.VEH_Color ?? (object)DBNull.Value},
                    {"@VEH_Observaciones",vehicle.VEH_Observaciones ?? (object)DBNull.Value},
                    {"@VEH_Precio_USD",vehicle.VEH_Precio_USD ?? (object)DBNull.Value}
                };
                int response = dataContext.ExecuteNonQuerySPs(procedure, parameter);

                return response > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeacticateVehicle(string VEH_Numero_Placa)
        {
            try
            {

                
                string procedure = "SP_DesactivarVehiculo";
                var parameter = new Dictionary<string, object>()
                {
                    {"@VEH_Numero_Placa", VEH_Numero_Placa }
                };
                int response = dataContext.ExecuteNonQuerySPs(procedure, parameter);

                return response > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ImagesVehicleRequest> ImagesVehicle(int VEH_ID)
        {
            string view = $"SELECT * FROM vw_SeleccionarImagenesPorVehiculo WHERE VEH_ID = ${VEH_ID}";
            List<ImagesVehicleRequest> images = new List<ImagesVehicleRequest>();
            DataTable response = dataContext.ExecuteQueryViews(view);

            foreach(DataRow row in response.Rows)
            {
                images.Add(new ImagesVehicleRequest {
                    IMA_Imagen = row["IMA_Imagen"].ToString(),
                });
            }
            return images;
        }

        public bool UpdateImagesVehicle(UpdateImagesVehicleRequest image)
        {
            try
            {

                
                string procedure = "Actualizar_SisVeS_IMAGENES";
                var parameter = new Dictionary<string, object>()
                {
                    {"@IMA_ID", image.IMA_ID },
                    {"@VEH_ID", image.VEH_ID },
                    {"@IMA_Imagen", image.IMA_Imagen }
                };
                int response = dataContext.ExecuteNonQuerySPs(procedure, parameter);

                return response > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
