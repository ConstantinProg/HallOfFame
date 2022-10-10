using HallOfFame.Data;

namespace HallOfFame.Data
{
    public interface IPersonRepository
    {
        Task<List<Transfer.Person>> GetAllAsync();
        Task<Transfer.Person> AddAsync(Transfer.Person person);
        Task<Transfer.Person> FindAsync(long id);
        Task<bool> RemoveAsync(long id);
        Task<bool> UpdateAsync(long id, Transfer.Person person);
    }
}
