using Tutorial.Models;

namespace Tutorial.Interfaces
{
    public interface IBuildRepository
    {
        Task<IEnumerable<Build>> GetAll();
        Task<Build> GetByIdAsync(int id);
        Task<IEnumerable<Character>> GetCharactersByBuild(int buildId);
        bool Add(Build build);
        bool Update(Build build);
        bool Delete(Build build);
        bool Save();
    }
}
