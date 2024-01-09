using Microsoft.AspNetCore.Mvc;
using Tutorial.Interfaces;
using Tutorial.Models;
using Tutorial.Repository;
using Tutorial.ViewModels;

namespace Tutorial.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IBuildRepository _buildRepository;

        public CharacterController(ICharacterRepository characterRepository, IBuildRepository buildRepository)
        {

            _characterRepository = characterRepository;
            _buildRepository = buildRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Character> characters = await _characterRepository.GetAll();
            return View(characters);
        }
        public async Task<IActionResult> Create()
        {
            var viewModel = new CharacterViewModel
            {
                Builds = await _buildRepository.GetAll(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CharacterViewModel characterVM)
        {

            if (ModelState.IsValid)
            {
                var character = new Character
                {
                    Name = characterVM.Name,
                    Element = characterVM.Element,
                    Region  = characterVM.Region,
                    CharacterWeaponType= characterVM.CharacterWeaponType.ToString(),
                    BuildId = characterVM.BuildId,

                };
                _characterRepository.Add(character);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var character = await _characterRepository.GetByIdAsync(id);
            if (character == null) return View("Error");
            var characterVM = new Character
            {
                Name = character.Name,
                CharacterWeaponType =  character.CharacterWeaponType,
                Element = character.Element,
                Region = character.Region,
                CharacterId = character.CharacterId,
                BuildsList= await _buildRepository.GetAll(),
            };
            return View(characterVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Character updatedChar)
        {
            
            var existingChar = await _characterRepository.GetByIdAsync(id);

            existingChar.Name = updatedChar.Name;
            existingChar.Element = updatedChar.Element;
            existingChar.Region = updatedChar.Region;
            existingChar.CharacterWeaponType = updatedChar.CharacterWeaponType;
            _characterRepository.Update(existingChar);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _characterRepository.GetByIdAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _characterRepository.GetByIdAsync(id);
            if (character == null)
            {
                return View("Error");
            }
            _characterRepository.Delete(character);
            return RedirectToAction(nameof(Index));
        }
    }
}
