using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using WebAPIMySQL.Models;

namespace WebAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly string _connection = @"server=localhost;port=3306;database=modelodual;uid=root;password=12345";
        [HttpGet]     
        public IActionResult Get()
        {
            IEnumerable<ProyectoDTO> proyectos = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT id_proyecto,codigo_proyecto,nombre_proyecto,codigo_empresa,matricula FROM proyectos";
                proyectos = db.Query<ProyectoDTO>(sql);
            }
            return Ok(proyectos);
        }
        [HttpPost]
        public IActionResult Insert(ProyectoDTO proyecto)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "INSERT INTO proyectos(codigo_proyecto,nombre_proyecto,codigo_empresa,matricula)" +
                    " VALUES(@codigo_proyecto,@nombre_proyecto,@codigo_empresa,@matricula)";
                result = db.Execute(sql, proyecto);
            }
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Edit(ProyectoDTO proyecto)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "UPDATE proyectos" +
                    " SET codigo_proyecto=@codigo_proyecto,nombre_proyecto=@nombre_proyecto," +
                    " codigo_empresa=@codigo_empresa,matricula=@matricula" +
                    " WHERE id_proyecto=@id_proyecto";
                result = db.Execute(sql, proyecto);
            }
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(ProyectoDTO proyecto)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "DELETE FROM proyectos WHERE id_proyecto=@id_proyecto";
                result = db.Execute(sql, proyecto);
            }
            return Ok(result);
        }
    }
}
