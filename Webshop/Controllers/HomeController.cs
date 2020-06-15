using Webshop.Models;
using Microsoft.AspNetCore.Mvc;
using WebshopData;
using CommonServices.Authentication;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;

namespace Webshop.Controllers
{
    public class HomeController : Controller
    {        
        private IWebshopItems _context;
        private IAuthenticationService _authenticationService;
        private HomeInformationModel _homeInformationModel;

        public HomeController(IWebshopItems context, IAuthenticationService authenticationService)
        {                       
            _context = context;
            _authenticationService = authenticationService;
            _homeInformationModel = new HomeInformationModel();
        }

        public IActionResult Index()
        {
            return View(_homeInformationModel);
        }

        public IActionResult SubmitForms(string name, string email)
        {
            if (_authenticationService.IsEmailValid(email))
            {
                _authenticationService.SetLoggedUser(new KeyValuePair<string, string>(email, name));
                return RedirectToAction("Index", "ProductList", new { area = "" });
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }

        
    }
}
