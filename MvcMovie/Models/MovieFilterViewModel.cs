using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models;

public class MovieFilterViewModel
{
    public List<Movie>? Movies { get; set; }
    public SelectList? Genres { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }

    // New properties for filtering by year
    public SelectList? Years { get; set; }
    public string? MovieYear { get; set; }
}