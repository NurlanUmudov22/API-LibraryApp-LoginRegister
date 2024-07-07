using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Authors;
using Service.Services.Interfaces;

namespace LibraryApp.Controllers.Admin
{
    //[Authorize]

    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _authorService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorCreateDto request)
        {
            await _authorService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { Response = "Data succesfully created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] AuthorEditDto request)
        {
            await _authorService.EditAsync(id, request);
            return Ok(new { response = "Data successfully updated" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _authorService.DeleteAsync(id);
            return Ok(new { response = "Data successfully deleted" });
        }
    }
}
