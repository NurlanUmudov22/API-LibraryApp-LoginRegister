using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Books
{
    public class BookCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int PageCount { get; set; }

        public int AuthorId { get; set; }
    }
}
