using AcousticsClient.Infrastructure.Commands;
using AcousticsClient.Models.Base;
using AcousticsClient.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AcousticsClient.Models
{
    internal class Experiment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //inner data
        public string Name { get; set; } = "New Experiment";

        public Room Room { get; set; } = new Room();
        /// <summary>
        /// Coordinates of Source
        /// </summary>
        public Vector3 Source { get; set; } = new Vector3();
        public List<Reciever> Recievers { get; set; }=new List<Reciever>();
        public Surface WallLeft { get; set; } = new Surface();
        public Surface WallRight { get; set; }= new Surface();
        public Surface WallForward { get; set; } = new Surface();
        public Surface WallBackward { get; set; } = new Surface();
        public Surface Floor { get; set; }=new Surface();
        public Surface Celling { get; set; } = new Surface();

        public double Rev60_125 { get; set; } = 0;
        public double Rev60_500 { get; set; } = 0;
        public double Rev60_2000 { get; set; } = 0;
        public Experiment(string name) {
            Name = name;
            SearchRoom = new LambdaCommand(OnSearchRoomExecuted, CanSearchRoomExecute);
        }
        public ICommand SearchRoom { get; }
        private bool CanSearchRoomExecute(object p) => Room.Name!="";
        private void OnSearchRoomExecuted(object p)
        {
            Random r = new Random();
            Room.Proportions.X =r.NextDouble()*10;
            OnPropertyChanged("Room.Proportions.X");
            //запрос в бд на поиск по имени комнаты.
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
