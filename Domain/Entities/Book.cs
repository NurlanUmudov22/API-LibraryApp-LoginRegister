using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Book : BaseEntity
    {
        public string  Name { get; set; }

        public string  Description { get; set; }

        public int PageCount { get; set; }

        public ICollection<BookAuthors> BookAuthors { get; set; }

    }
}
