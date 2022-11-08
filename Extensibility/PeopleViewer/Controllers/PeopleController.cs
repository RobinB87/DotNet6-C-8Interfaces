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
        ViewData["Title"] = "Using a Web Service";
        return PopulatePeopleView(new ServiceReader());
    }

    public IActionResult UseCSV()
    {
        ViewData["Title"] = "Using a CSV File";
        return PopulatePeopleView(new CSVReader());
    }

    public IActionResult UseSQL()
    {
        ViewData["Title"] = "Using a SQL Database";
        return PopulatePeopleView(new SQLReader());
    }

    private IActionResult PopulatePeopleView(IPersonReader reader)
    {
        ViewData["ReaderType"] = reader.GetType().ToString();
        return View("Index", reader.GetPeople());
    }
}