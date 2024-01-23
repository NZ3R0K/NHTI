using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SharedResources;
using ConnectionResources;

namespace HallamBellemare_TicTacToeClient
{
	public partial class ServerConnectionForm : Form
	{
		public Connection connection;

		GameListForm _gameList;
		TTTGameForm _game;

		string _ipaddress;
		string _port;
		public Player player = new Player();

		public ServerConnectionForm()
		{
			InitializeComponent();
		}

		private void ServerConnectionForm_Load(object sender, EventArgs e)
		{
			if (FileDocumenter.findFile())
            {
                try
                {
					FileDocumenter.readFile(out string ip, out string port, out Player player);

					txtbx_serverIP.Text = ip;
					txtbx_serverPort.Text = port;
					txtbx_username.Text = player.username;

					_ipaddress = ip;
					_port = port;
					this.player = player;
				}
				catch (Exception err)
                {
					MessageBox.Show(err.Message, $"Read File Error - {FileDocumenter.dirParameter + FileDocumenter.fileName}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
		}

		private void btn_quit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btn_connect_Click(object sender, EventArgs e)
		{
			string port = txtbx_serverPort.Text;
			string ip = txtbx_serverIP.Text;

			try
			{
				Random rnd = new Random();

				Player player = new Player()
				{
					TYPE = 80,
					username = txtbx_username.Text,
					id = rnd.Next(1000, 9999).ToString()
				};

				_ipaddress = ip;
				_port = port;
				this.player = player;

				connection = new Connection(ip, port, player);

				_gameList = new GameListForm(this);

				_game = new TTTGameForm(this, _gameList);

				if (chkbx_rememberInfo.Checked) SaveTextboxInfo();


				_game.Show();

				this.Hide();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}
		}

		private void validateInputs(object sender, EventArgs e)
		{
			bool serverIP = (txtbx_serverIP.Text.Length > 0) ? true : false;
			bool serverPort = (txtbx_serverPort.Text.Length > 0) ? true : false;
			bool username = (txtbx_username.Text.Length > 0) ? true : false;

			btn_connect.Enabled = (serverIP && serverPort && username) ? true : false;
		}

        private void ServerConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
				
		}
    
		public void SaveTextboxInfo()
        {
			_ipaddress = txtbx_serverIP.Text;
			_port = txtbx_serverPort.Text;

			Random rnd = new Random();

			player = new Player()
			{
				TYPE = 80,
				username = txtbx_username.Text,
				id = rnd.Next(1000, 9999).ToString()
			};

			FileDocumenter.saveFile(_ipaddress, _port, player);
		}
    }
}
