namespace ProyectoProgra6_Assets.ModelsDTOs
{
    public class UsuarioPostDTO
    {
        public int UsuarioId { get; set; }

        public string? Nombre { get; set; } 

        public string? Apellido { get; set; } 

        public int? Cedula { get; set; } 

        public string? Telefono { get; set; } 

        public string? CorreoElectronico { get; set; }

      //public string? Contrasennia { get; set; }

        public int RolId { get; set; }
    }
}
