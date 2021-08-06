using EntertpriseIS.Models;
using EntertpriseIS.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace EntertpriseIS.ViewModels
{
    /// <summary>
    /// Класс представления
    /// </summary>
    public class EnterpriseDataFactoryViewModel : INotifyPropertyChanged
    {
        private EnterpriseViewModel _viewModel = null;

        private ActionCommand _manualLoadCommand = null;
        private ActionCommand _manualSaveCommand = null;

        /// <summary>
        /// Объект представления
        /// </summary>
        public EnterpriseDataFactory EnterpriseDataFactory { get; }

        /// <summary>
        /// Модель представления загруженных данных
        /// </summary>
        public EnterpriseViewModel ViewModel
        {
            get => _viewModel;
            private set
            {
                _viewModel = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ViewModel)));
                _manualSaveCommand.RaiseCanExecuteChanged();
            }
        }


        public EnterpriseDataFactoryViewModel(EnterpriseDataFactory enterpriseDataFactory)
        {
            EnterpriseDataFactory = enterpriseDataFactory;
            _manualSaveCommand = new ActionCommand(
                _ => EnterpriseDataFactory.DataService.ManualSave(ViewModel.Value as Enterprise),
                _ => EnterpriseDataFactory.DataService != null && ViewModel != null && ViewModel.Value as Enterprise != null);
            _manualLoadCommand = new ActionCommand(
                _ => ViewModel = new EnterpriseViewModel(EnterpriseDataFactory.DataService.ManualLoad()),
                _ => EnterpriseDataFactory.DataService != null);
        }


        /// <summary>
        /// Команда ручной загрузки данных
        /// </summary>
        public ICommand ManualLoadCommand => _manualLoadCommand;
        /// <summary>
        /// Команда ручного сохранения данных
        /// </summary>
        public ICommand ManualSaveCommand => _manualSaveCommand;


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
