using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Services;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using UserRegistrarion.Models;

namespace UserRegistrarion.Controllers
{
    public class HomeController : Controller
    {
        UserDeatails userDeatails = new UserDeatails();
        UserService userService = new UserService();
      
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                if(!userService.GetByFilter(registerViewModel.Email))
                {
                    TempData["message"] = "Email Allready Exist Please Try Another one...!!";
                    return View("Index");
                }
                userDeatails.FullName = registerViewModel.FullName;
                userDeatails.Email = registerViewModel.Email;
                userDeatails.Password = registerViewModel.Password;
                userDeatails.Phone = registerViewModel.Password;
                userDeatails.City = registerViewModel.City;
                userDeatails.State = registerViewModel.State;
                userDeatails.Country = registerViewModel.Country;
                userService.GetDetails(userDeatails);
            }


            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(userService.UserExists(model.Email,model.Password))
                {
                    return RedirectToAction("Index", "Booking");
                    
                }
                
            }
            TempData["emessage"] = "User Does Not Exist.....!!";
            return View("Login");


        }

    }
}
