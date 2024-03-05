using Microsoft.AspNetCore.Mvc;

namespace ServicioHospital.Controllers
{
    public class HospitalController : Controller
    {
        [HttpGet]
        [Route("api/Hospital/GetAll")]
        public IActionResult GetAll()
        {
            Modelo.Hospital hospital = new Modelo.Hospital();
            Modelo.Result result = Negocio.Hospital.GetAll(hospital);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
            //return View();
        }
        [HttpPost]
        [Route("api/Hospital/Delete")]
        public IActionResult Delete([FromBody] int IdHospital)
        {

            Modelo.Result result = Negocio.Hospital.Delete(IdHospital);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
            //return View();
        }
        [HttpPost]
        [Route("api/Hospital/Add")]
        public IActionResult Add([FromBody] Modelo.Hospital hospital)
        {

            Modelo.Result result = Negocio.Hospital.Add(hospital);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
            //return View();
        }
        [HttpGet]
        [Route("api/Hospital/GetById/{IdHospital}")]
        public IActionResult GetById(int IdHospital)
        {

            Modelo.Result result = Negocio.Hospital.GetById(IdHospital);
            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return NotFound(result);
            }
            //return View();
        }
        [HttpPost]
        [Route("api/Hospital/Update/{id}")]
        public IActionResult Update(int id, [FromBody] Modelo.Hospital hospital)
        {
            hospital.IdHospital = id;

            Modelo.Result result = Negocio.Hospital.Update(hospital);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
            //return View();
        }
    }
}
