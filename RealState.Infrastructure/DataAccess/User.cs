﻿using System;
using System.Collections.Generic;

namespace RealState.Infrastructure.DataAccess
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
