
using App2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using App2.View;

namespace App2.ViewModel
{
    public class VM_GameInfo
    {
        public ObservableCollection<GameInfo> GameHistory { get; set; }
        public GameInfo EnteredInfo { get; set; }

        //public ICommand GoToGame { get; set; }
        public ICommand GoTo_History { get; protected set; }

        public ICommand GoTo_GamePlay { get; protected set; }

        public VM_GameInfo()
        {
            GameHistory = new ObservableCollection<GameInfo>();

            GameHistory.Add(new GameInfo() { Player1Name = "P1", Player2Name = "P2" });
            GameHistory.Add(new GameInfo() { Player1Name = "P3", Player2Name = "P4" });

            EnteredInfo = GameHistory.LastOrDefault();

            GoTo_History = new Command(async () => { await Application.Current.MainPage.Navigation.PushAsync(new Page_History()); });
            GoTo_GamePlay = new Command(async   () => { await Application.Current.MainPage.Navigation.PushAsync(new Page_GamePlay(EnteredInfo)); });
                       
         }
    } 
}