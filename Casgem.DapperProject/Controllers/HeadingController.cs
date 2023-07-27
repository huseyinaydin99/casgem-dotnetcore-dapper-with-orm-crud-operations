using Casgem.DapperProject.DAL.Entities;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Casgem.DapperProject.Controllers
{
    public class HeadingController : Controller
    {
        private readonly string _connectionString = "Server=DESKTOP-13123BI; Initial Catalog=CasgemDBDapper; Integrated Security=true;";

        [HttpGet]
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
                $"VALUES ('{headings.HeadingName}', '{headings.HeadingStatus}')";
            await connection.QueryAsync(query);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteHeading(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync($"Delete From Headings Where HeadingId = {id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateHeading(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var values = await connection.QueryFirstAsync<Headings>($"Select * From Headings Where HeadingId = {id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHeading(Headings headings)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"UPDATE Headings SET HeadingName='{headings.HeadingName}', HeadingStatus='{headings.HeadingStatus}' Where HeadingId = '{headings.HeadingId}'";
            await connection.QueryAsync(query);
            return RedirectToAction("Index");
        }
    }
}