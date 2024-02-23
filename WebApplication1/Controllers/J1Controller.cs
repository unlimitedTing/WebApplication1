using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class J1Controller : ApiController
    {
        private Dictionary<int, int> burgerCaloriesMap = new Dictionary<int, int>()
        {
            { 1, 461 },
            { 2, 431 },
            { 3, 420 },
            { 4, 0 } // Default value
        };

        private Dictionary<int, int> drinkCaloriesMap = new Dictionary<int, int>()
        {
            { 1, 130 },
            { 2, 160 },
            { 3, 118 },
            { 4, 0 } // Default value
        };

        private Dictionary<int, int> sideCaloriesMap = new Dictionary<int, int>()
        {
            { 1, 100 },
            { 2, 57 },
            { 3, 70 },
            { 4, 0 } // Default value
        };

        private Dictionary<int, int> dessertCaloriesMap = new Dictionary<int, int>()
        {
            { 1, 167 },
            { 2, 266 },
            { 3, 75 },
            { 4, 0 } // Default value
        };
        /**
         * <Summary>
         * Computes the total calories of a meal based on the choices of burger, drink, side, and dessert.
         * </Summary>
         * <param name="burger">The index of the chosen burger (1 for Cheeseburger, 2 for Fish Burger, 3 for Veggie Burger, 4 for no burger)</param>
         * <param name="drink">The index of the chosen drink (1 for Soft Drink, 2 for Orange Juice, 3 for Milk, 4 for no drink)</param>
         * <param name="side">The index of the chosen side order (1 for Fries, 2 for Baked Potato, 3 for Chef Salad, 4 for no side order)</param>
         * <param name="dessert">The index of the chosen dessert (1 for Apple Pie, 2 for Sundae, 3 for Fruit Cup, 4 for No Dessert)</param>
         * <returns>The total calorie count of the meal</returns>
         * GET api/J1/Menu/1/2/3/4 -> "Your total calorie count is 69"
         */

        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public IHttpActionResult GetTotalCalories(int burger, int drink, int side, int dessert)
        {
            int burgerCalories = burgerCaloriesMap.ContainsKey(burger) ? burgerCaloriesMap[burger] : 0;
            int drinkCalories = drinkCaloriesMap.ContainsKey(drink) ? drinkCaloriesMap[drink] : 0;
            int sideCalories = sideCaloriesMap.ContainsKey(side) ? sideCaloriesMap[side] : 0;
            int dessertCalories = dessertCaloriesMap.ContainsKey(dessert) ? dessertCaloriesMap[dessert] : 0;

            int totalCalories = burgerCalories + drinkCalories + sideCalories + dessertCalories;
            
            return Ok($"Your total calorie count is {totalCalories}");
        }
    }
}