using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HallamBellemare_TicTacToeClient
{
    public partial class GameListForm : Form
    {
        ServerConnectionForm _serverConnection;
        TTTGameForm _game;

        public GameListForm(ServerConnectionForm serverConnection)
        {
            _serverConnection = serverConnection;

            InitializeComponent();
        }

        private void GameListForm_Load(object sender, EventArgs e)
        {
          
        }

        private void btn_logOut_Click(object sender, EventArgs e)
        {
            _serverConnection.connection.Disconnect();

            _serverConnection.Show();
            this.Hide();
        }

        private void btn_TEMPBypass_Click(object sender, EventArgs e)
        {
            _game = new TTTGameForm(_serverConnection, this);

            _game.Show();
            this.Hide();
        }

        private void GameListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
