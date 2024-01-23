using SharedResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HallamBellemare_TicTacToeClient
{
    public partial class TTTGameForm : Form
    {
        ServerConnectionForm _serverConnection;
        GameListForm _gameList;

        List<Button> gameButtons = new List<Button>();

        /// <summary>
        /// Set to false if the client is trying to go back one page
        /// </summary>
        bool _closeApplication = true;

        /// <summary>
        /// What role this client has taken - X or O for players, S for Spectator
        /// </summary>
        char _clientRole = 'E';

        /// <summary>
        /// Is true if the game is closing / ending
        /// </summary>
        bool _exit = false;

        Thread gameThread;

        public TTTGameForm(ServerConnectionForm serverConnection, GameListForm gameList)
        {
            _serverConnection = serverConnection;
            _gameList = gameList;

            InitializeComponent();

            lbl_clientName.Text = "You: " + _serverConnection.player.username;

            #region Add all buttons to a list for easy iteration
            gameButtons.Add(btn_TTTSlot0);
            gameButtons.Add(btn_TTTSlot1);
            gameButtons.Add(btn_TTTSlot2);
            gameButtons.Add(btn_TTTSlot3);
            gameButtons.Add(btn_TTTSlot4);
            gameButtons.Add(btn_TTTSlot5);
            gameButtons.Add(btn_TTTSlot6);
            gameButtons.Add(btn_TTTSlot7);
            gameButtons.Add(btn_TTTSlot8);
            #endregion Add all buttons to a list for easy iteration

            gameThread = new Thread(RecieveInformation);
            gameThread.Start();
        }

        private void TTTGameForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_leaveGame_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to leave?", "Leave Game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            _serverConnection.Show();
            _closeApplication = false;
            this.Close();
        }

        private void TTTGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _exit = true;

            if (_serverConnection.connection != null)
                _serverConnection.connection.Disconnect();

            if (_closeApplication) Application.Exit();
        }

        private void TakeSlot(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;

            int location = int.Parse(selectedButton.Tag.ToString());

            if (_serverConnection.connection.WriteSteam(string.Format("T{0}{1}", location, _clientRole)))
            {
                gameButtons[location].Text = _clientRole.ToString();
                gameButtons[location].Enabled = false;
            }
        }

        void SetStatusText(string text)
        {
            tlstrplbl_gameStatus.Text = text;
        }

        void SetOpponentText(string text)
        {
            lbl_opponentName.Text = "Opponent: " + text;
        }

        void RecieveInformation()
        {
            do
            {
                //If there is no information to recieve, skip switch statement
                if (!_serverConnection.connection.ReadStream(out byte[] inStream, out char type)) continue;

                switch (type)
                {
                    //Tells client what it is and unlocks X controls
                    #region START
                    case 'S':

                        char role = (char)inStream[1];

                        _clientRole = role;

                        if (role == 'X')
                        {
                            foreach (Button button in gameButtons)
                            {
                                if (button.Text.ToString() == string.Empty)
                                    button.InvokeEx(b => b.Enabled = true);
                            }
                        }

                        SetStatusText("Waiting for X");

                        Console.WriteLine("Recieved START");

                        break;
                    #endregion START

                    //Recieve board information
                    #region BOARD
                    case 'B':

                        BoardState board = inStream.BoardFromBytes();

                        Console.WriteLine(board.currentTurn);

                        Console.WriteLine($"Recieve BOARD:" +
                            $"\n{board.bSpace1}{board.bSpace2}{board.bSpace3}" +
                            $"\n{board.bSpace4}{board.bSpace5}{board.bSpace6}" +
                            $"\n{board.bSpace7}{board.bSpace8}{board.bSpace9}");

                        break;
                    #endregion BOARD

                    //Recieve player data
                    #region PLAYER
                    case 'P':

                        Player opponent = inStream.PlayerfromBytes();

                        SetOpponentText(opponent.username);

                        break;
                    #endregion PLAYER

                    //Recieve conformation on taking a spot
                    #region TAKE
                    case 'T':

                        int space = (int)char.GetNumericValue((char)inStream[1]);
                        char takeRole = (char)inStream[2];

                        //Set the text of the taken slot to the taking role
                        gameButtons[space].InvokeEx(b => b.Text = takeRole.ToString());

                        //If the taking role is this client
                        if (takeRole == _clientRole)
                        {
                            //Disable every button
                            foreach (Button button in gameButtons)
                                button.InvokeEx(b => b.Enabled = false);

                        }
                        else
                        {
                            Thread.Sleep(500);

                            //Turn on buttons that are not taken
                            foreach (Button button in gameButtons)
                            {
                                if (button.Text.ToString() == string.Empty)
                                    button.InvokeEx(b => b.Enabled = true);
                            }
                        }

                        //Switch play status to other player
                        switch(takeRole)
                        {
                            case 'X':

                                SetStatusText("Waiting for O");
                                break;

                            case 'O':

                                SetStatusText("Waiting for X");
                                break;
                        }

                        Console.WriteLine("Recieved TAKE CONFORMATION");

                        break;
                    #endregion TAKE

                    //Tells client to wait for another player
                    #region WAIT
                    case 'W':

                        SetStatusText("Waiting for another Player...");

                        Console.WriteLine("Recieved WAIT");

                        break;
                    #endregion WAIT

                    //Recieve conformation of game finish
                    #region FINISH
                    case 'F':

                        Console.WriteLine("Recieved FINISH");

                        foreach (Button button in gameButtons)
                            button.InvokeEx(b => b.Enabled = false);

                        char winnerRole = (char)inStream[1];
                        DialogResult result;

                        if (winnerRole != 'N')
                        {
                            SetStatusText($"{winnerRole} Wins the Game");
                            result = MessageBox.Show($"{winnerRole} Has Won!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            SetStatusText($"The game ends in a Tie!");
                            result = MessageBox.Show($"The game ends in a Tie!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (result == DialogResult.OK) return;

                        break;
                    #endregion FINISH

                    #region DEFAULT
                    default:

                        char eCode = (char)inStream[0];

                        Console.WriteLine($"{eCode} Recieved: \nWe got some info from the server and have no idea what to do with it...");

                        break;
                        #endregion DEFAULT
                }
            }
            while (!_exit);

            Console.WriteLine("Ending Thread");
        }
    }
}
