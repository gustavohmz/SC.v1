using AutoMapper;
using Microsoft.Extensions.Localization;
using SC.v1.Common.Common.ErrorHandling;
using SC.v1.Common.Common.Localization;
using SC.v1.Common.Common.Models;
using SC.v1.Core.DTOs.Requests;
using SC.v1.Core.DTOs.Responses;
using SC.v1.Core.Interfaces;
using SC.v1.Data.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SC.v1.Core.Implementations.Commands
{
    public class SignUp : ISignUp
    {
        private readonly IUserRepository _userRepository;
        private readonly IStringLocalizer<ServiceResources> _localizer;
        private readonly IMapper _mapper;

        public SignUp(IUserRepository userRepository, IMapper mapper,
              IStringLocalizer<ServiceResources> localizer)
        {
            _userRepository = userRepository;
             _localizer = localizer;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SignUpResponseDto>> ExecuteAsync(SignUpRequestDto request)
        {
            ServiceResponse<SignUpResponseDto> response = new ServiceResponse<SignUpResponseDto>();

            try
            {
                // Validar que se proporcionen los datos requeridos
                if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password) || request.RoleId == 0)
                {
                    response.HttpCode = HttpStatusCode.Conflict;
                    throw new ValidationException("signup_data_required");
                }

                // Validar que el usuario no exista previamente
                var existingUser = await _userRepository.GetUserByUsername(request.UserName);
                if (existingUser != null)
                {
                    response.HttpCode = HttpStatusCode.Conflict;
                    throw new ValidationException("signup_user_exists");
                }

                // Hash de la contraseña usando BCrypt
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                var newUser = new User
                {
                    UserName = request.UserName,
                    PasswordHash = passwordHash,
                    RoleId = request.RoleId
                };

                // Guardar el nuevo usuario en la base de datos
                await _userRepository.AddAsync(newUser);

                // Construir la respuesta
                var res = new SignUpResponseDto
                {
                    UserId = newUser.UserId,
                    UserName = newUser.UserName,
                    RoleId = newUser.RoleId
                };

                response.Data = res;
            }
            catch (Exception ex)
            {
                //  Error handling
                response.HttpCode = HttpStatusCode.InternalServerError;
                response.Errors = ErrorMessage.CreateErrorMessage("signup_error", "SignUp Error", ex.Source ?? "", ex.Message, _localizer);
            }

            return response;
        }
    }
}
