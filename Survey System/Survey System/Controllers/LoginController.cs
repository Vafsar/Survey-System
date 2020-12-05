using Survey_System.Models;
using System.Linq;
using System.Web.Mvc;

namespace Survey_System.Controllers
{
    public class LoginController : Controller
    {
        SurveyEntities db = new SurveyEntities();
        public ActionResult SignIn(string Code, string Password)
        {
            if (Code == null)
            {
                return View();
            }
            else
            {
                var person = db.Person.FirstOrDefault(m => m.Code == Code && m.Password == Password);
                if (person != null)
                {
                    Session["Code"] = person.Code;
                    Session["NameSurname"] = person.NameSurname;
                    return RedirectToAction("Index", "Person");
                }
                else
                {
                    ViewBag.Error = "Kod veya Şifre Hatalı.";
                    return View();
                }
            }

        }
    }
}