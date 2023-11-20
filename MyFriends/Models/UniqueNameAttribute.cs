using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyFriends.Models;

namespace MyFriends
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        private readonly DbContext _context;

        public UniqueNameAttribute(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var name = (string?)value;

            // Check if the name is unique in the database
            if (name != null && _context.Set<Friend>().Any(f => f.Name.ToLower() == name.ToLower()))
            {
                return new ValidationResult("The name must be unique.");
            }

            return ValidationResult.Success!;
        }
    }
}