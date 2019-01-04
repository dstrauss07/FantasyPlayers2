﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StraussDa.ApplicationCore.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }
        public string Pos { get; set; }
        public int PosRank { get; set; }
    }
}
