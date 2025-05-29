using System.ComponentModel.DataAnnotations;

namespace Proyecto.Data
{
    public class Clase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public string? Nombre { get; set; }
       virtual public ICollection<Usuario> Usuarios { get; set; }
    }
}
