﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class Room : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ServiceIds { get; set; }
    }
}
