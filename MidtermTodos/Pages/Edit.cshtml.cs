using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MidtermTodos.Models;
using MidtermTodos.Data;
using Microsoft.EntityFrameworkCore;

namespace MidtermTodos.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly TodoContext _context;
        private readonly ILogger<LoginModel> _logger;

        [BindProperty]
        public Todo TodoToUpdate { get; set; } = default!;

        public EditModel(TodoContext context, ILogger<LoginModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            var currTodo = await _context.Todos.FirstOrDefaultAsync(m => m.Id == id);

            if (currTodo == null)
            {
                return NotFound();
            }
            else
            {
                TodoToUpdate = currTodo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // if (!ModelState.IsValid)
            // {
            //     Console.WriteLine("ModelState is not valid");
            //     return Page();
            // }

            _context.Attach(TodoToUpdate).State = EntityState.Modified;

            Console.WriteLine(TodoToUpdate);
            _logger.LogInformation($"Todo {TodoToUpdate} is updated.");
            TempData["FlashMessage"] = $"Todo {TodoToUpdate.Id} is updated.";

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
