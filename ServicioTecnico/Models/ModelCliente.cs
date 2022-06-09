using System.ComponentModel.DataAnnotations;

namespace ServicioTecnico.Models
{
    public class ModelCliente
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Ingresar el nombre es obligatorio")]
        public string? nombre { get; set; }  //El carácter ? se usa en tipos de para indicar el valor es nulleable, osea que puede ser un numero valido o puede ser null.

        [Required(ErrorMessage = "Ingresar el domicilio es obligatorio")]
        public string? domicilio { get; set; }

        [Required(ErrorMessage = "Ingresar el telefono es obligatorio")]
        public string? telefono { get; set; }

    }
}
