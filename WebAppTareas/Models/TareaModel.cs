using System.ComponentModel.DataAnnotations;

namespace WebAppTareas.Models
{
    public class TareaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Titulo es obligatorio")]
        public string? Titulo { get; set; }


        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string? Descripcion { get; set; }


        public DateTime Fechacreacion { get; set; }


        public int Estado { get; set; }

    }


}
