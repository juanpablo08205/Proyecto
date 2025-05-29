using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class EstiloVida
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public string? Nombre { get; set; }

    public List<Usuario> Usuarios { get; set; } = new();
}
