﻿using System;
using System.Collections.Generic;
#nullable disable
namespace TestGitHub.Models
{
    public partial class Repartidor
    {
        public uint IdRepartidor { get; set; }
        public string NombreRepartidor { get; set; } = null!;
        public string ApellidoRepartidor { get; set; } = null!;
    }
}
