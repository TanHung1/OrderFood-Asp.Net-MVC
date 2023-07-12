using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderFood.Models;
using OrderFood.Repository;
namespace OrderFood.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodController : Controller
    {
        private IDishRepository _dishRepository;
        private ICategoryRepository _categoryRepository;
        public FoodController(IDishRepository dishRepository, ICategoryRepository categoryRepository)
        {
            _dishRepository = dishRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var q1 = from c in _categoryRepository.GetAll()
                     select new SelectListItem()
                     {
                         Text = c.NameCategory,
                         Value = c.CategoryId.ToString(),
                     };
            ViewBag.CategoryId = q1.ToList();
            
            List<Dish> dishes = _dishRepository.GetAll();
            return View(dishes);
        }
        //Tạo
        [HttpPost]
      
        public IActionResult saveFood(Dish dish)
        {
            if (ModelState.IsValid)
            {
                _dishRepository.Create(dish);
                return RedirectToAction("Index");
            }
            ModelState.Remove("Image");
            var categories = _categoryRepository.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.NameCategory,
                    Value = c.CategoryId.ToString()
                })
                .ToList();
            ViewBag.CategoryId = categories;
           
            return View("Index",dish);
         
        }
        public IActionResult CreateFood()
        {
            var categories= _categoryRepository.GetAll()
                     .Select (c=> new SelectListItem()
                     {
                         Text = c.NameCategory,
                         Value = c.CategoryId.ToString()
                     })
                .ToList();
            ViewBag.CategoryId = categories;
            return View("CreateFood", new Dish());
        }
        //Xóa
        public IActionResult DeleteDish(string id)
        {
            _dishRepository.Delete(id);
            return RedirectToAction("Index");
        }
        //Chỉnh sửa
        [HttpPost]
        public IActionResult UpdateFood(Dish dish, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                // Lưu hình ảnh mới vào thư mục và cập nhật thuộc tính Image của đối tượng Dish
                var imagePath = Path.Combine("wwwroot/images", image.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                dish.Image = image.FileName;
            }
            else
            {
                // Giữ nguyên giá trị hiện tại của thuộc tính Image trong đối tượng Dish
                Dish currentDish = _dishRepository.findById(dish.DishId);
                dish.Image = currentDish.Image;
            }

            _dishRepository.Update(dish);
            return RedirectToAction("Index");
        }
        public IActionResult EditFood(string id)
        {
            var q1 = from c in _categoryRepository.GetAll()
                     select new SelectListItem()
                     {
                         Text = c.NameCategory,
                         Value = c.CategoryId.ToString()
                     };
                     ViewBag.CategoryId = q1.ToList();
            return View("EditFood", _dishRepository.findById(id));
        }
    }
}
