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

        public JsonResult Delete (int id)
        {
            ML.Result result = _restauranteBL.DeleteRestaurante(id);
            if(result.Correct){
                return Json(new{succes = true});

            }
            else{
                return Json(new{error = result.ErrorMessage});
            }
        }

         public JsonResult Update([FromBody] ML.Restaurante restaurante)
        {
            if (restaurante == null)
            {
                return Json(new { error = "Datos inválidos." });
            }

            ML.Result result = _restauranteBL.UpdateRestaurante(restaurante);

            if (result.Correct)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { error = result.ErrorMessage });
            }
        }

    }

}
