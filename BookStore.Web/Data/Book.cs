using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebAPI.Data;

public class Book
{
    [Key]
    public int BookId { get; set; }
    [Required]
    [MaxLength(500)]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    public bool IsAvailable { get; set; } = false;
    public ICollection<BookLending> BookLendings { get; set; }
}
