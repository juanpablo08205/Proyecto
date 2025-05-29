using System.ComponentModel.DataAnnotations;

public class EstiloVida
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    public List<Usuario> Usuarios { get; set; } = new();
}
