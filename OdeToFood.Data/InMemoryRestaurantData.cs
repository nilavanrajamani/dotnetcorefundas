using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Name= "Restaurant1", Id= 1, Cuisine = CuisineType.Indian, Location="Location1"},
                new Restaurant(){ Name= "Restaurant2", Id= 2, Cuisine = CuisineType.Italian, Location="Location2"},
            };
        }

        public Restaurant Add(Restaurant addRestaurant)
        {
            restaurants.Add(addRestaurant);
            addRestaurant.Id = restaurants.Max(x => x.Id) + 1;
            return addRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            Restaurant restaurant = restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants
                .Where(x => string.IsNullOrWhiteSpace(name) || x.Name.StartsWith(name)).OrderBy(x => x.Name).AsEnumerable();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Cuisine = updatedRestaurant.Cuisine; 
            }
            return restaurant;
        }
    }
}
