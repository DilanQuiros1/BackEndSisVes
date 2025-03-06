
using BackEndSisVes.BackEndSisVesBO.OrderServiceLogin;
using BackEndSisVes.BackEndSisVesEntidades.LoginEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.LoginController
{
    public class LoginController : Controller
    {
        private OrderServiceLogin _orderServiceLogin;
        public LoginController(OrderServiceLogin orderServiceLogin)
        {
            _orderServiceLogin = orderServiceLogin;
        }
        public IActionResult LoginPage()
        {
            return View();
        }


        [HttpPost]
        public IActionResult LogIn([FromBody] LoginRequest user)
        {
           
            try
            {

               
                // Call the Login method in the OrderServiceLogin class to verify the user
                LoginRequest verifyUser = _orderServiceLogin.Login(user);

                // If a valid user is returned (i.e., login successful)
                if (verifyUser != null)
                {

                    bool setSession = _orderServiceLogin.setUserBD(user.UsuarioID);
                    if(setSession)
                    {
                        return Json(new { success = true, message = "Todo bien aqui" });
                    }
                    else
                    {
                        return Json(new { success = true, message = "Inicio pero no agrego usuario" });
                    }
                   
                }
                else
                {
                    return Json(new { success = false, message = "Credenciales Invalidas" });
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the login process
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

       



    }
}
