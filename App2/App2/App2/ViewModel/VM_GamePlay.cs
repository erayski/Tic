using App2.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class VM_GamePlay : BaseViewModel
    {
        private const int NUMBER_OF_SQUARES = 3;
        private string[,] GameBoard { get; set; } = new string[5, 5];

        public GameInfo EnteredInfo { get; private set; }
        public ICommand GridCellTappedCmd { get; protected set; }
        public ICommand ResetCmd { get; protected set; }


        public bool _IsPlayer1Turn  = true;
        public bool IsPlayer1Turn 
        {
            get { return _IsPlayer1Turn; }
            private set { SetProperty(ref _IsPlayer1Turn, value);OnPropertyChanged("UserTurn"); }
        
        }

        public string UserTurn
        {
            get { return IsPlayer1Turn ? EnteredInfo.Player1Name : EnteredInfo.Player2Name + " is up"; }
        }


        private string _gameboard0_0;
        private string _gameboard0_1;
        private string _gameboard0_2;
        private string _gameboard0_3;
        private string _gameboard0_4;
    
        private string _gameboard1_0;
        private string _gameboard1_1;
        private string _gameboard1_2;
        private string _gameboard1_3;
        private string _gameboard1_4;
      
        private string _gameboard2_0;
        private string _gameboard2_1;
        private string _gameboard2_2;
        private string _gameboard2_3;
        private string _gameboard2_4;

        private string _gameboard3_0;
        private string _gameboard3_1;
        private string _gameboard3_2;
        private string _gameboard3_3;
        private string _gameboard3_4;


        private string _gameboard4_0;
        private string _gameboard4_1;
        private string _gameboard4_2;
        private string _gameboard4_3;
        private string _gameboard4_4;
        //row1
        public string GameBoard0_0
        {
            get { return _gameboard0_0; }
            set { SetProperty(ref _gameboard0_0, value); }
        }

        public string GameBoard0_1
        {
            get { return _gameboard0_1; }
            set { SetProperty(ref _gameboard0_1, value); }
        }
        public string GameBoard0_2
        {
            get { return _gameboard0_2; }
            set { SetProperty(ref _gameboard0_2, value); }
        }
        public string GameBoard0_3
        {
            get { return _gameboard0_3; }
            set { SetProperty(ref _gameboard0_3, value); }
        }
        public string GameBoard0_4
        {
            get { return _gameboard0_4; }
            set { SetProperty(ref _gameboard0_4, value); }
        }


        //row 2   
        public string GameBoard1_0
        {
            get { return _gameboard1_0; }
            set { SetProperty(ref _gameboard1_0, value); }
        }
        public string GameBoard1_1
        {
            get { return _gameboard1_1; }
            set { SetProperty(ref _gameboard1_1, value); }
        }
        public string GameBoard1_2
        {
            get { return _gameboard1_2; }
            set { SetProperty(ref _gameboard1_2, value); }
        }
        public string GameBoard1_3
        {
            get { return _gameboard1_3; }
            set { SetProperty(ref _gameboard1_3, value); }
        }

        public string GameBoard1_4
        {
            get { return _gameboard1_4; }
            set { SetProperty(ref _gameboard1_4, value); }
        }

        //row 3

        public string GameBoard2_0
        {
            get { return _gameboard2_0; }
            set { SetProperty(ref _gameboard2_0, value); }
        }
        public string GameBoard2_1
        {
            get { return _gameboard2_1; }
            set { SetProperty(ref _gameboard2_1, value); }
        }
        public string GameBoard2_2
        {
            get { return _gameboard2_2; }
            set { SetProperty(ref _gameboard2_2, value); }
        }
        public string GameBoard2_3
        {
            get { return _gameboard2_3; }
            set { SetProperty(ref _gameboard2_3, value); }
        }
        public string GameBoard2_4
        {
            get { return _gameboard2_4; }
            set { SetProperty(ref _gameboard2_4, value); }
        }


        //row 4

        public string GameBoard3_0
        {
            get { return _gameboard3_0; }
            set { SetProperty(ref _gameboard3_0, value); }
        }
        public string GameBoard3_1
        {
            get { return _gameboard3_1; }
            set { SetProperty(ref _gameboard3_1, value); }
        }
        public string GameBoard3_2
        {
            get { return _gameboard3_2; }
            set { SetProperty(ref _gameboard3_2, value); }
        }
        public string GameBoard3_3
        {
            get { return _gameboard3_3; }
            set { SetProperty(ref _gameboard3_3, value); }
        }
        public string GameBoard3_4
        {
            get { return _gameboard3_4; }
            set { SetProperty(ref _gameboard3_4, value); }
        }

        //row 5

        public string GameBoard4_0
        {
            get { return _gameboard4_0; }
            set { SetProperty(ref _gameboard4_0, value); }
        }
        public string GameBoard4_1
        {
            get { return _gameboard4_1; }
            set { SetProperty(ref _gameboard4_1, value); }
        }
        public string GameBoard4_2
        {
            get { return _gameboard4_2; }
            set { SetProperty(ref _gameboard4_2, value); }
        }
        public string GameBoard4_3
        {
            get { return _gameboard4_3; }
            set { SetProperty(ref _gameboard4_3, value); }
        }
        public string GameBoard4_4
        {
            get { return _gameboard4_4; }
            set { SetProperty(ref _gameboard4_4, value); }
        }

      

        public VM_GamePlay(GameInfo enteredInfo)
        {         
            EnteredInfo = enteredInfo;     

            GridCellTappedCmd = new Command<string>((xyInfo) => { PlayAtCell(xyInfo); });
            ResetCmd = new Command(async() => 
            {

              bool shouldReset =  await Application.Current.MainPage.DisplayAlert("Reset GAME? !", "Are you sure that you want go to reset game ? ", "RESET" ,"CANCEL");
                if (shouldReset)
                    ResetGame();
            });

        }


        private void MarkBoard(int x , int y , string mark)
        {
            //  GameBoard[x, y] = mark;

            //            string propertyName = $"GameBoard{x}{y}";
            //          typeof(VM_GamePlay).GetProperty(propertyName).SetValue(this, GameBoard[x, y]);


            GameBoard[x, y] = mark;
            string propertyName = $"GameBoard{x}_{y}";
            typeof(VM_GamePlay).GetProperty(propertyName).SetValue(this, GameBoard[x, y]);

        }


        public void ResetGame()
        {
            for (int x0 = 0; x0 < 5; x0++)
            {
                for (int y0 = 0; y0 < 5; y0++)
                {
                    MarkBoard(x0, y0, "");
                }
            }
        }
        public async void PlayAtCell(string xyInfo) 
        {
            string[] xyStrArray = xyInfo.Split(',');
            int x = int.Parse(xyStrArray[0]);
            int y = int.Parse(xyStrArray[1]);

            if (!string.IsNullOrWhiteSpace(GameBoard[x, y]))
                return;


            string playerMarking = IsPlayer1Turn ? "X" : "O";
            MarkBoard(x, y, playerMarking);



            int sameInRow = 0;
            int sameInCol = 0;
            int sameDiagA = 0;
            int sameDiagB = 0;

            int markedCount = 0;
            for(int x0 = 0; x0 < 5; x0++)
            {
                for(int y0 = 0 ;y0< 5; y0++)
                {
                    if (string.IsNullOrWhiteSpace(GameBoard[x0, y0]))
                        continue;
                    markedCount++;


                    if (!GameBoard[x0, y0].Equals(playerMarking))
                        continue;

                    if (x0 == x)
                        sameInCol++;
                    if (y0 == y)
                        sameInRow++;
                    
                    
                    if (x0 == y0)
                        sameDiagA++;
                   
                    
                    if ((x0 == 0 && y0 == 2) || (x0 == 1 && y0 == 1) || (x0 == 3 && y0 == 0))
                        sameDiagB++;

                   
                    //   if (y0 == y)
                    //      sameInRow++;
                    //    if (x0 == x)
                    //       sameInCol++;
                    //    if (x0 == y0)
                    //       sameDiagA++;

                    //     if ((x0 == 0 && y0 == 2) || (x0 == 1 && y0 == 1) || (x0 == 3 && y0 == 0))

                    //  if((x0 + y0) ==(5-1))

                    // if(x0 && )


                    //if((x0==1 && y1==1 ))

                    // sameDiagB++;
                }
            }

            if(sameInRow == NUMBER_OF_SQUARES || sameInCol == NUMBER_OF_SQUARES || sameDiagA == NUMBER_OF_SQUARES || sameDiagB ==NUMBER_OF_SQUARES)

            {
                await Application.Current.MainPage.DisplayAlert("Winner!", $"{UserTurn} won!", "OK");
                ResetGame();
            }

          else   if(markedCount == 5 * 5)
            {
                await Application.Current.MainPage.DisplayAlert("Draw!", "The game will now reset", "OK");
                ResetGame();
            }



                IsPlayer1Turn = !IsPlayer1Turn;
            }
        }
}