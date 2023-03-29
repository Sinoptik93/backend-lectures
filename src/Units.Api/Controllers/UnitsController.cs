using System.Net;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Units.Api.Controllers;

public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; }
}

[ApiController]
[Route("units")]
public class UnitsController
{
    private static List<Unit> UnitsListDB = new List<Unit>()
    {
        new Unit
        {
            Id = 3,
            Name = "Syktyvkar-1"
        },
        new Unit
        {
            Id = 5,
            Name = "Omsk-1"
        }
    };

    [Route("all")]
    [HttpGet]
    public Unit[] GetAll()
    {
        return new[]
        {
            new Unit
            {
                Id = 3,
                Name = "Syktyvkar-1"
            },
            new Unit
            {
                Id = 5,
                Name = "Omsk-1"
            }
        };
    }

    [Route("unit/{unitId:int}")]
    [HttpGet]
    public HttpResponseMessage GetInit(int unitId)
    {
        Console.WriteLine($"unitId: {unitId}");

        var result = UnitsListDB.Find((unit => unit.Id == unitId));

        if (result == null)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        var response = new HttpResponseMessage(HttpStatusCode.OK);
        
        return response;
    }
}