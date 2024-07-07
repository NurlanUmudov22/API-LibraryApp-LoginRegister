using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Authors
{
    public  class AuthorCreateDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

    }
}
