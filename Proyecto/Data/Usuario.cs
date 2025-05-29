using System.ComponentModel.DataAnnotations;
using Proyecto.Data;

public class Usuario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [DataType(DataType.Password)]
    public string Contrasena { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime FechaRegistro { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "El tipo de membresía es obligatorio.")]
    public string TipoMembresia { get; set; } = string.Empty; 

    [Required(ErrorMessage = "El estado es obligatorio.")]
    public string Estado { get; set; } = string.Empty; 

    //propiedades de navegacion 
    public int? ClaseId { get; set; }
    virtual public Clase? Clase { get; set; }
    public List<EstiloVida> EstilosVida { get; set; } = new();



}
