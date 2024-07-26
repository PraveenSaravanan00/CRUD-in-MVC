using System;
using System.Collections.Generic;

namespace CRUDApplication.Models;

public partial class Userlistdatum
{
    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int Salary { get; set; }

    public string Gender { get; set; } = null!;

    public int Userid { get; set; }
}
