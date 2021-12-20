using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaRedarbor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaRedarbor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Database db = new Database();

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string query = "select * from Employee";
            DataTable dt = db.GetData(query);
            var result = new ObjectResult(dt);
            return (IEnumerable<string>)result;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            var serialize = JsonConvert.SerializeObject(value);
            JObject jobject = JObject.Parse(serialize);
            string query = "insert into Role (Description) values (@Description);";
            var parameters = new IDataParameter[]
            {
                new SqlParameter("@Description", jobject["Description"].ToString())
            };
            if (db.ExecuteData(query, parameters) > 0)
            {
                return "Saved";
            }
            else
            {
                return "something went wrong";
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
