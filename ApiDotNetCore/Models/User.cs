using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDotNetCore.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Имя должно быть от {2} до {1} символов.", MinimumLength = 4)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Фамилия должна быть от {2} до {1} символов.", MinimumLength = 4)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
