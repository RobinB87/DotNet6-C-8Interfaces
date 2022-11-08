using Microsoft.AspNetCore.Mvc;
using PersonReader.Factory;
using PersonReader.Interface;

namespace PeopleViewer.Controllers;
public class PeopleController : Controller
{
    private ReaderFactory _factory = new ReaderFactory();
    private IConfiguration _configuration;

    public PeopleController(IConfiguration configuration)
    {
        _configuration = configuration 
            ?? throw new ArgumentNullException(nameof(configuration));
    }

    public IActionResult UseConfiguredReader()
    {
        var readerType = _configuration["PersonReaderType"];
        ViewData["Title"] = "Using Configured Reader";
        return PopulatePeopleView(readerType);
    }

    public IActionResult UseService()
    {
        ViewData["Title"] = "Using a Web Service";
        return PopulatePeopleView("Service");
    }

    public IActionResult UseCSV()
    {
        ViewData["Title"] = "Using a CSV File";
        return PopulatePeopleView("CSV");
    }

    public IActionResult UseSQL()
    {
        ViewData["Title"] = "Using a SQL Database";
        return PopulatePeopleView("SQL");
    }

    private IActionResult PopulatePeopleView(string readerType)
    {
        // so now you only care about the interface in this project
        IPersonReader reader = _factory.GetReader(readerType);
        ViewData["ReaderType"] = reader.GetType().ToString();

        // we do not care which object we have, as long as it has a GetPeople method
        // better separation of concerns and puts responsibilities where they belong
        return View("Index", reader.GetPeople());
    }
}