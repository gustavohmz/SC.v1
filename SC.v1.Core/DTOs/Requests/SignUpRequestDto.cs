using SC.v1.Data.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace SC.v1.Core.DTOs.Requests
{
    public class SignUpRequestDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
