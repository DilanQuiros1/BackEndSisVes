using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using BackEndSisVes.BackEndSisVesEntidades.LoginEntidades;
using System.Data;


namespace BackEndSisVes.BackEndSisVesBO.OrderServiceLogin
{
    public class OrderServiceLogin
    {
          private readonly DataContext _dataContext;
          public OrderServiceLogin(DataContext dataContext)
          {
            _dataContext = dataContext;
          }

        public LoginRequest Login(LoginRequest user)
        {
            LoginRequest loggedInUser = null;
            
            string query = "SELECT UsuarioID, NombreUsuario FROM Usuarios WHERE UsuarioID = @UsuarioID AND NombreUsuario = @NombreUsuario;";
            var parameters = new Dictionary<string, object>()
            {
                { "@NombreUsuario", user.NombreUsuario },
                { "@UsuarioID", user.UsuarioID }
            };

            DataTable result = _dataContext.GetUserLogin(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                loggedInUser = new LoginRequest
                {
                    UsuarioID = Convert.ToInt32(row["UsuarioID"]),
                    NombreUsuario = row["NombreUsuario"].ToString(),
                };

         
            }

            return loggedInUser;
        }

    

        public bool setUserBD(int userId)
        {
            return _dataContext.SetUserSession(userId);
        }
    }
}
