using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MidtermTodos.Models;
using MidtermTodos.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MidtermTodos.Pages
{
    [Authorize]
    public class AddModel : PageModel
    {
        private readonly TodoContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginModel> _logger;
        // public string CurrentUser { get; private set; }

        [BindProperty]
        public Todo NewTodo { get; set; } = default!;

        public AddModel(TodoContext context, ILogger<LoginModel> logger, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            NewTodo.Owner = await _userManager.GetUserAsync(User);

            // if (!ModelState.IsValid)
            // {
            //     Console.WriteLine("ModelState is not valid");
            //     return Page();
            // }
            // if (!ModelState.IsValid)
            // {
            //     foreach (var modelStateKey in ModelState.Keys)
            //     {
            //         var modelStateVal = ModelState[modelStateKey];
            //         foreach (var error in modelStateVal.Errors)
            //         {
            //             Console.WriteLine($"Error in {modelStateKey}: {error.ErrorMessage}");
            //         }
            //     }

            //     return Page();
            // }



            // if (NewTodo.Id > 0)
            // {
            //     _context.Attach(NewTodo).State = EntityState.Modified;

            //     Console.WriteLine(NewTodo);
            //     _logger.LogInformation($"Todo {NewTodo} is updated.");
            //     TempData["FlashMessage"] = $"Todo {NewTodo.Id} is updated.";
            // }
            // else
            // {
            _context.Todos.Add(NewTodo);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Todo {NewTodo} is added.");
            TempData["FlashMessage"] = $"Todo {NewTodo.Id} is added.";

            // 
            return RedirectToPage("./Index");
        }
    }
}
