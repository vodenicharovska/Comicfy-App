using Comicfy.Data;
using Comicfy.Data.Services;
using Comicfy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Controllers
{
    public class MCharactersController : Controller
    {
        private readonly IMCharactersService _service;
        public MCharactersController(IMCharactersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: MCharacters/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Picture, Name, Bio")]MainCharacter mCharacter)
        {
            if (!ModelState.IsValid)
            {
                return View(mCharacter);
            }
            await _service.AddAsync(mCharacter);
            return RedirectToAction(nameof(Index));
        }

        //Get: MCharacters/Details/Id

        public async Task<IActionResult> Details(int id)
        {
            var mCharacterDetails = await _service.GetByIdAsync(id);

            if (mCharacterDetails == null) return View("NotFound");
            return View(mCharacterDetails);
        }

        //Get: MCharacters/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var mCharacterDetails = await _service.GetByIdAsync(id);

            if (mCharacterDetails == null) return View("NotFound");

            return View(mCharacterDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MainCharacter mCharacter)
        {
            mCharacter.Id = id;
            if (!ModelState.IsValid)
            {
                return View(mCharacter);
            }
            await _service.UpdateAsync(id, mCharacter);
            return RedirectToAction(nameof(Index));
        }

        //Get: MCharacters/Delete/Id
        public async Task<IActionResult> Delete(int id)
        {
            var mCharacterDetails = await _service.GetByIdAsync(id);

            if (mCharacterDetails == null) return View("NotFound");

            return View(mCharacterDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mCharacterDetails = await _service.GetByIdAsync(id);
            if (mCharacterDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
