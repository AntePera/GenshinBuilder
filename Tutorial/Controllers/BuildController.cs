using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tutorial.Interfaces;
using Tutorial.Models;
using Tutorial.ViewModels;

namespace Tutorial.Controllers
{
    public class BuildController : Controller
    {
        private readonly IBuildRepository _buildRepository;
        private readonly IWeaponRepository _weaponRepository;
        private readonly ICharacterRepository _characterRepository;

        public BuildController(IBuildRepository buildRepository, IWeaponRepository weaponRepository,ICharacterRepository characterRepository)
        {

            _buildRepository = buildRepository;
            _weaponRepository = weaponRepository;
            _characterRepository = characterRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Build> builds = await _buildRepository.GetAll();

            return View(builds);
        }
        public async Task<IActionResult>ListCharacters(int id)
        {
            IEnumerable<Character> characters = await _buildRepository.GetCharactersByBuild(id);
            return View(characters);
        }
        public async Task<IActionResult> Create()
        {
            var viewModel = new BuildViewModel
            {
               Weapons = await _weaponRepository.GetAll(),
            };
  
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BuildViewModel buildVM)
        {
            var weapon = await _weaponRepository.GetByIdAsync(buildVM.WeaponId);
            if (ModelState.IsValid) 
            {
                var build = new Build
                {
                    BuildName = buildVM.SetName,
                    WeaponId = buildVM.WeaponId,
                    WeaponName =weapon.Name,
                    WeaponType=weapon.Type.ToString(),
                    BuildDescription=buildVM.Description,

                };
                _buildRepository.Add(build);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var build= await _buildRepository.GetByIdAsync(id);
            var buildVM = new BuildViewModel
            {
                Id=id,
                SetName = build.BuildName,
                Description = build.BuildDescription,
                BuildWeaponType = build.WeaponType,
                WeaponId = build.WeaponId,
                Weapons = await _weaponRepository.GetAll(),

            };
            if (buildVM.Weapons != null)
            {
                return View(buildVM);
            }
            else
            {

                return RedirectToAction("index"); 
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BuildViewModel buildVM)
        {
            var weapon = await _weaponRepository.GetByIdAsync(buildVM.WeaponId);
       

            var build = await _buildRepository.GetByIdAsync(id);
            

             build.BuildName = buildVM.SetName;
             build.BuildDescription = buildVM.Description;
             build.WeaponType = buildVM.BuildWeaponType;
             build.WeaponId = buildVM.WeaponId;
             build.WeaponName = weapon.Name;

            _buildRepository.Update(build);


            return RedirectToAction("Index");

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var build = await _buildRepository.GetByIdAsync(id);

            if (build == null)
            {
                return NotFound();
            }

            return View(build);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var build = await _buildRepository.GetByIdAsync(id);
            if (build == null)
            {
                return View("Error");
            }
            _buildRepository.Delete(build);
            return RedirectToAction(nameof(Index));
        }

    }
}
    