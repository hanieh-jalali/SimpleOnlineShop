namespace SimpleOnlineStore.Domain.IRepository
{
    public interface IUserRepository
    {
        public Task<bool> CheckExist(int id);
    }
}
