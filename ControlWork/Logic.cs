﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
  public  class Logic
    {
        public PasswordsContext context;

        public Logic(PasswordsContext ctx)
        {
            context = ctx;
        }
    }
}
