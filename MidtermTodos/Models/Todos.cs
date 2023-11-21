using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MidtermTodos.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public IdentityUser Owner { get; set; } = null!; // required, never null

        [Required, StringLength(200, MinimumLength = 1)]
        public string Task { get; set; } = string.Empty; // required, never null, 1-200 characters

        [Required]
        [Range(typeof(DateTime), "1/1/2000", "12/31/2099", ErrorMessage = "Due date must be between 2000 and 2099")]
        public DateTime DueDate { get; set; } // required, never null, year in 2000-2099 range

        public bool IsDone { get; set; } // not required, default false

        public override string ToString()
        {
            return $"Id: {Id}, Owner: {Owner}, Task: {Task}, DueDate: {DueDate}, IsDone: {IsDone}";
        }
    }
}