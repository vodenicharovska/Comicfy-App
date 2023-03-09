using Comicfy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Data.ViewModels
{
    public class NewComicBookDropdownsVM
    {
        public NewComicBookDropdownsVM()
        {
            Writers = new List<Writer>();
            Pencilers = new List<Penciler>();
            CoverArtists = new List<CoverArtist>();
            MainCharacters = new List<MainCharacter>();
        }

        public List<Writer> Writers { get; set; }
        public List<Penciler> Pencilers { get; set; }
        public List<CoverArtist> CoverArtists { get; set; }
        public List<MainCharacter> MainCharacters { get; set; }
    }
}
