using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GetDataWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecryptController : ControllerBase
    {
        private IConfiguration Configuration;
      //  GetData dt = new GetData();

        public DecryptController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

      
        [HttpGet("{userid}/{password}")]
        public IEnumerable<string> Get(string userid, string password)
        {
            GetData dt = new GetData();

            string connString = this.Configuration.GetConnectionString("dbConn");

            string data = dt.DecryptData(userid, password, connString);
            yield return data;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
