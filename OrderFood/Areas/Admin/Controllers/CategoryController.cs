using Microsoft.AspNetCore.Mvc;
using OrderFood.Models;
using OrderFood.Repository;
namespace OrderFood.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            List<Category> categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                categories = _categoryRepository.Search(searchString);
            }
            else
            {
                categories = _categoryRepository.GetAll();
            }

            int totalItems = categories.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            categories = categories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.SearchString = searchString;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = totalItems;
            ViewBag.TotalPages = totalPages;

            return View(categories);
        }
        //Tạo
        [HttpPost]
        public IActionResult saveCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                bool isCategoryNameExist = _categoryRepository.CheckNameCategory(category.NameCategory);
                if (isCategoryNameExist)
                {
                    ModelState.AddModelError(string.Empty, "Tên loại món này đã tồn tại");
                    return View("CreateCategory");
                }
                _categoryRepository.Create(category);
                return RedirectToAction("Index");
            }
            else
            {

                return View("CreateCategory", category);
            }

        }
        public IActionResult CreateCategory()
        {
            return View("CreateCategory", new Category());
        }

        //Xóa
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
        //Chỉnh sửa
        public IActionResult EditCategory(int id)
        {

            return View("EditCategory", _categoryRepository.findById(id));
        }
        public IActionResult UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
            return RedirectToAction("Index");
        }


    }
}
