using System;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationApiProject.Models;

public class AppUser : IdentityUser
{
    public string Role { get; set; }
}
