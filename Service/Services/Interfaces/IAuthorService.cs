using Service.DTOs.Admin.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public  interface IAuthorService
    {
        Task CreateAsync(AuthorCreateDto model);
        Task EditAsync(int? id, AuthorEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(int? id);
    }
}
