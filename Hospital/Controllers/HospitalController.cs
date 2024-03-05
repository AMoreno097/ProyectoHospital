using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult Hospital()
        {
            return View();
        }
    }
}
