using Comicfy.Data.Base;
using Comicfy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Data.Services
{
    public class MCharactersService : EntityBaseRepository<MainCharacter>, IMCharactersService
    {
        public MCharactersService(AppDbContext context) : base(context) { }
    }
}
