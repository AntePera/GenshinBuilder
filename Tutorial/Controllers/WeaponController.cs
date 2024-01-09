using Microsoft.AspNetCore.Mvc;
using Tutorial.Interfaces;
using Tutorial.Models;

namespace Tutorial.Controllers
{
    public class WeaponController : Controller
    {
        
        private readonly IWeaponRepository _weaponRepository;

        public WeaponController(IWeaponRepository weaponRepository)
        {

            _weaponRepository = weaponRepository;
        }
        public async Task <IActionResult> Index()
        {
            IEnumerable<Weapon> weapons= await _weaponRepository.GetAll();
            return View(weapons);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create (Weapon weapon)
        {
            if(ModelState.IsValid)
            {
                _weaponRepository.Add(weapon);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var weapon = await _weaponRepository.GetByIdAsync(id);
            if (weapon == null) return View("Error");
            var weaponVM = new Weapon
            {
                Name = weapon.Name,
                Type = weapon.Type,
                Substat = weapon.Substat
            };
            return View(weaponVM);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id, Weapon updatedWeapon)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", updatedWeapon);
            }
            var existingWeapon=await _weaponRepository.GetByIdAsync(id);
            existingWeapon.Name = updatedWeapon.Name;
            existingWeapon.Type = updatedWeapon.Type;
            existingWeapon.Substat = updatedWeapon.Substat;
            _weaponRepository.Update(existingWeapon);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = await _weaponRepository.GetByIdAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }

            return View(weapon);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weapon = await _weaponRepository.GetByIdAsync(id);
            if (weapon == null)
            {
                return View("Error");
            }
            _weaponRepository.Delete(weapon);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
