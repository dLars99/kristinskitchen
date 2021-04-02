using KristinsKitchen.Models;
using System.Collections.Generic;
using System.Linq;

namespace KristinsKitchen.Utils
{
    public static class Validations
    {
        public static string ValidateIngredient(IngredientsDB ingredient, Category category)
        {
            if (ingredient.PantryShelfLife <= -1 && ingredient.FridgeShelfLife <= -1 && ingredient.FreezerShelfLife <= -1)
            {
                return "Cannot add ingredient to database without an expiration date in at least one storage location.";
            }
            if (category == null)
            {
                return "Invalid category.";
            }
            if (ingredient.Quantity < 0)
            {
                return "Ingredient quantity cannot be negative.";
            }

            return "";
        }

        public static string ValidateUserIngredient(Ingredient ingredient, IngredientsDB ingredientsDB, Location location, UserProfile userProfile)
        {
            if (ingredientsDB == null)
            {
                return "Source ingredient not located in IngredientsDB.";
            }
            if (location == null)
            {
                return "Invalid location.";
            }
            if (userProfile == null || !userProfile.IsActive)
            {
                return "Invalid user";
            }    
            return "";
        }

    }
}
