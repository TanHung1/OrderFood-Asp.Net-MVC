using Microsoft.AspNetCore.Mvc;
using OrderFood.Models;
using OrderFood.Repository;
namespace OrderFood.Controllers
{

    public class MenuController : Controller
    {
        private IDishRepository _dishRepository;
        private ICategoryRepository _categoryRepository;
        public MenuController(IDishRepository dishRepository, ICategoryRepository categoryRepository)
        {
            _dishRepository = dishRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Dish> dishes = _dishRepository.GetAll();
            return View(dishes);
        }
        //Tìm kiếm món ăn
        public IActionResult Search(string name)
        {
            List<Dish> dishes = _dishRepository.GetDishesByName(name);
            return View("Index", dishes);
        }
        public IActionResult DishDetail(string id)
        {
            return View("DishDetail", _dishRepository.findByDishId(id));
        }
        public IActionResult findDishByCategoryId(int id)
        {
            List<Dish> dishes = _dishRepository.GetAllDishByCategoryID(id);
            return View("Index", dishes);
        }
    }
}
