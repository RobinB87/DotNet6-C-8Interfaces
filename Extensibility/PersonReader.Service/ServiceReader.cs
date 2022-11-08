using PersonReader.Interface;
using System.Net;
using System.Text.Json;

namespace PersonReader.Service;
public class ServiceReader : IPersonReader
{
    // ignore obsolete for purpose of this course
    WebClient _client = new WebClient();
    string _baseUri = "http://localhost:9874";
    JsonSerializerOptions _options = new JsonSerializerOptions 
        { PropertyNameCaseInsensitive = true };

    public IEnumerable<Person>? GetPeople()
    {
        var address = $"{_baseUri}/people";
        var reply = _client.DownloadString(address);
        return JsonSerializer.Deserialize<IEnumerable<Person>>(
            reply, _options);
    }

    public Person? GetPerson(int id)
    {
        var address = $"{_baseUri}/people/{id}";
        var reply = _client.DownloadString(address);
        return JsonSerializer.Deserialize<Person>(
            reply, _options);
    }
}