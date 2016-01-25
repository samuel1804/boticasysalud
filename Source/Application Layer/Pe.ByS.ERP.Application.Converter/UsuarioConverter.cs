using System;
using Pe.ByS.ERP.Application.DTO;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Application.Converter
{
    public class UsuarioConverter
    {
        public static UsuarioDto DomainToDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Username = usuario.Username,
                Email = usuario.Email,
                Estado = usuario.Estado
            };
        }

        public static Usuario DtoToDomain(UsuarioDto usuario)
        {
            string guid = Guid.NewGuid().ToString().Split('-')[0];

            return new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Estado = usuario.Estado,
                Password = guid
            };
        }
    }
}