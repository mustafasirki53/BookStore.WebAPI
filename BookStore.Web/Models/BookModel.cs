using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebAPI.Models;

public class BookModel
{
    public int BookId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    public bool IsAvailable { get; set; } = false;
}
