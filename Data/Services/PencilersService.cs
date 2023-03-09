using Comicfy.Data.Base;
using Comicfy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Data.Services
{
    public class PencilersService:EntityBaseRepository<Penciler>, IPencilersService
    {
        public PencilersService(AppDbContext context) : base(context)
        { 
        }
    }
}
