namespace ClientDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bn_Conn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.infolist = new System.Windows.Forms.ListBox();
            this.statuslist = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtThis = new System.Windows.Forms.TextBox();
            this.btnSendThis = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSendThis);
            this.groupBox3.Controls.Add(this.bn_Conn);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnDisconnect);
            this.groupBox3.Controls.Add(this.txtPort);
            this.groupBox3.Controls.Add(this.txtIP);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.btnConnect);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 94);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            // 
            // bn_Conn
            // 
            this.bn_Conn.Location = new System.Drawing.Point(421, 11);
            this.bn_Conn.Name = "bn_Conn";
            this.bn_Conn.Size = new System.Drawing.Size(99, 32);
            this.bn_Conn.TabIndex = 5;
            this.bn_Conn.Text = "连接压力测试";
            this.bn_Conn.UseVisualStyleBackColor = true;
            this.bn_Conn.Click += new System.EventHandler(this.bn_MaxConn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "服务器端口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "服务器IP";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(196, 45);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(102, 32);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "断开连接";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.bn_Disconnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.ForeColor = System.Drawing.Color.Blue;
            this.txtPort.Location = new System.Drawing.Point(65, 45);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 8;
            this.txtPort.Text = "9527";
            // 
            // txtIP
            // 
            this.txtIP.ForeColor = System.Drawing.Color.Blue;
            this.txtIP.Location = new System.Drawing.Point(65, 18);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 8;
            this.txtIP.Text = "127.0.0.1";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(304, 11);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(102, 32);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "发数随机数据";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.bn_LoopSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(196, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(102, 32);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "连服务器";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.bn_Connect_Click);
            // 
            // infolist
            // 
            this.infolist.FormattingEnabled = true;
            this.infolist.ItemHeight = 12;
            this.infolist.Location = new System.Drawing.Point(18, 334);
            this.infolist.Name = "infolist";
            this.infolist.Size = new System.Drawing.Size(528, 88);
            this.infolist.TabIndex = 28;
            // 
            // statuslist
            // 
            this.statuslist.FormattingEnabled = true;
            this.statuslist.ItemHeight = 12;
            this.statuslist.Location = new System.Drawing.Point(14, 228);
            this.statuslist.Name = "statuslist";
            this.statuslist.Size = new System.Drawing.Size(528, 88);
            this.statuslist.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "客户端状态信息：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "客户端文字信息：";
            // 
            // txtThis
            // 
            this.txtThis.Location = new System.Drawing.Point(18, 112);
            this.txtThis.Multiline = true;
            this.txtThis.Name = "txtThis";
            this.txtThis.Size = new System.Drawing.Size(514, 98);
            this.txtThis.TabIndex = 23;
            // 
            // btnSendThis
            // 
            this.btnSendThis.Location = new System.Drawing.Point(304, 45);
            this.btnSendThis.Name = "btnSendThis";
            this.btnSendThis.Size = new System.Drawing.Size(102, 32);
            this.btnSendThis.TabIndex = 23;
            this.btnSendThis.Text = "发送消息";
            this.btnSendThis.UseVisualStyleBackColor = true;
            this.btnSendThis.Click += new System.EventHandler(this.btnSendThis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 429);
            this.Controls.Add(this.txtThis);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.statuslist);
            this.Controls.Add(this.infolist);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox infolist;
        private System.Windows.Forms.ListBox statuslist;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bn_Conn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnSendThis;
        private System.Windows.Forms.TextBox txtThis;
    }
}

