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

    public IActionResult UseRuntimeReader()
    {
        IEnumerable<Person> people = _reader.GetPeople();

        ViewData["Title"] = "Using a Runtime Reader";
        ViewData["ReaderType"] = _reader.GetType().ToString();
        return View("Index", people);
    }
}