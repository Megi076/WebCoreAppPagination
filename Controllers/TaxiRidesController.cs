/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace WebCoreAppPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiRides : ControllerBase
    {
        private IConfiguration _configuration;
        public TaxiRides(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetTaxiRides")]

    }
} 


private IConfiguration _configuration;
public CustomersController(IConfiguration configuration)
{
    _configuration = configuration;
}

[HttpGet]
[Route("GetCustomers")]

public JsonResult GetCustomers()
{
    string query = "select * from dbo.Customers";
    DataTable table = new DataTable();
    string sqlDataSource = _configuration.GetConnectionString("CustomersDB");
    SqlDataReader myReader;
    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
    {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        {
            myReader = myCommand.ExecuteReader();
            table.Load(myReader);
            myReader.Close();
            myCon.Close();
        }
    }

    return new JsonResult(table);
}

    }*/


using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiRidesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TaxiRidesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetTaxiRides2")]
        public JsonResult GetTaxiRides()
        {
            string query = "select * from dbo.TaxiRides2";
            DataTable table = new DataTable();

            // Ensure the connection string is retrieved properly
            string sqlDataSource = _configuration.GetConnectionString("TaxiServiceDBCon");
            if (string.IsNullOrEmpty(sqlDataSource))
            {
                throw new InvalidOperationException("Connection string 'TaxiServiceDBCon' has not been initialized.");
            }

            using SqlConnection TaxiServiceDBCon = new SqlConnection(sqlDataSource);
            TaxiServiceDBCon.Open();
            using var myCommand = new SqlCommand(query, TaxiServiceDBCon);
            using var myReader = myCommand.ExecuteReader();
            table.Load(myReader);

            return new JsonResult(table);
        }
    }
}


