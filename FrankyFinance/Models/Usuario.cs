using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FrankyFinance.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 12 caracteres.")]
        public string? Contrasena { get; set; }
        public ICollection<Grupo>? Grupos { get; set; } = new List<Grupo>();
    }
}
