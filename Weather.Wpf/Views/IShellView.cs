﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Wpf.Views;

namespace Weather.Wpf.ViewModels
{
    public interface IShellView
    {
        ShellView GetInstance();
    }
}
