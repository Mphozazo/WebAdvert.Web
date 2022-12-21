using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeWebAdvert.Web.Models.Accounts;

namespace WeWebAdvert.Web.Controllers
{
    public class Accounts : Controller
    {

        readonly SignInManager<CognitoUser> SignInManager;
        readonly UserManager<CognitoUser> UserManager;
        readonly CognitoUserPool UserPool;
        public Accounts(SignInManager<CognitoUser> signInManager , UserManager<CognitoUser> userManager , CognitoUserPool userPool )
        {
            SignInManager = signInManager;
            UserManager = userManager;
            UserPool = userPool;

        }
        public async Task<IActionResult> SignUp()
        {
            var user = new Signup();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Signup model)
        {
            if (ModelState.IsValid)
            {
                var user = UserPool.GetUser(model.Email);

                if (user != null)
                {
                    ModelState.AddModelError("UserExists", "User with email address already exists.");

                    return View(model);
                }
                user.Attributes.Add(CognitoAttribute.Name.ToString(), model.Email);
                var  createdUser  = await UserManager.CreateAsync(user, model.Password);

                if (createdUser.Succeeded)
                {
                    RedirectToAction("Confirm"); 
                }
            }
              

            return View(); 
        }

    }
}
