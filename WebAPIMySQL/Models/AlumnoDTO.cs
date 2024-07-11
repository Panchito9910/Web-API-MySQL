namespace WebAPIMySQL.Models
{
    public class AlumnoDTO
    {
        public int Id_Alumno {  get; set; }
        public string Matricula { get; set; } = null!;

        public string Nombre_Alumno { get; set; } = null!;

        public string Apellido_Alumno { get; set; } = null!;

        public int Semestre_Actual { get; set; }

        public string Correo_Alumno { get; set; } = null!;
    }
}
