using Comicfy.Data.Base;
using Comicfy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Data.Services
{
    public class CoverArtistService: EntityBaseRepository<CoverArtist>, ICoverArtistsService
    {
        public CoverArtistService(AppDbContext context): base(context)
        {

        }
    }
}
