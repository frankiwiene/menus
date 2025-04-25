using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using menus.Models;
using System.Text.Json;


namespace menus.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient httpClient;

    public HomeController(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    [HttpGet("Home/GetPokemon/{name}")]
    public async Task<IActionResult> GetPokemon(string name)
    {
        String url = $"https://pokeapi.co/api/v2/pokemon/{name}";
        HttpResponseMessage response =
             await httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            return NotFound();
        }
        String json = await response
                           .Content
                           .ReadAsStringAsync();
        JsonDocument doc = JsonDocument
                          .Parse(json);
        Pokemon pokemon = new Pokemon
        {
            Name = doc.RootElement.GetProperty("name").GetString(),
            ImageUrl = doc
                   .RootElement
                   .GetProperty("sprites")
                   .GetProperty("front_default")
                   .GetString(),
            Types = doc.RootElement.GetProperty("types")
           .EnumerateArray()
           .Select(t => t.GetProperty("type")
                       .GetProperty("name")
                       .GetString())
                  .ToList(),
            Abilities = doc.RootElement.GetProperty("abilities")
                .EnumerateArray()
                .Select(a => a.GetProperty("ability")
                              .GetProperty("name")
                              .GetString())
                 .ToList(),
            Weight = doc.RootElement.GetProperty("weight").GetInt32(),
        };

        return View(pokemon);
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Photos()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
