using System;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using TipCalc.Core.Models;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        readonly ICalculationService _calculationService;

        public TipViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _subTotal = 100;
            _generosity = 10;

            Recalculate();
        }

        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                // _subTotal = value;
                // RaisePropertyChanged(() => SubTotal);
                // これの代わりとして、SetPropertyを使うこと
                // 値に変化があったときのみRaisePropertyChangedを投げるようになる
                SetProperty<Double>(ref _subTotal, value);
                Recalculate();
            }
        }

        private int _generosity;
        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);

                Recalculate();
            }
        }

        private double _tip;
        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private Store _store = new Store();
        public Store Store
        {
            get { return _store; }
            set { SetProperty(ref _store, value); }
        }

        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }
    }
}
