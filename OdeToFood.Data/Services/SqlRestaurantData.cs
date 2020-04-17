using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext dbContext;
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.dbContext = db;
        }

        public void Add(Restaurant restaurant)
        {
            dbContext.Restaurants.Add(restaurant);
            dbContext.SaveChanges(); // This is the point where it gets added.
        }

        public void Delete(int Id)
        {
            var restaurant = dbContext.Restaurants.Find(Id);
            dbContext.Restaurants.Remove(restaurant);
            dbContext.SaveChanges();
        }

        public Restaurant Get(int Id)
        {
            return dbContext.Restaurants.FirstOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //return dbContext.Restaurants.OrderBy(r=>r.Id); or 
            return from r in dbContext.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            var entry = dbContext.Entry(restaurant); // means retaurant tbl and its data we want to modify is already in db 
            entry.State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
