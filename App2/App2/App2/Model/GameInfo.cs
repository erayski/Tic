using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
     public class GameInfo : INotifyPropertyChanged
    {
        private string player1Name;
        
        public string Player1Name
        {
            get { return player1Name; }
            set { player1Name = value; OnPropertyChaneged(); }
        }
        private string player2Name;

        public string Player2Name
        {
            get { return player2Name; }
            set { player2Name = value; OnPropertyChaneged(); }
        }


        public bool HasPlayer1Won { get; set; }

        //<summary>
        private int player1MovieCount;

        public int Player1MoveCount
        {
            get { return player1MovieCount; }
            set { player1MovieCount = value; OnPropertyChaneged(); }
        }
      
        
        private int player2MoveCount;

        public int Player2MoveCount
        {
            get { return player2MoveCount; }
            set { player2MoveCount = value; OnPropertyChaneged(); }
        }

        private DateTime savedateTime;

        public DateTime SaveDateTime
        {
            get { return savedateTime; }
            set { savedateTime = value; OnPropertyChaneged(); }
        }

        public string Str_Title { get { return string.Format("{0} vs. {1}", Player1Name, Player2Name); } }
        public string Str_Winner { get { return string.Format("{0} won in {1} moves", 
            HasPlayer1Won ? Player1Name: Player2Name,
            HasPlayer1Won ? Player1MoveCount: Player2MoveCount); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChaneged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
