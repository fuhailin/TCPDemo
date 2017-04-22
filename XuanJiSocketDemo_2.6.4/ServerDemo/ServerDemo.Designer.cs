namespace ServerDemo
{
    partial class ServerDemo
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
            this.lb_ServerInfo = new System.Windows.Forms.ListBox();
            this.bn_Resume = new System.Windows.Forms.Button();
            this.bn_Stop = new System.Windows.Forms.Button();
            this.bn_Start = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.btnSendto = new System.Windows.Forms.Button();
            this.labClientCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_ServerInfo
            // 
            this.lb_ServerInfo.FormattingEnabled = true;
            this.lb_ServerInfo.ItemHeight = 12;
            this.lb_ServerInfo.Location = new System.Drawing.Point(14, 32);
            this.lb_ServerInfo.Name = "lb_ServerInfo";
            this.lb_ServerInfo.Size = new System.Drawing.Size(572, 100);
            this.lb_ServerInfo.TabIndex = 61;
            // 
            // bn_Resume
            // 
            this.bn_Resume.Location = new System.Drawing.Point(174, 3);
            this.bn_Resume.Name = "bn_Resume";
            this.bn_Resume.Size = new System.Drawing.Size(97, 23);
            this.bn_Resume.TabIndex = 69;
            this.bn_Resume.Text = "SendToAll";
            this.bn_Resume.UseVisualStyleBackColor = true;
            this.bn_Resume.Click += new System.EventHandler(this.bn_Resume_Click);
            // 
            // bn_Stop
            // 
            this.bn_Stop.Location = new System.Drawing.Point(111, 3);
            this.bn_Stop.Name = "bn_Stop";
            this.bn_Stop.Size = new System.Drawing.Size(57, 23);
            this.bn_Stop.TabIndex = 67;
            this.bn_Stop.Text = "停止";
            this.bn_Stop.UseVisualStyleBackColor = true;
            this.bn_Stop.Click += new System.EventHandler(this.bn_Stop_Click);
            // 
            // bn_Start
            // 
            this.bn_Start.Location = new System.Drawing.Point(14, 3);
            this.bn_Start.Name = "bn_Start";
            this.bn_Start.Size = new System.Drawing.Size(86, 23);
            this.bn_Start.TabIndex = 66;
            this.bn_Start.Text = "启动服务器";
            this.bn_Start.UseVisualStyleBackColor = true;
            this.bn_Start.Click += new System.EventHandler(this.bn_Start_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 141);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(572, 88);
            this.listBox1.TabIndex = 61;
            // 
            // cmbClient
            // 
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(379, 5);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(115, 20);
            this.cmbClient.TabIndex = 70;
            // 
            // btnSendto
            // 
            this.btnSendto.Location = new System.Drawing.Point(287, 3);
            this.btnSendto.Name = "btnSendto";
            this.btnSendto.Size = new System.Drawing.Size(75, 23);
            this.btnSendto.TabIndex = 71;
            this.btnSendto.Text = "SendTo";
            this.btnSendto.UseVisualStyleBackColor = true;
            this.btnSendto.Click += new System.EventHandler(this.btnSendto_Click);
            // 
            // labClientCount
            // 
            this.labClientCount.AutoSize = true;
            this.labClientCount.Location = new System.Drawing.Point(515, 8);
            this.labClientCount.Name = "labClientCount";
            this.labClientCount.Size = new System.Drawing.Size(11, 12);
            this.labClientCount.TabIndex = 72;
            this.labClientCount.Text = "0";
            // 
            // ServerDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 241);
            this.Controls.Add(this.labClientCount);
            this.Controls.Add(this.btnSendto);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.bn_Resume);
            this.Controls.Add(this.bn_Stop);
            this.Controls.Add(this.bn_Start);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lb_ServerInfo);
            this.Name = "ServerDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerDemo_FormClosing);
            this.Load += new System.EventHandler(this.ServerDemo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_ServerInfo;
        private System.Windows.Forms.Button bn_Resume;
        private System.Windows.Forms.Button bn_Stop;
        private System.Windows.Forms.Button bn_Start;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Button btnSendto;
        private System.Windows.Forms.Label labClientCount;
    }
}

