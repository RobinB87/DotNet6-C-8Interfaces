using Microsoft.AspNetCore.Mvc;
using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.Service;
using PersonReader.SQL;

namespace PeopleViewer.Controllers;

public class PeopleController : Controller
{
    public IActionResult UseService()
    {
        var reader = new ServiceReader();
        IEnumerable<Person>? people = reader.GetPeople();

        ViewData["ReaderType"] = reader.GetType().ToString();
        ViewData["Title"] = "Using a Web Service";
        return View("Index", people);
    }

    public IActionResult UseCSV()
    {
        var reader = new CSVReader();
        IEnumerable<Person>? people = reader.GetPeople();

        ViewData["ReaderType"] = reader.GetType().ToString();
        ViewData["Title"] = "Using a CSV File";
        return View("Index", people);
    }

    public IActionResult UseSQL()
    {
        var reader = new SQLReader();
        IEnumerable<Person>? people = reader.GetPeople();

        ViewData["ReaderType"] = reader.GetType().ToString();
        ViewData["Title"] = "Using a SQL Database";
        return View("Index", people);
    }
}