using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using XuanJiSocket;
using System.Net.Sockets;
namespace ClientDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        SocketHelper.TcpClients client;
        string ip = string.Empty;
        string port = string.Empty;
        private void Form1_Load(object sender, EventArgs e)
        {
            //客户端如何处理异常等信息参照服务端
            SocketHelper.pushSockets = new SocketHelper.PushSockets(Rec);//注册推送器
            client = new SocketHelper.TcpClients();
            ip = txtIP.Text;
            port = txtPort.Text;
        }
        /// <summary>
        /// 处理推送过来的消息
        /// </summary>
        /// <param name="rec"></param>
        private void Rec(SocketHelper.Sockets sks)
        {
            this.Invoke(new ThreadStart(delegate
            {
                if (infolist.Items.Count > 1000)
                {
                    infolist.Items.Clear();
                }
                if (sks.ex != null)
                {
                    //在这里判断ErrorCode  可以自由扩展
                    switch (sks.ErrorCode)
                    {
                        case SocketHelper.Sockets.ErrorCodes.objectNull:
                            break;
                        case SocketHelper.Sockets.ErrorCodes.ConnectError:
                            break;
                        case SocketHelper.Sockets.ErrorCodes.ConnectSuccess:
                            statuslist.Items.Add("连接成功.!");
                            break;
                        case SocketHelper.Sockets.ErrorCodes.TrySendData:
                            break;
                        default:
                            break;
                    }  
                    infolist.Items.Add(string.Format("客户端信息{0}", sks.ex));
                     
                }
                else
                {
                    byte[] buffer = new byte[sks.Offset];
                    Array.Copy(sks.RecBuffer, buffer, sks.Offset);
                    string str = Encoding.UTF8.GetString(buffer);
                    if (str == "ServerOff")
                    {
                        infolist.Items.Add("服务端主动关闭");
                    }
                    else
                    {
                        infolist.Items.Add(string.Format("服务端{0}发来消息：{1}", sks.Ip, str));
                        txtThis.Text += "\r\n";
                        txtThis.Text += string.Format("服务端{0}发来消息：{1}", sks.Ip, str);
                    }
                }
            }));
        }

        private void bn_LoopSend_Click(object sender, EventArgs e)
        {
            client.SendData("客户端消息.!    " + Guid.NewGuid().ToString());
        }
        private void bn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                ip = txtIP.Text;
                port = txtPort.Text;
                client.InitSocket(ip, int.Parse(port));
                client.Start();
               
            }
            catch (Exception ex)
            {

                statuslist.Items.Add(string.Format("连接失败!原因：{0}", ex.Message));
                btnConnect.Enabled = true;
            }
        }

        private void bn_Disconnect_Click(object sender, EventArgs e)
        {
            client.Stop();
        }
        private void bn_MaxConn_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                //默认1024,自行修改更大的连接数.
                for (int i = 0; i < 1024; i++)
                {
                    SocketHelper.TcpClients clientx = new SocketHelper.TcpClients();//初始化类库  
                    clientx.InitSocket(ip, int.Parse(port));
                    clientx.Start();
                }
                MessageBox.Show("完成.!");
            });

        }

        private void btnSendThis_Click(object sender, EventArgs e)
        {
            client.SendData(this.txtThis.Text.Trim());
        }
    }
}
