using Microsoft.AspNetCore.Mvc;
using Altimetrik_election__com.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
namespace Altimetrik_election__com.Controllers
{
    public class ElectionUsersController : Controller
    {
        public ElectionUsersData electionUsersData = new ElectionUsersData();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ElectionUsersLogin()
        {
            ViewBag.Status = "";
            return View();
        }
        [HttpPost]
        public ActionResult ElectionUsersLogin(ElectionUsersModel ElectionUsersModels)
        {
            
            string status = electionUsersData.ElectionRegistrationuserLogin(ElectionUsersModels);
            ViewBag.Status = status;
            if (status == "Invalid")
            {
                ViewBag.Status = status;
            }
            else
            {
                
                return RedirectToAction("Index", "MPSeats", new { area = "" });
            }

            return View();
        }
        public ActionResult ElectionUsersCreateUser()
        {
           
            ViewBag.Status = "";
            return View();
        }
        [HttpPost]
        public ActionResult ElectionUsersCreateUser(ElectionUsersModel ElectionUsersModels)
        {
            
            ElectionUsersModels.Status = "I";
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.GenerateKey();
                des.GenerateIV();

                // Encrypt the string
                ElectionUsersModels.Epassword = electionUsersData.EncryptString(ElectionUsersModels.Epassword, des.Key, des.IV);
           

                // Decrypt the string
               // decrypted = DecryptString(encrypted, des.Key, des.IV);
            
            }
            string status= electionUsersData.ElectionRegistrationuser(ElectionUsersModels);

            ViewBag.Status = status;
            return View();
        }
    }
}
