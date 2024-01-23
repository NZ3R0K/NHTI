using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace SharedResources
{
    public enum STRUCT_TYPES
    {
        Player = 80,
        Message = 77,
        Game = 71,
        Board = 66
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BoardState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaceFill">Should always be '#'</param>
        /// <param name="startTurn">Should generally 'X'</param>
        public BoardState(char spaceFill, char startTurn)
        {
            TYPE = STRUCT_TYPES.Board.ToByte();
            bSpace1 = spaceFill;
            bSpace2 = spaceFill;
            bSpace3 = spaceFill;
            bSpace4 = spaceFill;
            bSpace5 = spaceFill;
            bSpace6 = spaceFill;
            bSpace7 = spaceFill;
            bSpace8 = spaceFill;
            bSpace9 = spaceFill;
            currentTurn = startTurn;
        }
        public byte TYPE;
        [MarshalAs(UnmanagedType.U1)]
        public char bSpace1;
        [MarshalAs(UnmanagedType.U1)]
        public char bSpace2;
        [MarshalAs(UnmanagedType.U1)]
        public char bSpace3;
        [MarshalAs(UnmanagedType.U1)]
        public char bSpace4;
        [MarshalAs(UnmanagedType.U1)]
        public char bSpace5;
        [MarshalAs(UnmanagedType.U1)]
        public char bSpace6;
        [MarshalAs(UnmanagedType.U1)]
        public char bSpace7;
        [MarshalAs(UnmanagedType.U1)]
        public char bSpace8;
        [MarshalAs(UnmanagedType.U1)]
        public char bSpace9;
        [MarshalAs(UnmanagedType.U1)]
        public char currentTurn;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct Player
    {
        public byte TYPE;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string username;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string id;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Game
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string id;
    }

    //https://docs.microsoft.com/en-us/dotnet/framework/network-programming/asynchronous-server-socket-example
    /// <summary>
    /// Data state object used for reading incoming data asynchronously.
    /// </summary>
    public class SocketDataObject
    {
        public const int BufferSize = 1024;

        public byte[] buffer = new byte[BufferSize];

        public Socket workSocket = null;
    }



    public static class Extensions
    {
        //https://stackoverflow.com/questions/3278827/how-to-convert-a-structure-to-a-byte-array-in-c
        public static byte[] getBytes(this Player str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public static byte[] GetBytes(this BoardState board)
        {
            int size = Marshal.SizeOf(board);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(board, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public static Player PlayerfromBytes(this byte[] arr)
        {
            Player str = new Player();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (Player)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        public static Game GamefromBytes(this byte[] arr)
        {
            Game str = new Game();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (Game)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        public static BoardState BoardFromBytes(this byte[] arr)
        {
            BoardState board = new BoardState();

            int size = Marshal.SizeOf(board);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            board = (BoardState)Marshal.PtrToStructure(ptr, board.GetType());
            Marshal.FreeHGlobal(ptr);

            return board;
        }

        /// <summary>
        /// Convert a ENUM value to a byte.
        /// </summary>
        /// <param name="type">The enum value to convert.</param>
        /// <returns>byte value for the enum type.</returns>
        public static byte ToByte(this STRUCT_TYPES type)
        {
            return (byte)type;
        }

        /// <summary>
        /// Convert a byte to its corresponding STRUCT_TYPE
        /// </summary>
        /// <param name="b">The byte to convert.</param>
        /// <returns>STRCUT_TYPE value for the byte given.</returns>
        public static STRUCT_TYPES ToStructType(this byte b)
        {
            return (STRUCT_TYPES)b;
        }

        public static byte[] ToBytes(this string s)
        {
            byte[] bytes = new byte[s.Length];
            char[] chars;

            chars = s.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                bytes[i] = (byte)chars[i];
            }

            return bytes;
        }

        public static void InvokeEx<T>(this T me, Action<T> action) where T : ISynchronizeInvoke
        {
            if (me.InvokeRequired)
            {
                me.Invoke(action, new object[] { me });
            }
            else
            {
                action(me);
            }
        }
    }

    public class TicTacMethods
    {
        //https://stackoverflow.com/questions/6803073/get-local-ip-address
        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return host.AddressList[4];
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
