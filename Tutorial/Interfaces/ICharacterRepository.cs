using Tutorial.Models;

namespace Tutorial.Interfaces
{
    public interface ICharacterRepository
    { 
        Task<IEnumerable<Character>> GetAll();
        Task<Character> GetByIdAsync(int id);
        Task<IEnumerable<Build>> GetCharacterBuilds(int id);
        bool Add(Character character);
        bool Update(Character character);
        bool Delete(Character character);
        bool Save();
    }
}
