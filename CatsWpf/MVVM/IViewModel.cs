﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsWpf.MVVM
{
    public interface IViewModel
    {
        Action Close { get; set; }
    }
}
