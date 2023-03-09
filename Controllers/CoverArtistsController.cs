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
    public class CoverArtistsController : Controller
    {
        private readonly ICoverArtistsService _service;
        public CoverArtistsController(ICoverArtistsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCoverArtists = await _service.GetAllAsync();
            return View(allCoverArtists);
        }

        //Get: CoverArtists/Details/Id
        public async Task<IActionResult> Details(int id)
        {
            var coverArtistDetails = await _service.GetByIdAsync(id);
            if (coverArtistDetails == null) return View("NotFound");
            return View(coverArtistDetails);
        }

        //Get: CoverArtists/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] CoverArtist coverArtist)
        {
            if (!ModelState.IsValid)
            {
                return View(coverArtist);
            }
            await _service.AddAsync(coverArtist);
            return RedirectToAction(nameof(Index));
        }

        //Get: CoverArtists/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var coverArtistDetails = await _service.GetByIdAsync(id);
            if (coverArtistDetails == null) return View("NotFound");
            return View(coverArtistDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CoverArtist coverArtist)
        {
            coverArtist.Id = id;
            if (!ModelState.IsValid)
            {
                return View(coverArtist);
            }
            await _service.UpdateAsync(id, coverArtist);
            return RedirectToAction(nameof(Index));
        }

        //Get: CoverArtists/Delete/Id
        public async Task<IActionResult> Delete(int id)
        {
            var coverArtistDetails = await _service.GetByIdAsync(id);
            if (coverArtistDetails == null) return View("NotFound");
            return View(coverArtistDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coverArtistDetails = await _service.GetByIdAsync(id);
            if (coverArtistDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
