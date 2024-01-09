using Microsoft.EntityFrameworkCore;
using Tutorial.Data;
using Tutorial.Interfaces;
using Tutorial.Models;

namespace Tutorial.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _context;
        public CharacterRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(Character character)
        {
            _context.Add(character);
            return Save();
        }

        public bool Delete(Character character)
        {
            _context.Remove(character);
            return Save();
        }

        public async Task<IEnumerable<Character>> GetAll()
        {
            return await _context.Characters.GroupBy(c => c.Name).Select(group => group.First()).ToListAsync();

        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await _context.Characters.FirstOrDefaultAsync(i => i.CharacterId == id);
        }

        public Task<IEnumerable<Build>> GetCharacterBuilds(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Character character)
        {
            _context.Update(character);
            return Save();
        }
    }
}
