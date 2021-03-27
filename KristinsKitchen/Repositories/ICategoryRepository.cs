using KristinsKitchen.Models;
using System.Collections.Generic;

namespace KristinsKitchen.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
    }
}