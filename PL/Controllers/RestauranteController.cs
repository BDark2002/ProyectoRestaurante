using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class RestauranteController : Controller
    {

        private readonly BL.Restaurante _restauranteBL;

        public RestauranteController(DL.Models.RestauranteContext context)
        {
            _restauranteBL = new BL.Restaurante(context);
        }

        public IActionResult GetAll()
        {
            return View();
        }

        public JsonResult GetAllRestaurante()
        {
            ML.Result result = _restauranteBL.GetAllRestaurante();

            if (result.Correct)
            {
                return Json(result.Objects);
            }
            else
            {
                return Json(new { error = "No se pudieron obtener los restaurantes." });
            }
        }
    }
}
