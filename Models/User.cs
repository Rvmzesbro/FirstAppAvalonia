﻿using System;
using System.Collections.Generic;

namespace FirstAppAvalonia.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
