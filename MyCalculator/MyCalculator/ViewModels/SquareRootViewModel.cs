using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using MyCalculator.Services;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyCalculator.ViewModels
{
    public class SquareRootViewModel : MvxViewModel
    {
        readonly ISquareRootService _squareRootService;

        public SquareRootViewModel(ISquareRootService squareRootService)
        {
            _squareRootService = squareRootService;
        }
    

        public override async Task Initialize()
        {
            await base.Initialize();

            _number = 16;
            _squareRoot = 4;

        }

        private double _number;
        public double Number
        {
            get => _number;
            set
            {
                SetField(ref _number, value);
                SetField(ref _squareRoot, value);
                Recalculate();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
            }

        }
        private double _squareRoot;
        public double SquareRoot
        {
            get => _squareRoot; 
            set
            {
                    SetField(ref _squareRoot, value);
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SquareRoot)));
              }
        }

        private void Recalculate()
        {
            SquareRoot = _squareRootService.squareRoot(Number);
        }


        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
            

    }
}
