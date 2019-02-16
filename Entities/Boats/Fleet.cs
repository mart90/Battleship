﻿using System;
using System.Collections.Generic;

namespace MBRD.Entities
{
    class Fleet
    {
        private List<IBoat> boats;
        
        public Fleet()
        {
            boats = new List<IBoat>();
        }

        public void Add(IBoat boat)
        {
            boats.Add(boat);
        }
    }
}