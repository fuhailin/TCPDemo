using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XuanJiSocket;
using System.Threading;
using System.Net;

namespace ServerDemo
{
    public partial class ServerDemo : Form
    {
        public ServerDemo()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void bn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                SocketHelper.pushSockets = new SocketHelper.PushSockets(Rec);
                //防止二次开启引发异常
                if (server == null)
                {
                    server = new SocketHelper.TcpServer();
                    server.InitSocket(IPAddress.Any, 9527);
                    server.Start();
                    lb_ServerInfo.Items.Add("服务端启动成功.!");
                }
                
            }
            catch (Exception ex)
            {

                lb_ServerInfo.Items.Add(string.Format("启动失败!原因：{0}", ex.Message));
                bn_Start.Enabled = true;
            }

        }

        private void bn_Stop_Click(object sender, EventArgs e)
        {
            server.Stop();
        }

        private void bn_Pause_Click(object sender, EventArgs e)
        {

        }

        private void bn_Resume_Click(object sender, EventArgs e)
        {
            server.SendToAll("服务端消息:www.xuanjics.com 随机消息:" + Guid.NewGuid().ToString());

        }
        SocketHelper.TcpServer server;
        private void ServerDemo_Load(object sender, EventArgs e)
        {
            SocketHelper.pushSockets = new SocketHelper.PushSockets(Rec);
           

        }
        private void Rec(SocketHelper.Sockets sks)
        {
            this.Invoke(new ThreadStart(delegate
              {
                  if (listBox1.Items.Count > 1000)
                  {
                      listBox1.Items.Clear();
                  }
                  if (sks.ex != null)
                  {
                      //在此处理异常信息
                      lb_ServerInfo.Items.Add(string.Format("客户端出现异常:{0}.!", sks.ex.Message));
                      cmbClient.Items.Remove(sks.Ip);
                      labClientCount.Text = (cmbClient.Items.Count).ToString();

                  }
                  else
                  {
                      if (sks.NewClientFlag)
                      {
                          lb_ServerInfo.Items.Add(string.Format("新客户端:{0}连接成功.!", sks.Ip));
                          cmbClient.Items.Add(sks.Ip);
                          labClientCount.Text = (cmbClient.Items.Count).ToString();
                      }
                      else
                      {
                          byte[] buffer = new byte[sks.Offset];
                          Array.Copy(sks.RecBuffer, buffer, sks.Offset);
                          string str = string.Empty;
                          if (sks.Offset == 0)
                          {
                              str = "客户端下线";
                              lb_ServerInfo.Items.Add(str);
                              cmbClient.Items.Remove(sks.Ip);
                              labClientCount.Text = (cmbClient.Items.Count).ToString();
                          }
                          else
                          {
                              str = Encoding.UTF8.GetString(buffer);
                              listBox1.Items.Add(string.Format("客户端{0}发来消息：{1}", sks.Ip, str));
                          }
                         
                      }
                  }
              }));
        }

        private void btnSendto_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedItem != null)
            {
                server.SendToClient((IPEndPoint)cmbClient.SelectedItem, string.Format("服务端随机消息...{0}", Guid.NewGuid().ToString()));
            }

        }

        private void ServerDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
        }
    }
}
