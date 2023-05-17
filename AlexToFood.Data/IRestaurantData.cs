using AlexToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurants();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Delete(int id);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() {Id = 1, Name = "Alexis Mexican", Location = "Itagüí", Cuisine = CuisineType.Mexican},
                new Restaurant() {Id = 2, Name = "Alexis Italian", Location = "Itagüí", Cuisine = CuisineType.Italian}
            };
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return restaurants.Where(r => r.Name.Contains(name)).OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id ==  updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        Restaurant IRestaurantData.Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }
}
