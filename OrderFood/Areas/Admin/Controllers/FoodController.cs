using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderFood.Models;
using OrderFood.Repository;
using X.PagedList;

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
        public IActionResult findDishCategory(int? id, string searchString, int page = 1, int pageSize = 10)
        {
            var categories = _categoryRepository.GetAll();
            ViewBag.Categories = categories;

            List<Dish> dishes;
            if (id.HasValue)
            {
                if (id.Value == 0) // check if the "Tất cả" option is selected
                {
                    dishes = _dishRepository.GetAll();
                }
                else
                {
                    dishes = _dishRepository.GetAllDishByCategoryID(id.Value);
                }

                ViewBag.CategoryId = id.Value; // set the CategoryId ViewBag variable
            }
            else
            {
                dishes = _dishRepository.GetAll();
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = _dishRepository.SearchDish(searchString);
                ViewBag.SearchString = searchString; // set the SearchString ViewBag variable
            }

            int totalItem = dishes.Count;
            int totalPages = (int)Math.Ceiling((double)totalItem / pageSize);

            dishes = dishes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItem = totalItem;
            ViewBag.TotalPages = totalPages;

            return View("Index", dishes);
        }
        public IActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            List<Dish> dishes;
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = _dishRepository.SearchDish(searchString);
            }
            else
            {
                dishes = _dishRepository.GetAll();
            }

            int totalItem = dishes.Count;
            int totalPages = (int)Math.Ceiling((double)totalItem / pageSize);

            dishes = dishes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.SearchString = searchString;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItem = totalItem;
            ViewBag.TotalPages = totalPages;


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
            else
            {
                var categories = _categoryRepository.GetAll()
                    .Select(c => new SelectListItem()
                    {
                        Text = c.NameCategory,
                        Value = c.CategoryId.ToString()
                    })
               .ToList();
                ViewBag.CategoryId = categories;
                return View("CreateFood", dish);
            }

        }
        public IActionResult CreateFood()
        {
            var categories = _categoryRepository.GetAll()
                     .Select(c => new SelectListItem()
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
        //Đếm món ăn đang có

    }
}
