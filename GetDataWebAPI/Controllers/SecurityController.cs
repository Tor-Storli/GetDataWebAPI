using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Microsoft.Extensions.Configuration;
using GetDataWebAPI.Security;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GetDataWebAPI.Controllers
{
    public enum OperationType
    {
        UpsertUserData,
        VerifyUser
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private IConfiguration Configuration;
        //GetData dt = new GetData();

        SecurityData dt = new SecurityData();

        public SecurityController(IConfiguration _configuration)
        {
            Configuration = _configuration;

        }

        [HttpGet("{userid}/{user_key}/{text2encrypt}/encrypt")]
        public IEnumerable<string> Get(string userid, string user_key, string text2encrypt)
        {

            string connString = this.Configuration.GetConnectionString("dbConn");

            string data = dt.EncryptData(userid, user_key, text2encrypt, connString);
            yield return data;
        }

        [HttpGet("{userid}/{user_key}/decrypt")]
        public IEnumerable<string> Get(string userid, string user_key)
        {

            string connString = this.Configuration.GetConnectionString("dbConn");

            string data = dt.DecryptData( userid, user_key, connString);

            yield return data;
        }

        [HttpGet("{userid}/{password}/user")]
        public IEnumerable<string> Get(string userid, string password, int operation_type)
        {
            //operation_type = 0 - OperationType.UpsertUserData
            //operation_type = 1 - OperationType.VerifyUser


            string data = String.Empty;
            string connString = this.Configuration.GetConnectionString("dbConn");

            if (operation_type == (int)OperationType.UpsertUserData)
            {
                data = dt.Create_Update_User(userid, password, connString);
            }
            if (operation_type == (int)OperationType.VerifyUser)
            {
                data = dt.VerifyUser(userid, password, connString);
            }
            yield return data;
        }

        //[HttpGet("{userid}/{password}/upsert")]
        //public IEnumerable<string> Get(string userid, string password)  //, int operation_type)
        //{
        //    //operation_type = 0 - Create_Update_User
        //    //operation_type = 1 - VerifyUser

        //    GetData dt = new GetData();

        //    string data = String.Empty;
        //    string connString = this.Configuration.GetConnectionString("dbConn");

        //    data = dt.Create_Update_User(userid, password, connString);
          
        //    yield return data;
        //}
        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
