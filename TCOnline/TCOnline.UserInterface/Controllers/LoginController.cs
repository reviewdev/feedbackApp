using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using TCOnline.UserInterface.Models;
using TCOnline.UserInterface.HttpHelper;

namespace TCOnline.UserInterface.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(UserViewModel LoginUser)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = new UserViewModel();

                HttpClientHelper httpObj = new HttpClientHelper();
                HttpResponseMessage response = httpObj.GetResponse("api/User/FindUser?username=" + LoginUser.UserName + "&password=" + LoginUser.Password);
                response.EnsureSuccessStatusCode();

                bool findUser = response.Content.ReadAsAsync<bool>().Result;

                if (findUser == true)
                {
                    Session["UserID"] = LoginUser.Id;
                    return RedirectToAction("Index", "Feedback");
                    
                }
                else
                {
                    LoginUser.LoginErrorMessage = "Wrong User Name or Password";
                    return View("LoginPage", LoginUser);
                }
            } // end if
            else
                return View("LoginPage", LoginUser);


        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("LoginPage", "Login");
        }

       
    } //end of class
}