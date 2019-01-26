using MvvmCross;
using MvvmCross.ViewModels;
using MyCalculator.Services;
using MyCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCalculator
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<ISquareRootService, SquareRootService>();
            RegisterAppStart<SquareRootViewModel>();
        }
    }
}
