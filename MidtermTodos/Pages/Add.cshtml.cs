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
        public Todo NewTodo { get; set; }

        [BindProperty]
        public IdentityUser Owner { get; set; }


        public AddModel(TodoContext context, ILogger<LoginModel> logger, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id.HasValue)
            { // Edit
                var currTodo = await _context.Todos.FirstOrDefaultAsync(m => m.Id == id);

                if (currTodo == null)
                {
                    return NotFound();
                }
                else
                {
                    NewTodo = currTodo;
                    Console.WriteLine(NewTodo);
                }
            }
            else
            { // Add
                NewTodo = new Todo();

                NewTodo.Owner = await _userManager.GetUserAsync(User);
                Console.WriteLine(NewTodo);
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
            Console.WriteLine(NewTodo);
            Console.WriteLine(Owner);
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
            // Console.WriteLine("------------------enter post------------------");
            // Console.WriteLine(NewTodo);
            // Console.WriteLine(NewTodo.Id);

            if (NewTodo.Id > 0)
            {
                _context.Attach(NewTodo).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                Console.WriteLine("-----=====-----  Updated  -----=====-----");
                Console.WriteLine(NewTodo + " is updated.");
                _logger.LogInformation($"Todo {NewTodo} is updated.");
                TempData["FlashMessage"] = $"Todo {NewTodo.Id} is updated.";
            }
            else
            {
                NewTodo.Owner = await _userManager.GetUserAsync(User);
                Console.WriteLine(NewTodo);
                Console.WriteLine("-----=====-----  add  -----=====-----");
                _context.Todos.Add(NewTodo);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Todo {NewTodo} is added.");
                Console.WriteLine(NewTodo + " is added.");
                TempData["FlashMessage"] = $"Todo {NewTodo.Id} is added.";
            }

            return RedirectToPage("./Index");
        }
    }
}
