using OrderFood.Models;

namespace OrderFood.Repository
{
    public interface IDishRepository
    {
        public bool Create(Dish dish);
        public Dish findById(string id);
        public bool Update(Dish dish);
        public bool Delete(string DishId);
        public Dish findByDishId(string id);
        List<Dish> SearchDish(string searchString);
        public List<Dish> GetDishesByName(string name);
        public List<Dish> GetAllDishByCategoryID(int id);
        List<Dish> GetAll();

        List<Dish> PriceIncrease();

        List<Dish> PriceDecrease();
        Dish findById(Guid dishId);
    }
    public class DishRepository : IDishRepository
    {
        private OrderFoodDBContext _dbContext;
        public Dish findById(Guid id)
        {
            return _dbContext.Dishes.Find(id);
        }
        public DishRepository(OrderFoodDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Dish dish)
        {
            _dbContext.Dishes.Add(dish);
            _dbContext.SaveChanges();
            return true;
        }
        public List<Dish> GetDishesByName(string name)
        {
            return _dbContext.Dishes.Where(x => x.NameDish.Contains(name)).ToList();
        }
        public bool Delete(string DishId)
        {
            Guid dishIdGuid = Guid.Parse(DishId);
            Dish d = _dbContext.Dishes.FirstOrDefault(x => x.DishId == dishIdGuid);
            _dbContext.Remove(d);
            _dbContext.SaveChanges();
            return true;
        }



        public List<Dish> GetAll()
        {
            return _dbContext.Dishes.ToList();
        }

        public List<Dish> GetAllDishByCategoryID(int id)
        {
            //Guid dishIdGuid = Guid.Parse(id);
            return _dbContext.Dishes.Where(x => x.CategoryId == id).ToList();
        }
        public Dish findById(string DishId)
        {
            Guid dishIdGuid = Guid.Parse(DishId);
            Dish d = _dbContext.Dishes.FirstOrDefault(x => x.DishId == dishIdGuid);
            return d;
        }
        public bool Update(Dish dish)
        {
            Dish d = _dbContext.Dishes.FirstOrDefault(x => x.DishId == dish.DishId);
            if (d != null)
            {
                _dbContext.Entry(d).CurrentValues.SetValues(dish);
                _dbContext.SaveChanges();
            }
            return true;
        }

        public Dish findByDishId(string id)
        {
            Guid dishIdGuid = Guid.Parse(id);
            return _dbContext.Dishes.Where(x => x.DishId == dishIdGuid).FirstOrDefault();
        }

        public List<Dish> PriceIncrease()
        {
            return _dbContext.Dishes.OrderBy(x => x.Price).ToList();

        }

        public List<Dish> PriceDecrease()
        {
            return _dbContext.Dishes.OrderBy(x => x.Price).Reverse().ToList();
        }

        public List<Dish> SearchDish(string searchString)
        {
            return _dbContext.Dishes.Where(x => x.NameDish.Contains(searchString)).ToList();
        }
    }
}
