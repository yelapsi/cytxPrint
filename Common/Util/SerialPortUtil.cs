﻿using System;
using System.IO.Ports;
using System.Text;

namespace Maticsoft.Common.Util
{
    public class SerialPortUtil
    {

        /**
         *获取可用串口
         */
        public static String[] getAvailableSerialPort()
        {
            return SerialPort.GetPortNames();
        }

        /**
         *获取一个串口对象
         */
        public static SerialPort getSerialPort(String portName, int baudRate)
        {
            SerialPort sport = new SerialPort();
            sport.PortName = portName;
            sport.BaudRate = baudRate;

            sport.Parity = Parity.None;
            sport.DataBits = 8;
            sport.StopBits = StopBits.One;
            sport.Handshake = Handshake.None;
            sport.ReceivedBytesThreshold = 1;
            sport.ReadBufferSize = 4096;
            sport.WriteBufferSize = 4096;

            try
            {
                sport.Open();
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }

            return sport;
        }

        /**
         *读取数据
         */
        public static String readData(SerialPort sp)
        {
            try
            {
                String s = sp.ReadLine();
                byte[] data = Convert.FromBase64String(s);
                return Encoding.Unicode.GetString(data);
            }
            catch
            {
                return null;
            }
        }

        /**
         *往串口中写数据
         */
        public static Boolean writeData(SerialPort sp, byte[] wstr, int length)
        {
            try
            {
                sp.Write(wstr, 0, length);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}