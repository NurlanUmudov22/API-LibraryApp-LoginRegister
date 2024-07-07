using Service.DTOs.Admin.BookAuthors;
using Service.DTOs.Admin.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateAsync(BookCreateDto model);
        Task EditAsync(int? id, BookEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> GetByIdAsync(int? id);

       
    }
}
