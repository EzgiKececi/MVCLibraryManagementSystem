﻿using Microsoft.AspNetCore.Mvc;

namespace MVCLibraryManagementSystem.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.Mvc;
    using MVCLibraryManagementSystem.ViewModels;
    using System.Security.Claims;
    using MVCLibraryManagementSystem.Models;

    namespace ToDoAppPatika.Controllers
    {
      
        public class AuthController : Controller
        {
            private static List<User> _users = new List<User>()
        {
            new User{ Id = 1, Email="." , Password = "."}
        };

           

            private readonly IDataProtector _dataProtector;
            public AuthController(IDataProtectionProvider dataProtectionProvider)
            {
                _dataProtector = dataProtectionProvider.CreateProtector("security");
            }

            [HttpGet]
            public IActionResult SignUp()
            {
                return View();
            }

            [HttpPost]
            public IActionResult SignUp(SignUpViewModel formData)
            {

                if (!ModelState.IsValid)
                {
                    return View(formData);
                }

                var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());
                if (user is not null)
                {
                    ViewBag.Error = "Kullanıcı mevcut";
                    return View(formData);
                }

                var newUser = new User()
                {
                    Id = _users.Max(x => x.Id) + 1,
                    Email = formData.Email.ToLower(),
                    Password = _dataProtector.Protect(formData.Password)
                };

                _users.Add(newUser);

                return RedirectToAction("Index", "Home");
            }

            [HttpGet]
            public IActionResult SignIn()
            {

                return View();
            }

            [HttpPost]
            public async Task<IActionResult> SignIn(SignInViewModel formData)
            {
                var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());

                if (user is null)
                {
                    ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                    return View(formData);
                }

                var rawPassword = _dataProtector.Unprotect(user.Password);

                if (rawPassword == formData.Password)
                {
                   

                    var claims = new List<Claim>();

                    claims.Add(new Claim("email", user.Email));
                    claims.Add(new Claim("id", user.Id.ToString()));

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    

                    var autProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true, 
                        ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(24)) 
                    };


                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);

                

                }
                else
                {
                    ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                    return View(formData);
                }

                return RedirectToAction("Index", "Home");
            }

            public async Task<IActionResult> SignOut()
            {
                await HttpContext.SignOutAsync();

                return RedirectToAction("Index", "Home");
            }
        }
    }

    
}