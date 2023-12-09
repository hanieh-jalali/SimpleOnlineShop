using SimpleOnlineStore.Domain.IRepository;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<bool> CheckExist(int id)
        {
            if (_applicationDbContext.Users.Any(w => w.Id == id))
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}
