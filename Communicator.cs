using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Практика_ООП_2
{
    using Number;
    using Polinom;
    public class Communicator
    {

        Number Curr_a = new Number();
        Number Curr_b = new Number();
        Number Curr_c = new Number();
        Number CurrX = new Number();
        uint Nosok = 1;
        string _type = "";
        Полином P = new Полином();


        static string remoteAddress = "127.0.0.1"; // хост для отправки данных
        static int remotePort = 8002; // порт для отправки данных
        static int localPort = 8001; // локальный порт для прослушивания входящих подключений

        public Communicator()
        {
            try
            {
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
                SendMessage("started"); // отправляем сообщение
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void SendMessage(string message)
        {
            UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
            try
            {
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    sender.Send(data, data.Length, remoteAddress, remotePort); // отправка
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }

        private void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(localPort); // UdpClient для получения данных
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                    string message = Encoding.Unicode.GetString(data);
                    Console.WriteLine("Полученно собщение" + message);

                    string [] arg = message.Split(';');
                    try
                    {
                        Curr_a = new Number(arg[1], arg[2]);
                        Curr_b = new Number(arg[1], arg[3]);
                        Curr_c = new Number(arg[1], arg[4]);
                        P.SetAssignment(Curr_a, Curr_b, Curr_c);

                        switch (arg[0])
                        {
                            case "1":
                                SendMessage(P.Xresult());
                                break;
                            case "2":
                                Number tempX = new Number(arg[1], arg[5]);
                                string N = P.CastomPolinom(tempX).ToString();
                                SendMessage(N);
                                break;
                            case "3":
                                SendMessage(P.ClassicPolinom());
                                break;
                            case "4":
                                SendMessage(P.CanonPolinom());
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        SendMessage("Ошибка");
                    }















                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }



















    }
}
