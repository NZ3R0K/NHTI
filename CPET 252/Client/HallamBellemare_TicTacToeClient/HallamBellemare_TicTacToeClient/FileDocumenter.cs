using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.AccessControl;

namespace HallamBellemare_TicTacToeClient
{
    static class FileDocumenter
    {
        public struct SaveData
        {
            public string ip { get; set; }
            public string port { get; set; }
            public string playerData { get; set; }
        }

        public struct Player
        {
            public byte TYPE { get; set; }
            public string username { get; set; }
            public string id { get; set; }
        }

        public readonly static string dirParameter = @"C:\temp\TicTacToe";
        public readonly static string fileName = @"\loginSave.txt";

        public static bool findFile()
        {
            if (!Directory.Exists(dirParameter))
            {
                var dir = Directory.CreateDirectory(dirParameter);

                dir.SetAccessControl(new DirectorySecurity(dirParameter, AccessControlSections.Owner));
            }
            if (File.Exists(dirParameter + fileName)) return true;

            return false;
        }

        public static void saveFile(string ipaddress, string port, SharedResources.Player player)
        {
            SaveData data = new SaveData { ip = ipaddress, port = port, playerData = JsonSerializer.Serialize(player.ToSavePlayer()) };

            string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions() { WriteIndented = true });

            // Save File to .txt
            FileStream fParameter = new FileStream(dirParameter + fileName, FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(jsonData);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
        }

        public static void readFile(out string ipaddress, out string port, out SharedResources.Player player)
        {
            // Save File to .txt
            FileStream fParameter = new FileStream(dirParameter + fileName, FileMode.Open);
            StreamReader m_ReaderParameter = new StreamReader(fParameter);
            string jsonString = m_ReaderParameter.ReadToEnd();
            SaveData data = JsonSerializer.Deserialize<SaveData>(jsonString);

            ipaddress = data.ip;
            port = data.port;
            player = JsonSerializer.Deserialize<Player>(data.playerData).ToServerPlayer();

            m_ReaderParameter.Close();
        }

        public static Player ToSavePlayer(this SharedResources.Player p)
        {
            return new Player { TYPE = p.TYPE, id = p.id, username = p.username };
        }

        public static SharedResources.Player ToServerPlayer(this Player p)
        {
            return new SharedResources.Player { TYPE = p.TYPE, id = p.id, username = p.username };
        }
    }
}
