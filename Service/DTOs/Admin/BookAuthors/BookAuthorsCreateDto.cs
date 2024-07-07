using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.BookAuthors
{
    public  class BookAuthorsCreateDto
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
