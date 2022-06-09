using System.ComponentModel.DataAnnotations;

namespace ServicioTecnico.Models
{
    public class ModelServicio
    {
        public int id { get; set; }

        public int idCliente { get; set; }  

        [Required(ErrorMessage = "Ingresar el domicilio es obligatorio")]
        public string? dispositivo { get; set; }

        [Required(ErrorMessage = "Debes ingresar una descripcion del servicio")]
        public string? descripcion { get; set; }

        [Required(ErrorMessage = "Indicar el estado es obligatorio")]
        public string? estado { get; set; }

        [Required(ErrorMessage = "Ingresar la fecha es obligatorio")]
        public DateTime? fechaDeIngreso { get; set; }
    }
}
