using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.WebAPI.Data;

public class BookLending
{
    [Key]
    public int BookLendingId { get; set; }
    [ForeignKey("Book")]
    public int BookId { get; set; }
    [Required]
    [MaxLength(200)]
    public string BorrowerName { get; set; }
    public DateTime LendingDate { get; set; } = DateTime.Now;
    
}
