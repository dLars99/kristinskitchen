using KristinsKitchen.Models;
using System.Collections.Generic;

namespace KristinsKitchen.Repositories
{
    public interface IIngredientRepository
    {
        void Add(Ingredient ingredient);
        void Delete(int id);
        List<Ingredient> GetAllByUser(int userId);
        Ingredient GetById(int id);
        void Update(Ingredient ingredient);
    }
}