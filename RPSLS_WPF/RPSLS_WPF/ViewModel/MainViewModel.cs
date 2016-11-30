using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using RPSLS_WPF.RPSLSService;

namespace RPSLS_WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _active;
        private string _username;
        private Result _result;
        private readonly RPSLSService.IRPSLSService _service;

        public ICommand RPSLSCommand { get; set; }

        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged("UserName");
            }
        }

        public Result Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged("Result");
            }
        }

        public MainViewModel()
        {
            _service = new RPSLSServiceClient();
            _active = false;
            RPSLSCommand = new RelayCommand<Symbol>(SendSymbol, CanSendSymbol);
        }

        public void SendSymbol(Symbol symbol)
        {
            _active = true;
            Result = _service.SendMove(_username, symbol);
            _active = false;
        }

        public bool CanSendSymbol(Symbol symbol)
        {
            return !_active && !string.IsNullOrEmpty(_username);
        }
    }
}