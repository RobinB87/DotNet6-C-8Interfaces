using Microsoft.AspNetCore.Mvc;
using PersonReader.Interface;

namespace PeopleViewer.Controllers;

public class PeopleController : Controller
{
    private readonly IPersonReader _reader;
    public PeopleController(IPersonReader reader)
    {
        _reader = reader ?? 
            throw new ArgumentNullException(nameof(reader));
    }

    public IActionResult UseService()
    {
        IEnumerable<Person>? people = _reader.GetPeople();
        
        ViewData["ReaderType"] = _reader.GetType().ToString();
        ViewData["Title"] = "Using a Web Service";
        return View("Index", people);
    }

    public IActionResult UseCSV()
    {
        ViewData["Title"] = "Using a CSV File";
        return View("Index", new List<Person>());
    }

    public IActionResult UseSQL()
    {
        ViewData["Title"] = "Using a SQL Database";
        return View("Index", new List<Person>());
    }
}
