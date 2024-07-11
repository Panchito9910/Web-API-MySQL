using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Configuration;
using WebAPIMySQL.Models;

namespace WebAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly string _connection = @"server=localhost;port=3306;database=modelodual;uid=root;password=12345";       
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<AlumnoDTO> alumnos = null;
            using (var db=new MySqlConnection(_connection))
            {
                var sql = "SELECT id_alumno,matricula,nombre_alumno,apellido_alumno,semestre_actual,correo_alumno FROM alumnos";
                alumnos = db.Query<AlumnoDTO>(sql);
            }
            return Ok(alumnos);
        }
        [HttpPost]
        public IActionResult Insert(AlumnoDTO alumno)
        {
            int result=0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "INSERT INTO alumnos(matricula,nombre_alumno,apellido_alumno,semestre_actual,correo_alumno)"+
                    " VALUES(@matricula,@nombre_alumno,@apellido_alumno,@semestre_actual,@correo_alumno)";
                result = db.Execute(sql,alumno);
            }
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Edit(AlumnoDTO alumno)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "UPDATE alumnos SET matricula=@matricula,nombre_alumno=@nombre_alumno,apellido_alumno=@apellido_alumno,semestre_actual=@semestre_actual,correo_alumno=@correo_alumno" +
                    " WHERE id_alumno=@id_alumno";
                result = db.Execute(sql, alumno);
            }
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(AlumnoDTO alumno)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "DELETE FROM alumnos WHERE id_alumno=@id_alumno";
                result = db.Execute(sql, alumno);
            }
            return Ok(result);
        }
    }
}
