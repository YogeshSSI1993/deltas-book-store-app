using DeltasBookStoreApp.Interfaces;
using DeltasBookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeltasBookStoreApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IBookDetailsRepository _bookDetailsRepository;

        public LoginController(IBookDetailsRepository bookDetailsRepository)
        {
            _bookDetailsRepository = bookDetailsRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserDetails userDetails)
        {
            try
            {
                userDetails.Password = EncodePasswordToBase64(userDetails.Password);
                List<UserDetails> lstUserDetails = _bookDetailsRepository.GetUserDetails(userDetails);
                if (lstUserDetails.Count > 0)
                {
                    TempData["successMessage"] = $"Login Successfull, Welcome {lstUserDetails[0].UserId}";
                    return RedirectToRoute(new { controller = "BookDetails", action = "Index" });
                }
                else
                {
                    TempData["errorMessage"] = "UserId or Password is invalid";
                }
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Logging In, Please try again later.";
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            try
            {
                TempData["successMessage"] = $"Logged Out Successfully";
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Logging Out";
                return View();
            }
            return RedirectToAction("Login");

        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}
