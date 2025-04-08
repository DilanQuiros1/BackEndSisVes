using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.CreditsEntidades;
using System.Data;

namespace BackEndSisVes.BackEndSisVesBO.OrderServiceCredits
{
    public class OrderServiceCredits
    {
        public readonly DataContext dataContext;

        public OrderServiceCredits(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<CreditsRequest> GetAllCredits(string CLI_ID)
        {
            string view;
            List<CreditsRequest> credits = new List<CreditsRequest>();
            if(string.IsNullOrEmpty(CLI_ID))
            {
                view = "SELECT * FROM vw_Creditos;";
            }
            else
            {
                view = $"SELECT * FROM vw_Creditos WHERE CLI_ID = {CLI_ID};";
            }

            DataTable response = dataContext.ExecuteQueryViews(view);
            foreach (DataRow row in response.Rows)
            {
                credits.Add(new CreditsRequest
                {
                    CRE_Numero_Credito = Convert.ToInt32(row["CRE_Numero_Credito"]),
                    CRE_Fecha_Apertura = row["CRE_Fecha_Apertura"].ToString(),
                    CRE_Fecha_Vencimiento = row["CRE_Fecha_Vencimiento"].ToString(),
                    CRE_Plazo_Meses = Convert.ToInt32(row["CRE_Plazo_Meses"]),
                    CRE_Tasa_Interes = Convert.ToDecimal(row["CRE_Tasa_Interes"]),
                    CRE_Intereses = Convert.ToDecimal(row["CRE_Intereses"]),
                    CRE_Detalle = row["CRE_Detalle"].ToString(),
                    TIPCRE_Tipo_Credito = row["TIPCRE_Tipo_Credito"].ToString(),
                    CLI_ID = Convert.ToInt32(row["CLI_ID"]),
                    CRE_Monto_Total = Convert.ToDecimal(row["CRE_Monto_Total"]),
                });
            }
           return credits;
        }
        
        public List<TypeOfCredits> GetTypeOfCredits()
        {
            string view = "SELECT * FROM vw_TipoCredito;";
            List<TypeOfCredits> typeOfCredits = new List<TypeOfCredits>();
           

            DataTable response = dataContext.ExecuteQueryViews(view);
            foreach (DataRow row in response.Rows)
            {
                typeOfCredits.Add(new TypeOfCredits
                {
                   TIPCRE_Tipo_Credito = row["TIPCRE_Tipo_Credito"].ToString(),
                });
            }
           return typeOfCredits;
        }

        public bool InsertCredit(InsertCreditsRequest credit)
        {
            string procedure = "InsertarSisVeS_CREDITO";
            var parameters = new Dictionary<string, object>
            {
                {"@TIPCRE_ID",  credit.TIPCRE_ID},
                {"@CLIE_ID",  credit.CLIE_ID},
                {"@CRE_Detalle",  credit.CRE_Detalle},
                {"@CRE_Numero_Credito",  credit.CRE_Numero_Credito},
                {"@CRE_Fecha_Apertura",  credit.CRE_Fecha_Apertura},
                {"@CRE_Fecha_Vencimiento",  credit.CRE_Fecha_Vencimiento},
                {"@CRE_Plazo_Meses",  credit.CRE_Plazo_Meses},
                {"@CRE_Tasa_Interes",  credit.CRE_Tasa_Interes},
                {"@CRE_Intereses",  credit.CRE_Intereses},
            };
            int response = dataContext.ExecuteNonQuerySPs(procedure, parameters);
            return response > 0;
        }

        public bool UpdateCredit(InsertCreditsRequest credit)
        {
            string procedure = "ActualizarSisVeS_CREDITO";
            var parameters = new Dictionary<string, object>
            {
                {"@CRE_ID",  credit.CRE_ID},
                {"@CRE_ID",  credit.TIPCRE_ID ?? (object)DBNull.Value},
                {"@CLIE_ID",  credit.CLIE_ID ?? (object)DBNull.Value},
                {"@CRE_Detalle",  credit.CRE_Detalle ?? (object)DBNull.Value},
                {"@CRE_Numero_Credito",  credit.CRE_Numero_Credito ?? (object)DBNull.Value},
                {"@CRE_Fecha_Apertura",  credit.CRE_Fecha_Apertura ?? (object)DBNull.Value},
                {"@CRE_Fecha_Vencimiento",  credit.CRE_Fecha_Vencimiento ??(object) DBNull.Value},
                {"@CRE_Plazo_Meses",  credit.CRE_Plazo_Meses ?? (object)DBNull.Value },
                {"@CRE_Tasa_Interes",  credit.CRE_Tasa_Interes ?? (object)DBNull.Value},
                {"@CRE_Intereses",  credit.CRE_Intereses ?? (object)DBNull.Value},
                {"@CRE_Estado",  credit.CRE_Estado ?? (object)DBNull.Value},
            };
            int response = dataContext.ExecuteNonQuerySPs(procedure, parameters);
            return response > 0;
        }

    }
}
