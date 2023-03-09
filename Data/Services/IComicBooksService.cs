using Comicfy.Data.Base;
using Comicfy.Data.ViewModels;
using Comicfy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Data.Services
{
    public interface IComicBooksService: IEntityBaseRepository<ComicBook>
    {
        Task<ComicBook> GetComicBookByIdAsync(int id);
        Task<NewComicBookDropdownsVM> GetNewComicBookDropdownsValues();
        Task AddNewComicBookAsync(NewComicBookVM data);
        Task UpdateComicBookAsync(NewComicBookVM data);
    }
}
