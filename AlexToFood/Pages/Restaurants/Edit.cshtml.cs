using AlexToFood.Core;
using AlexToFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlexToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public IHtmlHelper HtmlHelper { get; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            HtmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = HtmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Restaurant = restaurantData.Update(Restaurant);
            restaurantData.Commit();
            return Page();
        }
    }
}
