using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IConfiguration configuration;

        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: Book
        public IActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DevConnection"))) {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("BookViewAll", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.Fill(dataTable);
            }
            return View(dataTable);
        }

        // GET: Book/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            BookViewModel bookViewModel = new BookViewModel {
                Title = "",
                Author = ""
            };
            return View(bookViewModel);
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Author,Price")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("BookAdd", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("Id", bookViewModel.Id);
                    sqlCmd.Parameters.AddWithValue("Title", bookViewModel.Title);
                    sqlCmd.Parameters.AddWithValue("Author", bookViewModel.Author);
                    sqlCmd.Parameters.AddWithValue("Price", bookViewModel.Price);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            return View(bookViewModel);
        }

        // GET: Book/Edit/5
        public IActionResult Edit(int? id)
        {
            BookViewModel bookViewModel = new BookViewModel
            {
                Title = "",
                Author = ""
            };
            if (id == null)
            {
                return NotFound();
            }
            bookViewModel = FetchBookById(id);
            return View(bookViewModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Author,Price")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("BookAddOrEdit", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("Id", bookViewModel.Id);
                    sqlCmd.Parameters.AddWithValue("Title", bookViewModel.Title);
                    sqlCmd.Parameters.AddWithValue("Author", bookViewModel.Author);
                    sqlCmd.Parameters.AddWithValue("Price", bookViewModel.Price);
                }
                return RedirectToAction("Index");
            }
            return View(bookViewModel);
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BookViewModel bookViewModel = FetchBookById(id);
            return View(bookViewModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DevConnection"))) {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("BookDeleteById", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("Id", id);
                sqlCmd.ExecuteNonQuery();
            }
                return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public BookViewModel FetchBookById(int? id) {
            BookViewModel bookViewModel = new BookViewModel
            {
                Title = "",
                Author = ""
            };
            using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DevConnection"))) {
                DataTable dataTable = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("BookViewById", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("Id", id);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count==1) {
                    bookViewModel.Id = (int)dataTable.Rows[0]["Id"];
                    bookViewModel.Title = (string)dataTable.Rows[0]["Title"];
                    bookViewModel.Author = (string)dataTable.Rows[0]["Author"];
                    bookViewModel.Price = (int)dataTable.Rows[0]["Price"];
                }
                return bookViewModel;
            }
        }

        
    }
}
