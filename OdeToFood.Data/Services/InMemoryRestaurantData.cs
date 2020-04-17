using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Little Italy", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Bharatiya Jalpaan", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "California Burrito", Cuisine = CuisineType.Mexican }
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant); //Add restaurant to the list(restaurants)
            int maxId = restaurants.Max(r => r.Id) + 1;
            restaurant.Id = maxId; //Add one more to the max row count. This will not work in realtime. This is temp code to get id.
        }
        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if(existing!=null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }           
        }

        public Restaurant Get(int Id)
        {
            return restaurants.FirstOrDefault(resId => resId.Id==Id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Delete(int Id)
        {
            var restaurant = Get(Id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            restaurants.FirstOrDefault(resId => resId.Id == Id);
        }

    }

}
