using Comicfy.Data;
using Comicfy.Data.Services;
using Comicfy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Controllers
{
    public class ComicBooksController : Controller
    {
        private readonly IComicBooksService _service;
        public ComicBooksController(IComicBooksService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allComicBooks = await _service.GetAllAsync(w => w.Writer, p => p.Penciler, c => c.CoverArtist);
            return View(allComicBooks);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allComicBooks = await _service.GetAllAsync(w => w.Writer, p => p.Penciler, c => c.CoverArtist);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allComicBooks.Where(n => n.Title.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allComicBooks);
        }

        //Get: ComicBooks/Details/Id

        public async Task<IActionResult> Details(int id)
        {
            var comicBookDetail = await _service.GetComicBookByIdAsync(id);
            return View(comicBookDetail);
        }

        //Get: ComicBooks/Create
        public async Task<IActionResult> Create()
        {
            var comicBookDropdownsData = await _service.GetNewComicBookDropdownsValues();

            ViewBag.Writers = new SelectList(comicBookDropdownsData.Writers, "Id", "Name");
            ViewBag.Pencilers = new SelectList(comicBookDropdownsData.Pencilers, "Id", "Name");
            ViewBag.CoverArtists = new SelectList(comicBookDropdownsData.CoverArtists, "Id", "Name");
            ViewBag.MainCharacters = new SelectList(comicBookDropdownsData.MainCharacters, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewComicBookVM comicBook)
        {
            if (!ModelState.IsValid)
            {
                var comicBookDropdownsData = await _service.GetNewComicBookDropdownsValues();

                ViewBag.Writers = new SelectList(comicBookDropdownsData.Writers, "Id", "Name");
                ViewBag.Pencilers = new SelectList(comicBookDropdownsData.Pencilers, "Id", "Name");
                ViewBag.CoverArtists = new SelectList(comicBookDropdownsData.CoverArtists, "Id", "Name");
                ViewBag.MainCharacters = new SelectList(comicBookDropdownsData.MainCharacters, "Id", "Name");

                return View(comicBook);
            }

            await _service.AddNewComicBookAsync(comicBook);
            return RedirectToAction(nameof(Index));
        }

        //Get: ComicBooks/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var comicBookDetails = await _service.GetComicBookByIdAsync(id);
            if (comicBookDetails == null) return View("NotFound");

            var response = new NewComicBookVM()
            {
                Id = comicBookDetails.Id,
                Title = comicBookDetails.Title,
                ShortDescription = comicBookDetails.ShortDescription,
                Published = comicBookDetails.Published,
                Image = comicBookDetails.Image,
                Price = comicBookDetails.Price,
                Language = comicBookDetails.Language,
                WriterId = comicBookDetails.WriterId,
                PencilerId = comicBookDetails.PencilerId,
                CoverArtistId = comicBookDetails.CoverArtistId,
                CharacterIds = comicBookDetails.Characters_ComicBooks.Select(n => n.CharacterId).ToList(),
            };

            var comicBookDropdownsData = await _service.GetNewComicBookDropdownsValues();

            ViewBag.Writers = new SelectList(comicBookDropdownsData.Writers, "Id", "Name");
            ViewBag.Pencilers = new SelectList(comicBookDropdownsData.Pencilers, "Id", "Name");
            ViewBag.CoverArtists = new SelectList(comicBookDropdownsData.CoverArtists, "Id", "Name");
            ViewBag.MainCharacters = new SelectList(comicBookDropdownsData.MainCharacters, "Id", "Name");

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewComicBookVM comicBook)
        {
            if (id != comicBook.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var comicBookDropdownsData = await _service.GetNewComicBookDropdownsValues();

                ViewBag.Writers = new SelectList(comicBookDropdownsData.Writers, "Id", "Name");
                ViewBag.Pencilers = new SelectList(comicBookDropdownsData.Pencilers, "Id", "Name");
                ViewBag.CoverArtists = new SelectList(comicBookDropdownsData.CoverArtists, "Id", "Name");
                ViewBag.MainCharacters = new SelectList(comicBookDropdownsData.MainCharacters, "Id", "Name");

                return View(comicBook);
            }

            await _service.UpdateComicBookAsync(comicBook);
            return RedirectToAction(nameof(Index));
        }
    }
}
