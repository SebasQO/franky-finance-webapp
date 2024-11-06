namespace FrankyFinance.Models
{
    public class MiembroGrupo
    {
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int GrupoId { get; set; }
        public Grupo? Grupo { get; set; }
    }
}
