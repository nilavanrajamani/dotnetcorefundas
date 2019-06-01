using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFoodApril.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;
        private IConfiguration config;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            this.restaurantData = restaurantData;
            this.logger = logger;
            this.config = configuration;
        }

        public void OnGet()
        {
            logger.LogError("On Get ListModel");
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}