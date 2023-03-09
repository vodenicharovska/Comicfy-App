using Comicfy.Data;
using Comicfy.Data.Services;
using Comicfy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Controllers
{
    public class PencilersController : Controller
    {
        private readonly IPencilersService _service;
        public PencilersController(IPencilersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allPencilers = await _service.GetAllAsync();
            return View(allPencilers);
        }
        //Get: Pencilers/Details/Id
        public async Task<IActionResult> Details(int id)
        {
            var pencilerDetails = await _service.GetByIdAsync(id);
            if (pencilerDetails == null) return View("NotFound");
            return View(pencilerDetails);
        }

        //Get: Pencilers/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Penciler penciler)
        {
            if (!ModelState.IsValid)
            {
                return View(penciler);
            }
            await _service.AddAsync(penciler);
            return RedirectToAction(nameof(Index));
        }

        //Get: Pencilers/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var pencilerDetails = await _service.GetByIdAsync(id);
            if (pencilerDetails == null) return View("NotFound");
            return View(pencilerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Penciler penciler)
        {
            penciler.Id = id;
            if (!ModelState.IsValid)
            {
                return View(penciler);
            }
            await _service.UpdateAsync(id, penciler);
            return RedirectToAction(nameof(Index));
        }

        //Get: Pencilers/Delete/Id
        public async Task<IActionResult> Delete(int id)
        {
            var pencilerDetails = await _service.GetByIdAsync(id);
            if (pencilerDetails == null) return View("NotFound");
            return View(pencilerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pencilerDetails = await _service.GetByIdAsync(id);
            if (pencilerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
