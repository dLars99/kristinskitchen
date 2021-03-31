using KristinsKitchen.Models;

namespace KristinsKitchen.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetById(int id);
        void Update(UserProfile userProfile);
    }
}