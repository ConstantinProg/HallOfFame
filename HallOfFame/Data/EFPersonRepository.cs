using AutoMapper;
using HallOfFame.Data.Transfer;
using HallOfFame.Data.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace HallOfFame.Data
{
    public class EFPersonRepository : IPersonRepository
    {
        private readonly FameDbContext context;
        private readonly IMapper _mapper;

        public EFPersonRepository(FameDbContext ctx, IMapper mapper)
        {
            context = ctx;
            _mapper = mapper;
        }

        public async Task<List<Transfer.Person>> GetAllAsync()
        {
            return await context.Persons.Include(p => p.Skills).ProjectTo<Transfer.Person>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<Transfer.Person> AddAsync(Transfer.Person addiedPerson)
        {
            var person = _mapper.Map<Models.Person>(addiedPerson);
            context.Persons.Add(person);
            await context.SaveChangesAsync();
            return _mapper.Map<Transfer.Person>(person);
        }

        public async Task<Transfer.Person> FindAsync(long id)
        {
            var person = await context.Persons.FindAsync(id);
            if (person == null)
                return null;
            return _mapper.Map<Transfer.Person>(person);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var person = await context.Persons.FindAsync(id);
            if (person == null)
                return false;
            context.Persons.Remove(person);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(long id, Transfer.Person person)
        {
            var updatedPerson = await context.Persons.FindAsync(id);
            if (updatedPerson == null)
                return false;
            updatedPerson = _mapper.Map<Models.Person>(person);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

