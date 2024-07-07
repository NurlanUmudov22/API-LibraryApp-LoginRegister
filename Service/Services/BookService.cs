using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.BookAuthors;
using Service.DTOs.Admin.Books;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookAuthorsRepository _bookAuthorsRepo;
        private readonly IMapper _mapper;


        public BookService(IBookRepository bookRepo,
                           IAuthorRepository authorRepo,
                           IBookAuthorsRepository bookAuthorsRepo,
                           IMapper mapper)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _bookAuthorsRepo = bookAuthorsRepo;
            _mapper = mapper;

        }


        public async  Task CreateAsync(BookCreateDto model)
        {
            var data = _mapper.Map<Book>(model);
         
            await _bookRepo.CreateAsync(data);
            await _bookAuthorsRepo.CreateAsync(new BookAuthors { BookId = data.Id, AuthorId = model.AuthorId });
        }

        public async  Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var book = await _bookRepo.GetById((int)id) ?? throw new NotFoundException("Data not found");

            await _bookRepo.DeleteAsync(book);
        }

        public async  Task EditAsync(int? id, BookEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var book = await _bookRepo.GetById((int)id) ?? throw new NotFoundException("Data not found");
        
            _mapper.Map(model, book);
            await _bookRepo.EditAsync(book);
        }

        public async  Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var datas = await _bookRepo.FindAllWithIncludes()
                                             .Include(m => m.BookAuthors)
                                             .ThenInclude(m => m.Author)
                                             .ToListAsync();

            return _mapper.Map<IEnumerable<BookDto>>(datas);
        }

        public async  Task<BookDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var book = await _bookRepo.FindAllWithIncludes()
                .Where(m => m.Id == id)
                .Include(m => m.BookAuthors)
                .ThenInclude(m => m.Author)                                             
                .FirstOrDefaultAsync();

            return book is null ? throw new NotFoundException("Data not found") : _mapper.Map<BookDto>(book);
        }


    }
}
