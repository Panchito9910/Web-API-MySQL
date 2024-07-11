namespace WebAPIMySQL.Models
{
    public class EmpresaDTO
    {
        public int Id_Empresa { get; set; }
        public string Codigo_Empresa { get; set; } = null!;

        public string Nombre_Empresa { get; set; } = null!;

        public string Correo_Empresa { get; set; } = null!;
    }
}
