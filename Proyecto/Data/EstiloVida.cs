using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class EstiloVida
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }

    // Propiedad para relación muchos a muchos con Usuario
    public List<Usuario> Usuarios { get; set; } = new();
}
