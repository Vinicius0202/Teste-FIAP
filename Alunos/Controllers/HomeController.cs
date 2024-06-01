using Alunos.API.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Alunos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IRegisterUserService _service;


        public HomeController(ILogger<HomeController> logger, IRegisterUserService service)
        {
            _logger = logger;
            _service = service;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(string nome, string usuario, string senha)
        {
            try
            {
                _service.WriteUsers(senha, nome, usuario);
                return Json(new { success = true, message = "Cadastro com sucesso!" });

            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }

        #region FALATAOU TERMINAR
        //[HttpDelete]
        //public IActionResult DeleterUser(int ID, string nome, string usuario, string senha)
        //{
        //    try
        //    {
        //        _service.WriteUsers(senha, nome, usuario);
        //        return Json(new { success = true, message = "Cadastro com sucesso!" });

        //    }
        //    catch (Exception e)
        //    {
        //        return Json(new { success = false, message = e.Message });
        //    }
        //}

        //public IActionResult EditUser(int id, string nome, string usuario)
        //{
        //    try
        //    {
        //        var data = new StudentsDTO
        //        {
        //            Nome = nome,
        //            Usuario = usuario,
        //            ID = id,
        //        };

        //        return View(data);
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(new { success = false, message = e.Message });
        //    }
        //}

        //public IActionResult EditUsers(int id, string nome, string usuario)
        //{
        //    _service.UpdateUsers(id, nome, usuario);
        //    return View(Privacy());
        //}
        #endregion

        public IActionResult ListarAlunos()
        {
            try
            {
                var data = _service.RedUsers().Result;
                return View(data);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
