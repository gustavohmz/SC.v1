using SC.v1.Data.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.v1.Core.DTOs.Responses
{
    public class SignUpResponseDto
    {
       
        public int UserId { get; set; }

       
        public string? UserName { get; set; }


        public int? RoleId { get; set; }
    }
}
