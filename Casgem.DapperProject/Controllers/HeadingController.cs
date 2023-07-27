using Casgem.DapperProject.DAL.Entities;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Casgem.DapperProject.Controllers
{
    public class HeadingController : Controller
    {
        private readonly string _connectionString = "Server=DESKTOP-13123BI; Initial Catalog=CasgemDBDapper; Integrated Security=true;";

        public async Task<IActionResult> Index()
        {
            await using var connection = new SqlConnection(_connectionString);
            var values = await connection.QueryAsync<Headings>("Select * From Headings");

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddHeading()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddHeading(Headings headings)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"INSERT INTO Headings(HeadingName, HeadingStatus)" +
                $"VALUES ('{headings.HeadingName}', 'true')";
            await connection.QueryAsync(query);
            return RedirectToAction("Index");
        }
    }
}