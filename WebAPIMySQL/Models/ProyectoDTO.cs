namespace WebAPIMySQL.Models
{
    public class ProyectoDTO
    {
        public int Id_Proyecto { get; set; }
        public string Codigo_Proyecto { get; set; } = null!;

        public string Nombre_Proyecto { get; set; } = null!;

        public string Codigo_Empresa { get; set; } = null!;

        public string Matricula { get; set; } = null!;

    }
}
