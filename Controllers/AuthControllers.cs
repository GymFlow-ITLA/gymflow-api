using Microsoft.AspNetCore.Mvc;
using System;

namespace GymFlow.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        // Modelo simple para recibir los datos
        public class RegisterRequest
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string cedula { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string password { get; set; }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            // 1. Generar el UUID automáticamente
            Guid id = Guid.NewGuid();
            string userId = id.ToString();

            // 2. Aquí iría tu lógica de base de datos con Dapper
            // INSERT INTO users (id, first_name, last_name, cedula, email, phone, password_hash, is_verified, is_active)
            // VALUES (@userId, @first_name, @last_name, @cedula, @email, @phone, @hashedPassword, false, true);

            // 3. Generar el código OTP y guardar en 'email_verifications'
            
            return StatusCode(201, new { message = "Usuario creado. Por favor, verificar email." });
        }

        [HttpPost("verify-email")]
        public IActionResult VerifyEmail([FromBody] dynamic request)
        {
            // 1. Validar el 'code' y 'expires_at' de la tabla 'email_verifications'
            
            // 2. Si es válido, actualizar 'is_verified = true' en 'users'
            
            return Ok(new { message = "Correo verificado exitosamente." });
        }
    }
}