using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebAPI.Models;

public class BookLendingModel
{
    public int BookLendingId { get; set; }
    public int BookId { get; set; }
    [Required]
    public string BorrowerName { get; set; }
    public DateTime LendingDate { get; set; } = DateTime.Now;
}
