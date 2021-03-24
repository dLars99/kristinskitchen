using KristinsKitchen.Models;

namespace KristinsKitchen.Utils
{
    public static class Validations
    {
        public static string ValidateIngredient(IngredientsDB ingredient)
        {
            if (ingredient.PantryShelfLife <= -1 && ingredient.FridgeShelfLife <= -1 && ingredient.FreezerShelfLife <= -1)
            {
                return "Cannot add ingredient to database without an expiration date in at least one storage location.";
            }
            if (ingredient.CategoryId < 1 || ingredient.CategoryId > 3)
            {
                return "Cannot add ingredient to database without a valid category.";
            }
            if (ingredient.Quantity < 0)
            {
                return "Ingredient quantity cannot be negative.";
            }

            return "";
        }

    }
}
