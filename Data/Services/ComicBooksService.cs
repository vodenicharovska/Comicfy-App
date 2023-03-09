using Comicfy.Data.Base;
using Comicfy.Data.ViewModels;
using Comicfy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Data.Services
{
    public class ComicBooksService:EntityBaseRepository<ComicBook>, IComicBooksService
    {
        private readonly AppDbContext _context;
        public ComicBooksService(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task AddNewComicBookAsync(NewComicBookVM data)
        {
            var newComicBook = new ComicBook()
            {
                Title = data.Title,
                ShortDescription = data.ShortDescription,
                Image = data.Image,
                WriterId = data.WriterId,
                PencilerId = data.PencilerId,
                CoverArtistId = data.CoverArtistId,
                Price = data.Price,
                Published = data.Published,
                Language = data.Language,
                SellingCategory = data.SellingCategory
            };
            await _context.ComicBooks.AddAsync(newComicBook);
            await _context.SaveChangesAsync();

            //Add ComicBook Main Characters
            foreach(var characterId in data.CharacterIds)
            {
                var newCharacterMovie = new MCharacter_ComicBook()
                {
                    ComicBookId = newComicBook.Id,
                    CharacterId = characterId
                };
                await _context.Characters_ComicBooks.AddAsync(newCharacterMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ComicBook> GetComicBookByIdAsync(int id)
        {
            var comicBookDetails = await _context.ComicBooks
                .Include(w => w.Writer)
                .Include(p => p.Penciler)
                .Include(c => c.CoverArtist)
                .Include(cb => cb.Characters_ComicBooks).ThenInclude(mc => mc.MainCharacter)
                .FirstOrDefaultAsync(n => n.Id == id);

            return comicBookDetails;
        }

        public async Task<NewComicBookDropdownsVM> GetNewComicBookDropdownsValues()
        {
            var response = new NewComicBookDropdownsVM()
            {
                Writers = await _context.Writers.OrderBy(w => w.Name).ToListAsync(),
                Pencilers = await _context.Pencilers.OrderBy(p => p.Name).ToListAsync(),
                CoverArtists = await _context.CoverArtists.OrderBy(ca => ca.Name).ToListAsync(),
                MainCharacters = await _context.MainCharacters.OrderBy(mc => mc.Name).ToListAsync()
            }; 
            return response;
        }

        public async Task UpdateComicBookAsync(NewComicBookVM data)
        {
            var dbComicBook = await _context.ComicBooks.FirstOrDefaultAsync(n => n.Id == data.Id);
            
            if(dbComicBook != null)
            {
                dbComicBook.Title = data.Title;
                dbComicBook.ShortDescription = data.ShortDescription;
                dbComicBook.Image = data.Image;
                dbComicBook.WriterId = data.WriterId;
                dbComicBook.PencilerId = data.PencilerId;
                dbComicBook.CoverArtistId = data.CoverArtistId;
                dbComicBook.Price = data.Price;
                dbComicBook.Published = data.Published;
                dbComicBook.Language = data.Language;
                dbComicBook.SellingCategory = data.SellingCategory;

                await _context.SaveChangesAsync();
            }

            //Remove existing Characters
            var existingCharactersDb = _context.Characters_ComicBooks.Where(n => n.ComicBookId == data.Id).ToList();
            _context.Characters_ComicBooks.RemoveRange(existingCharactersDb);
            await _context.SaveChangesAsync();

            //Add ComicBook Main Characters
            foreach (var characterId in data.CharacterIds)
            {
                var newCharacterMovie = new MCharacter_ComicBook()
                {
                    ComicBookId = data.Id,
                    CharacterId = characterId
                };
                await _context.Characters_ComicBooks.AddAsync(newCharacterMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
