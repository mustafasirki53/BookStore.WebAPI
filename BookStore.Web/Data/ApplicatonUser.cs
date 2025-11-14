using System;
using Microsoft.AspNetCore.Identity;

namespace BookStore.WebAPI.Data;

public class ApplicatonUser : IdentityUser
{
    public string UserName { get; set; } = null!;
    public string LastName { get; set;} = null!;
}
