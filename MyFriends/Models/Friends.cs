using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyFriends.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        public IdentityUser Author { get; set; } = null!;

        [RegularExpression(@"^[a-zA-Z]+$"), Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Friend Name")]
        public string Name { get; set; } = string.Empty; // or any other default value

        [Required]
        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150.")]  // server-side validation, use ModelState.IsValid to call it
        public int Age { get; set; }
    }
}