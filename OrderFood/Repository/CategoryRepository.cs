using OrderFood.Models;
namespace OrderFood.Repository
{
    public interface ICategoryRepository
    {
        public bool Create(Category category);

        public bool Update(Category category);
        public Category findById(int id);
        public bool Delete(int categoryId);
        List<Category> Search(string searchString);
        public bool CheckNameCategory(string nameNameCategory);
        public List<Category> GetAll();
    }
    public class CategoryRepository : ICategoryRepository
    {
        private OrderFoodDBContext _dBContext;
        public CategoryRepository(OrderFoodDBContext dbContext)
        {
            _dBContext = dbContext;
        }
        public bool Create(Category category)
        {
            _dBContext.Categories.Add(category);
            _dBContext.SaveChanges();
            return true;
        }

        public bool Delete(int categoryId)
        {
            Category c = _dBContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            _dBContext.Remove(c);
            _dBContext.SaveChanges();
            return true;
        }



        public List<Category> GetAll()
        {
            return _dBContext.Categories.ToList();
        }
        public Category findById(int categoryId)
        {
            Category c = _dBContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            return c;
        }
        public bool Update(Category category)
        {
            Category c = _dBContext.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (c != null)
            {
                _dBContext.Entry(c).CurrentValues.SetValues(category);
                _dBContext.SaveChanges();
            }

            return true;
        }

        public bool CheckNameCategory(string name)
        {
            Category c = _dBContext.Categories.Where(x => x.NameCategory.Trim() == name.Trim()).FirstOrDefault();
            if (c == null)
            {
                return false;
            }
            return true;
        }

        public List<Category> Search(string searchString)
        {
            return _dBContext.Categories.Where(c => c.NameCategory.Contains(searchString)).ToList();
        }
    }
}
