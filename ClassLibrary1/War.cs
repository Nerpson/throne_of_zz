﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class War : EntityObject
    {
        public String Name { get; set; }

        public IEnumerable<Fight> TuVeuxQuonSeLaDonne { get; set; }
    }
}