using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Models
{
    public class MCharacter_ComicBook
    {
        public int ComicBookId { get; set; }
        public ComicBook ComicBook { get; set; }
        public int CharacterId { get; set; }
        public MainCharacter MainCharacter { get; set; }
    }
}
