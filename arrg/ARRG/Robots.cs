﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARRG_Game
{
    public class Robots : Monster
    {
        public Robots(string name, String model, int health, int power)
            : base(name,model,health, power)
        {
            
        }
    }
}