using KristinsKitchen.Models;
using System.Collections.Generic;

namespace KristinsKitchen.Repositories
{
    public interface IIngredientsDBRepository
    {
        List<IngredientsDB> GetAll();
        IngredientsDB GetById(int id);
        void Add(IngredientsDB ingredient);
        void Update(IngredientsDB ingredient);
    }
}