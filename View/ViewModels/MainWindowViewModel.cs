using Caliburn.Micro;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModels
{
    public class MainWindowViewModel : Screen
    {
        private readonly ITestService _testService;

        public MainWindowViewModel(ITestService testService)
        {
            _testService = testService;
        }
    }
}
