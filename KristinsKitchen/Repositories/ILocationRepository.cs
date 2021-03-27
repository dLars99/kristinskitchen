using KristinsKitchen.Models;
using System.Collections.Generic;

namespace KristinsKitchen.Repositories
{
    public interface ILocationRepository
    {
        List<Location> GetAll();
        Location GetById(int id);
    }
}