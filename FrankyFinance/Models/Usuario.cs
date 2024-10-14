using System.Text.RegularExpressions;

namespace FrankyFinance.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
    }
}
