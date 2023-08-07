using SC.v1.Common.Common.Models;
using SC.v1.Core.DTOs.Requests;
using SC.v1.Core.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.v1.Core.Implementations.Commands
{
    public interface ISignUp
    {
        Task<ServiceResponse<SignUpResponseDto>> ExecuteAsync(SignUpRequestDto _params);
    }
}
