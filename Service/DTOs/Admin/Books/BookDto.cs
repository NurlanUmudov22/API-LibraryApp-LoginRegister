using Service.DTOs.Admin.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Books
{
    public  class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PageCount { get; set; }

        public IEnumerable<AuthorDto> Authors { get; set; }


    }
}
