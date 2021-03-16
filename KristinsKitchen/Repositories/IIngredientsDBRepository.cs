using KristinsKitchen.Models;
using System.Collections.Generic;

namespace KristinsKitchen.Repositories
{
    public interface IIngredientsDBRepository
    {
        List<IngredientsDB> GetAllIngredients();
    }
}