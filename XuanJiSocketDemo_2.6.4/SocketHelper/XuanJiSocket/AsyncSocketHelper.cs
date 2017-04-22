using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace XuanJiSocket
{
    /// <summary>
    /// ClassName 玄机SocketHelper 
    /// Coding By 君临
    /// </summary>
    public class AsyncSocketHelper
    {
        #region 推送器 加密
        public delegate void PushSockets(Sockets sockets);
        public static PushSockets pushSockets;
        /// <summary>
        /// 数据DES加密
        /// </summary>
        public class Encrypt
        {
            private byte[] iba_mIV = new byte[8];  //向量
            private byte[] iba_mKey = new byte[8]; //密钥
            private DESCryptoServiceProvider io_DES = new DESCryptoServiceProvider();

            public Encrypt()
            {
                this.iba_mKey[0] = 0x95;
                this.iba_mKey[1] = 0xc4;
                this.iba_mKey[2] = 0xf6;
                this.iba_mKey[3] = 0x49;
                this.iba_mKey[4] = 0xac;
                this.iba_mKey[5] = 0x61;
                this.iba_mKey[6] = 0xa3;
                this.iba_mKey[7] = 0xe2;
                this.iba_mIV[0] = 0xf9;
                this.iba_mIV[1] = 0x6a;
                this.iba_mIV[2] = 0x65;
                this.iba_mIV[3] = 0xb8;
                this.iba_mIV[4] = 0x4a;
                this.iba_mIV[5] = 0x23;
                this.iba_mIV[6] = 0xfe;
                this.iba_mIV[7] = 0xc6;
                this.io_DES.Key = this.iba_mKey;
                this.io_DES.IV = this.iba_mIV;
            }
            /// <summary>
            /// 初始化加密向量与密钥 长度为8
            /// </summary>
            /// <param name="iba_mIV">向量</param>
            /// <param name="iba_mKey">密钥</param>
            public Encrypt(byte[] iba_mIV, byte[] iba_mKey)
            {
                this.io_DES.IV = iba_mIV;
                this.io_DES.Key = iba_mKey;
            }
            /// <summary>
            /// 解密
            /// </summary>
            /// <param name="as_Data"></param>
            /// <returns></returns>
            public string doDecrypt(string as_Data)
            {
                ICryptoTransform lo_ICT = this.io_DES.CreateDecryptor(this.io_DES.Key, this.io_DES.IV);
                try
                {
                    byte[] lba_bufIn = this.FromHexString(as_Data);//Encoding.UTF8.GetString(Convert.FromBase64String(
                    byte[] lba_bufOut = lo_ICT.TransformFinalBlock(lba_bufIn, 0, lba_bufIn.Length);
                    return Encoding.UTF8.GetString(lba_bufOut);
                }
                catch
                {
                    return as_Data;
                }
            }
            /// <summary>
            /// 加密
            /// </summary>
            /// <param name="as_Data"></param>
            /// <returns></returns>
            public string doEncrypt(string as_Data)
            {
                ICryptoTransform lo_ICT = this.io_DES.CreateEncryptor(this.io_DES.Key, this.io_DES.IV);
                try
                {
                    byte[] lba_bufIn = Encoding.UTF8.GetBytes(as_Data);
                    byte[] lba_bufOut = lo_ICT.TransformFinalBlock(lba_bufIn, 0, lba_bufIn.Length);
                    return GetHexString(lba_bufOut);//Convert.ToBase64String(Encoding.UTF8.GetBytes();
                }
                catch
                {
                    return "";
                }
            }
            /// <summary>
            /// 转换2进制
            /// </summary>
            /// <param name="as_value"></param>
            /// <returns></returns>
            private byte[] FromHexString(string as_value)
            {
                byte[] lba_buf = new byte[Convert.ToInt32((int)(as_value.Length / 2))];
                for (int li_i = 0; li_i < lba_buf.Length; li_i++)
                {
                    lba_buf[li_i] = Convert.ToByte(as_value.Substring(li_i * 2, 2), 0x10);
                }
                return lba_buf;
            }
            /// <summary>
            /// 字节转字符串
            /// </summary>
            /// <param name="aba_buf"></param>
            /// <returns></returns>
            private string GetHexString(byte[] aba_buf)
            {
                StringBuilder lsb_value = new StringBuilder();
                foreach (byte lb_byte in aba_buf)
                {
                    lsb_value.Append(Convert.ToString(lb_byte, 0x10).PadLeft(2, '0'));
                }
                return lsb_value.ToString();
            }
        }
        #endregion
        public class TcpAsyncServer
        {
            TcpListener Listener;
            IPEndPoint LocalPoint;
            IPAddress Localadd;
            Semaphore semap = new Semaphore(100, 1000);
            int Port;
            //public List<AsyncBuffer> ClientList = new List<AsyncBuffer>();
            public TcpAsyncServer(int port)
            {
                Port = port;
                Listener = new TcpListener(Port);
            }
            public TcpAsyncServer(IPEndPoint localPoint)
            {
                LocalPoint = localPoint;
                Listener = new TcpListener(LocalPoint);
            }
            public TcpAsyncServer(IPAddress localadd, int port)
            {
                Localadd = localadd;
                Port = port;
                Listener = new TcpListener(localadd, port);
            }
            public void Start()
            {
                Listener.Start();
                Listener.BeginAcceptTcpClient(new AsyncCallback(AsyncAccept), Listener);
                //ThreadPool.QueueUserWorkItem(o =>
                //{
                //    while (true)
                //    {

                //    }
                //});



            }
            public void StartBackLog(int BackLog)
            {
                Listener.Start(BackLog);
            }

            byte[] SendBuffer;
            byte[] RevBuffer = new byte[8 * 1024];
            IPEndPoint ep;
            private void AsyncAccept(IAsyncResult irs)
            {
                //接收传入的客户端
                TcpClient client = Listener.EndAcceptTcpClient(irs);
                semap.WaitOne();
                NetworkStream nStream = client.GetStream();
                nStream.BeginRead(RevBuffer, 0, RevBuffer.Length, new AsyncCallback(AsyncReader), nStream);
                ep = client.Client.RemoteEndPoint as IPEndPoint;

                semap.Release();
                Listener.BeginAcceptTcpClient(new AsyncCallback(AsyncAccept), Listener);
            }
            public void SendData(string Data)
            {
                SendBuffer = Encoding.UTF8.GetBytes(Data);


            }
            private void AsyncReader(IAsyncResult irs)
            {
                using (NetworkStream ns = irs.AsyncState as NetworkStream)
                {
                    int offset = ns.EndRead(irs);
                    byte[] buffer = new byte[offset];
                    Array.Copy(RevBuffer, buffer, offset);
                    string str = Encoding.UTF8.GetString(buffer);

                }
                //推送信息
            }
        }
        public class TcpAsyncClient
        {
            TcpClient Client;
            IPAddress Ipaddress; int Port;
            IPEndPoint ip;
            NetworkStream nStream;
            byte[] SendBuffer;
            byte[] RevBuffer = new byte[8 * 1024];
            public TcpAsyncClient(string ipadd, int port)
            {
                Ipaddress = IPAddress.Parse(ipadd);
                Port = port;
                ip = new IPEndPoint(Ipaddress, Port);
                Client = new TcpClient();//new TcpAsyncClient(Ipaddress,Port);


            }
            public TcpAsyncClient(IPAddress ipadd, int port)
            {
                Ipaddress = ipadd;
                Port = port;
                ip = new IPEndPoint(Ipaddress, Port);

            }
            public void Connect()
            {
                Client.Connect(ip);
                nStream = Client.GetStream();
                nStream.BeginRead(RevBuffer, 0, RevBuffer.Length, new AsyncCallback(AsyncEndReader), nStream);
            }
            public void Send(string SendData)
            {
                SendBuffer = Encoding.UTF8.GetBytes(SendData);
                nStream = Client.GetStream();
                nStream.Write(SendBuffer, 0, SendBuffer.Length);
            }
            private void AsyncEndReader(IAsyncResult ir)
            {
                NetworkStream ns = ir.AsyncState as NetworkStream;
                if (ns.CanRead)
                {
                    int offset = ns.EndRead(ir);
                    byte[] tbuffer = new byte[offset];
                    Array.Copy(RevBuffer, tbuffer, offset);
                    //消息推送

                }
            }
            public NetworkStream GetStream()
            {
                return Client.GetStream();
            }
            private void AsyncEndConnect(IAsyncResult ir)
            {
                TcpClient client = (TcpClient)ir.AsyncState;
                client.EndConnect(ir);
                //连接成功
                NetworkStream ns = client.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes("客户端连接.." + DateTime.Now);
                ns.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(AsyncEndWrite), ns);
            }
            private void AsyncEndWrite(IAsyncResult ir)
            {
                NetworkStream ns = ir.AsyncState as NetworkStream;
                ns.EndWrite(ir);
                while (true)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes("客户端连接.." + DateTime.Now);
                    ns.Write(buffer, 0, buffer.Length);
                    Thread.Sleep(1000);
                }
            }
        }

        /// <summary>
        /// Tcp同步服务端,SocketObject继承抽象类
        /// 服务端采用TcpListener封装.
        /// 使用Semaphore 来控制并发,每次处理5个.最大处理5000 
        /// </summary>
        public class TcpServer : SocketObject
        {
            /// <summary>
            /// 信号量
            /// </summary>
            private Semaphore semap = new Semaphore(5, 5000);
            /// <summary>
            /// 客户端队列集合
            /// </summary>
            public List<Sockets> ClientList = new List<Sockets>();
            /// <summary>
            /// 服务端
            /// </summary>
            private TcpListener listener;
            /// <summary>
            /// 当前IP地址
            /// </summary>
            private IPAddress Ipaddress;
            /// <summary>
            /// 欢迎消息
            /// </summary>
            private string boundary = "www.xuanjics.com";
            /// <summary>
            /// 当前监听端口
            /// </summary>
            private int Port;
            /// <summary>
            /// 当前IP,端口对象
            /// </summary>
            private IPEndPoint ip;
            /// <summary>
            /// 初始化服务端对象
            /// </summary>
            /// <param name="ipaddress">IP地址</param>
            /// <param name="port">监听端口</param>
            public override void InitSocket(IPAddress ipaddress, int port)
            {
                Ipaddress = ipaddress;
                Port = port;
                listener = new TcpListener(Ipaddress, Port);
            }
            /// <summary>
            /// 初始化服务端对象
            /// </summary>
            /// <param name="ipaddress">IP地址</param>
            /// <param name="port">监听端口</param>
            public override void InitSocket(string ipaddress, int port)
            {
                Ipaddress = IPAddress.Parse(ipaddress);
                Port = port;
                ip = new IPEndPoint(Ipaddress, Port);
                listener = new TcpListener(Ipaddress, Port);
            }
            /// <summary>
            /// 启动监听,并处理连接
            /// </summary>
            public override void Start()
            {
                try
                {
                    listener.Start();
                    Thread AccTh = new Thread(new ThreadStart(delegate
                    {
                        while (true)
                        {
                            GetAcceptTcpClient();
                        }
                    }));
                    AccTh.Start();
                }
                catch (SocketException skex)
                {
                    Sockets sks = new Sockets();
                    sks.ex = skex;
                    pushSockets.Invoke(sks);//推送至UI

                }
            }
            /// <summary>
            /// 等待处理新的连接
            /// </summary>
            private void GetAcceptTcpClient()
            {
                if (listener.Pending())
                {
                    semap.WaitOne();
                    TcpClient tclient = listener.AcceptTcpClient();
                    //维护客户端队列

                    Socket socket = tclient.Client;
                    NetworkStream stream = new NetworkStream(socket, true); //承载这个Socket
                    Sockets sks = new Sockets(tclient.Client.RemoteEndPoint as IPEndPoint, tclient, stream);
                    //客户端异步接收
                    sks.nStream.BeginRead(sks.RecBuffer, 0, sks.RecBuffer.Length, new AsyncCallback(EndReader), sks);
                    //加入客户端集合.
                    AddClientList(sks);
                    //主动向客户端发送一条连接成功信息 
                    if (stream.CanWrite)
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(boundary);
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    semap.Release();
                }
            }
            /// <summary>
            /// 异步接收发送的信息.
            /// </summary>
            /// <param name="ir"></param>
            private void EndReader(IAsyncResult ir)
            {
                try
                {
                    Sockets sks = ir.AsyncState as Sockets;
                    if (sks != null)
                    {
                        sks.Offset = sks.nStream.EndRead(ir);
                        pushSockets.Invoke(sks);//推送至UI
                        sks.nStream.BeginRead(sks.RecBuffer, 0, sks.RecBuffer.Length, new AsyncCallback(EndReader), sks);
                    }
                }
                catch (SocketException skex)
                {
                    Sockets sks = new Sockets();
                    sks.ex = skex;
                    pushSockets.Invoke(sks);//推送至UI

                }
            }
            /// <summary>
            /// 加入队列.
            /// </summary>
            /// <param name="sk"></param>
            private void AddClientList(Sockets sk)
            {
                Sockets sockets = ClientList.Find(o => { return o.Ip == sk.Ip; });
                //如果不存在则添加,否则更新
                if (sockets == null)
                {
                    ClientList.Add(sk);
                }
                else
                {
                    ClientList.Remove(sockets);
                    ClientList.Add(sk);
                }
            }
            public override void Stop()
            {
                listener.Stop();
            }
            /// <summary>
            /// 向所有在线的客户端发送信息.
            /// </summary>
            /// <param name="SendData">发送的文本</param>
            public void SendToAll(string SendData)
            {
                for (int i = 0; i < ClientList.Count; i++)
                {
                    SendToClient(ClientList[i].Ip, SendData);
                }
            }
            /// <summary>
            /// 向某一位客户端发送信息
            /// </summary>
            /// <param name="ip">客户端IP+端口地址</param>
            /// <param name="SendData">发送的数据包</param>
            public void SendToClient(IPEndPoint ip, string SendData)
            {
                try
                {
                    Sockets sks = ClientList.Find(o => { return o.Ip == ip; });
                    if (sks != null)
                    {
                        if (sks.Client.Connected)
                        {
                            //获取当前流进行写入.
                            NetworkStream nStream = sks.nStream;
                            if (nStream.CanWrite)
                            {
                                byte[] buffer = Encoding.UTF8.GetBytes(SendData);
                                nStream.Write(buffer, 0, buffer.Length);
                            }
                            else
                            {
                                //避免流被关闭,重新从对象中获取流
                                nStream = sks.Client.GetStream();
                                if (nStream.CanWrite)
                                {
                                    byte[] buffer = Encoding.UTF8.GetBytes(SendData);
                                    nStream.Write(buffer, 0, buffer.Length);
                                }
                                else
                                {
                                    //如果还是无法写入,那么认为客户端中断连接.
                                    ClientList.Remove(sks);
                                }
                            }
                        }
                    }
                }
                catch (SocketException skex)
                {
                    Sockets sks = new Sockets();
                    sks.ex = skex;
                    pushSockets.Invoke(sks);//推送至UI

                }
            }
        }
        public class TcpClients : SocketObject
        {
            /// <summary>
            /// 当前管理对象
            /// </summary>
            Sockets sk;
            /// <summary>
            /// 客户端
            /// </summary>
            TcpClient client;
            /// <summary>
            /// 当前连接服务端地址
            /// </summary>
            IPAddress Ipaddress;
            /// <summary>
            /// 当前连接服务端端口号
            /// </summary>
            int Port;
            /// <summary>
            /// 服务端IP+端口
            /// </summary>
            IPEndPoint ip;
            /// <summary>
            /// 发送与接收使用的流
            /// </summary>
            NetworkStream nStream;
            /// <summary>
            /// 初始化Socket
            /// </summary>
            /// <param name="ipaddress"></param>
            /// <param name="port"></param>
            public override void InitSocket(string ipaddress, int port)
            {
                Ipaddress = IPAddress.Parse(ipaddress);
                Port = port;
                ip = new IPEndPoint(Ipaddress, Port);
                client = new TcpClient();
            }
            public void SendData(string SendData)
            {
                try
                {
                    //如果连接则发送
                    if (client.Connected)
                    {
                        if (nStream == null)
                        {
                            nStream = client.GetStream();
                        }
                        byte[] buffer = Encoding.UTF8.GetBytes(SendData);
                        nStream.Write(buffer, 0, buffer.Length);

                    }
                }
                catch (SocketException skex)
                {
                    Sockets sks = new Sockets();
                    sks.ex = skex;
                    pushSockets.Invoke(sks);//推送至UI

                }
            }
            /// <summary>
            /// 初始化Socket
            /// </summary>
            /// <param name="ipaddress"></param>
            /// <param name="port"></param>
            public override void InitSocket(IPAddress ipaddress, int port)
            {
                Ipaddress = ipaddress;
                Port = port;
                ip = new IPEndPoint(Ipaddress, Port);
                client = new TcpClient();
            }
            private void Connect()
            {
                client.Connect(ip);
                nStream = new NetworkStream(client.Client, true);
                sk = new Sockets(ip, client, nStream);
                sk.nStream.BeginRead(sk.RecBuffer, 0, sk.RecBuffer.Length, new AsyncCallback(EndReader), sk);
            }
            private void EndReader(IAsyncResult ir)
            {
                try
                {
                    Sockets s = ir.AsyncState as Sockets;
                    if (s != null)
                    {
                        s.Offset = s.nStream.EndRead(ir);
                        pushSockets.Invoke(s);//推送至UI
                        sk.nStream.BeginRead(sk.RecBuffer, 0, sk.RecBuffer.Length, new AsyncCallback(EndReader), sk);
                    }
                }
                catch (SocketException skex)
                {
                    Sockets sks = new Sockets();
                    sks.ex = skex;
                    pushSockets.Invoke(sks);//推送至UI

                }
            }
            /// <summary>
            /// 重写Start方法,其实就是连接服务端
            /// </summary>
            public override void Start()
            {
                Connect();
            }
            public override void Stop()
            {
                client.Close();
            }

        }
        /// <summary>
        /// Socket基类(抽象类)
        /// 抽象3个方法,初始化Socket(含一个构造),停止,启动方法.
        /// 此抽象类为TcpServer与TcpClient的基类,前者实现后者抽象方法.
        /// 作用: 纯属闲的蛋疼,不写个OO的我感觉不会写代码了...What The Fuck...
        /// </summary>
        public abstract class SocketObject
        {
            public abstract void InitSocket(IPAddress ipaddress, int port);
            public abstract void InitSocket(string ipaddress, int port);
            public abstract void Start();
            public abstract void Stop();

        }
        /// <summary>
        /// 自定义Socket对象
        /// </summary>
        public class Sockets
        {
            /// <summary>
            /// 接收缓冲区
            /// </summary>
            public byte[] RecBuffer = new byte[8 * 1024];
            /// <summary>
            /// 发送缓冲区
            /// </summary>
            public byte[] SendBuffer = new byte[8 * 1024];
            /// <summary>
            /// 异步接收后包的大小
            /// </summary>
            public int Offset { get; set; }
            /// <summary>
            /// 空构造
            /// </summary>
            public Sockets() { }
            /// <summary>
            /// 创建Sockets对象
            /// </summary>
            /// <param name="ip">Ip地址</param>
            /// <param name="client">TcpClient</param>
            /// <param name="ns">承载客户端Socket的网络流</param>
            public Sockets(IPEndPoint ip, TcpClient client, NetworkStream ns)
            {
                Ip = ip;
                Client = client;
                nStream = ns;
            }
            /// <summary>
            /// 当前IP地址,端口号
            /// </summary>
            public IPEndPoint Ip { get; set; }
            /// <summary>
            /// 客户端主通信程序
            /// </summary>
            public TcpClient Client { get; set; }
            /// <summary>
            /// 承载客户端Socket的网络流
            /// </summary>
            public NetworkStream nStream { get; set; }
            /// <summary>
            /// 发生异常时不为null.
            /// </summary>
            public Exception ex { get; set; }
        }
    }
}
