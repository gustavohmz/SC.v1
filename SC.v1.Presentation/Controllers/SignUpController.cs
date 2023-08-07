using System.Net;
using Microsoft.AspNetCore.Mvc;
using SC.v1.Core.DTOs.Requests;
using SC.v1.Core.DTOs.Responses;
using SC.v1.Core.Implementations.Commands;
using SC.v1.Core.Ports;

namespace SC.v1.Presentation.Controllers
{
    /// <summary>
    /// Controlador para manejar las solicitudes relacionadas con el registro de usuarios.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpController : ControllerBase
    {
        private readonly ILogger<SignUpController> _logger;
        private readonly ISignUp _signUp;

        /// <summary>
        /// Constructor del controlador SignUpController.
        /// </summary>
        /// <param name="logger">Instancia del logger.</param>
        /// <param name="signUp">Instancia de ISignUp para el registro de usuarios.</param>
        public SignUpController(ILogger<SignUpController> logger, ISignUp signUp)
        {
            _logger = logger;
            _signUp = signUp;
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SignUp
        ///     {
        ///        "userName": "john.doe",
        ///        "password": "mysecretpassword",
        ///        "roleId": 0
        ///     }
        /// </remarks>
        /// <param name="request">Datos del nuevo usuario.</param>
        /// <returns>Detalles del usuario creado.</returns>
        /// <response code="200">Operación exitosa. Retorna los detalles del usuario creado.</response>
        /// <response code="400">Solicitud incorrecta. Puede ocurrir si falta algún dato requerido en la solicitud.</response>
        /// <response code="500">Error interno del servidor. Puede ocurrir si ocurre un error durante el proceso de creación del usuario.</response>
        [HttpPost(Name = "Crea un usuario.")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WebApiPort<SignUpResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(WebApiPort<SignUpResponseDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(WebApiPort<SignUpResponseDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SignUpUser([FromBody] SignUpRequestDto request)
        {
            var response = await _signUp.ExecuteAsync(request);
            WebApiPort<SignUpResponseDto> result = new(response);

            return StatusCode((int)result.HttpCode, result);
        }


    }
}
