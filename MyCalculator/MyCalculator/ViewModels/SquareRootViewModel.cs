using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using MyCalculator.Services;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmCross.Commands;

namespace MyCalculator.ViewModels
{
    public class SquareRootViewModel : MvxViewModel
    {
        readonly ISquareRootService _squareRootService;

        public SquareRootViewModel(ISquareRootService squareRootService)
        {
            _squareRootService = squareRootService ?? throw new System.ArgumentNullException(nameof(squareRootService)); ;
            ClickCommand = new MvxCommand(click_Execute);
            ClickCommand2 = new MvxCommand(click_Execute2);
        }

        public SquareRootViewModel()
        {
            Number = 10;
        }

        private void click_Execute()
        {
            RecalculateRoot();
        }

        private void click_Execute2()
        {
            RecalculateSquare();
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _number = 16;
            _squareRoot = 4;
            _squared = 256;

        }

        private double _number;
        public double Number
        {
            get => _number;
            set
            {
                SetField(ref _number, value);

            }

        }
        private double _squareRoot;
        public double SquareRoot
        {
            get => _squareRoot;
            set
            {
                SetField(ref _squareRoot, value);
                RaisePropertyChanged(nameof(SquareRootString));
            }
        }


        private double _squared;
        public double Squared
        {
            get => _squared;
            set
            {
                SetField(ref _squared, value);
                RaisePropertyChanged(nameof(SquaredString));
            }
        }


        public string SquareRootString => SquareRoot.ToString();
        public string SquaredString => Squared.ToString();

        private void RecalculateRoot()
        {
            SquareRoot = _squareRootService.squareRoot(Number);
        }


        private void RecalculateSquare()
        {
            Squared = _squareRootService.squareIt(Number);
        }

        private MvxCommand clickCommand;
        //public MvxCommand ClickCommand => clickCommand ?? (clickCommand = new MvxCommand(() => Recalculate()));
        public MvxCommand ClickCommand { get; private set; }

        private MvxCommand clickCommand2;
        public MvxCommand ClickCommand2 { get; private set; }

        //#region INotifyPropertyChanged Implementation
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
//#endregion


    }
}
