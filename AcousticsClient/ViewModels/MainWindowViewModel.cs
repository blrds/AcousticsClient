using AcousticsClient.Infrastructure;
using AcousticsClient.Infrastructure.Commands;
using AcousticsClient.Models;
using AcousticsClient.Models.Base;
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
        public ObservableCollection<string> RecievrsNames { get; set; } = new ObservableCollection<string>();
        public TrulyObservableCollection<Experiment> Experiments { get; set; } = new TrulyObservableCollection<Experiment>();
        public Experiment SelectedExperiment { get; set; }
        public int SelectedIndex { get; set; }



        public MainWindowViewModel()
        {
            RecievrsNames.Add("Приемник 1");
            RecievrsNames.Add("Приемник 2");
            RecievrsNames.Add("Приемник 3");
            Experiments.Add(new Experiment("1"));
            Experiments.Add(new Experiment("2"));
            Experiments.Add(new Experiment("3"));
            Click=new LambdaCommand(OnClickExecuted,CanClickExecute);
            Experiments.CollectionItemChanged += Experiment_Changed;
            Experiments[0].Room = new Room("1", new Vector3(2, 4, 2));
            Experiments[0].Source = new Vector3(1, 0.5, 1.2);
            Experiments[0].Recievers.Add(new Reciever(new Vector3(1,1, 1.2),0.18,0.23,0.23, "Приемник 1"));
            Experiments[0].Recievers.Add(new Reciever(new Vector3(1,2, 1.2),0.24,0.3,0.3, "Приемник 2"));
            Experiments[0].Recievers.Add(new Reciever(new Vector3(1,3, 1.2),0.36,0.39,0.39, "Приемник 3"));
            Experiments[0].SelectedResiever = Experiments[0].Recievers[0];
            Experiments[0].Rev60_125 = 1.29;
            Experiments[0].Rev60_500 = 1.829;
            Experiments[0].Rev60_2000 = 2.59;
            Experiments[0].Celling = new Surface("Бетон", 0.97);
            Experiments[0].Floor = new Surface("Бетон", 0.97);
            Experiments[0].WallBackward = new Surface("Дерево", 0.85);
            Experiments[0].WallForward = new Surface("Дерево", 0.85);
            Experiments[0].WallLeft = new Surface("Дерево", 0.85);
            Experiments[0].WallRight = new Surface("Дерево", 0.85);
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
