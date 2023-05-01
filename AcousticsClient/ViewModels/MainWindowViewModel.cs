using AcousticsClient.Infrastructure;
using AcousticsClient.Infrastructure.Commands;
using AcousticsClient.Models;
using AcousticsClient.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AcousticsClient.ViewModels
{
    internal class MainWindowViewModel:ViewModel
    {
        public TrulyObservableCollection<Experiment> Experiments { get; set; } = new TrulyObservableCollection<Experiment>();
        public Experiment SelectedExperiment { get; set; }
        public int SelectedIndex { get; set; }


        public MainWindowViewModel()
        {
            Experiments.Add(new Experiment("1"));
            Experiments.Add(new Experiment("2"));
            Experiments.Add(new Experiment("3"));
            Click=new LambdaCommand(OnClickExecuted,CanClickExecute);
            Experiments.CollectionItemChanged += Experiment_Changed;
        }
        public ICommand Click { get; }
        private bool CanClickExecute(object p) => true;
        private void OnClickExecuted(object p)
        {
            OnPropertyChanged("SelectedIndex");
        }
        void Experiment_Changed(object sender, PropertyChangedEventArgs e)
        {
            int oldIndex = SelectedIndex;
            SelectedIndex = SelectedIndex == 0 ? SelectedIndex + 1 : SelectedIndex - 1;
            OnPropertyChanged("SelectedIndex");
            SelectedIndex = oldIndex;
            OnPropertyChanged("SelectedIndex");

        }
    }
}
