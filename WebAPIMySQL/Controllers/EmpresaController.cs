using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebAPIMySQL.Models;

namespace WebAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly string _connection = @"server=localhost;port=3306;database=modelodual;uid=root;password=12345";
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<EmpresaDTO> empresas = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT id_empresa,codigo_empresa,nombre_empresa,correo_empresa FROM empresas";
                empresas = db.Query<EmpresaDTO>(sql);
            }
            return Ok(empresas);
        }
        [HttpPost]
        public IActionResult Insert(EmpresaDTO empresa)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "INSERT INTO empresas(codigo_empresa,nombre_empresa,correo_empresa)" +
                    " VALUES(@codigo_empresa,@nombre_empresa,@correo_empresa)";
                result = db.Execute(sql, empresa);
            }
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Edit(EmpresaDTO empresa)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "UPDATE empresas SET codigo_empresa=@codigo_empresa,nombre_empresa=@nombre_empresa,correo_empresa=@correo_empresa" +
                    " WHERE id_empresa=@id_empresa";
                result = db.Execute(sql, empresa);
            }
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(EmpresaDTO empresa)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "DELETE FROM empresas WHERE id_empresa=@id_empresa";
                result = db.Execute(sql, empresa);
            }
            return Ok(result);
        }
    }
}
