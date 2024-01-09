using Microsoft.EntityFrameworkCore;
using Tutorial.Data;
using Tutorial.Interfaces;
using Tutorial.Models;

namespace Tutorial.Repository
{
    public class BuildRepository : IBuildRepository
    {
        private readonly AppDbContext _context;
        public BuildRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(Build build)
        {
            _context.Add(build);
            return Save();
        }

        public bool Delete(Build build)
        {
            _context.Remove(build);
            return Save();
        }

        public async Task<IEnumerable<Build>> GetAll()
        {
            return await _context.Builds.ToListAsync();

        }

        public async Task<Build> GetByIdAsync(int id)
        {
            return await _context.Builds.FirstOrDefaultAsync(i => i.BuildId== id);
        }

        public async Task<IEnumerable<Character>> GetCharactersByBuild(int buildId)
        {
            return await _context.Builds
        .Where(build => build.BuildId == buildId)
        .Join(
            _context.Characters,
            build => build.BuildId,
            character => character.BuildId,
            (build, character) => character
        )
        .ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Build build)
        {
            _context.Update(build);
            return Save();
        }
    }
}
