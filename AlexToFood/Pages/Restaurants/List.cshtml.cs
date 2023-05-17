using AlexToFood.Core;
using AlexToFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
            this.config = config;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurants();
        }
    }
}
