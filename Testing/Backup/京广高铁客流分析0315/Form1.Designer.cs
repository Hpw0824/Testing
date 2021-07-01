namespace 京广高铁客流分析0315
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
            this.components = new System.ComponentModel.Container();
            this.区段客流 = new System.Windows.Forms.Button();
            this.旅客OD客流 = new System.Windows.Forms.Button();
            this.Cal = new System.Windows.Forms.Button();
            this.Sta = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.车次统计 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // 区段客流
            // 
            this.区段客流.Location = new System.Drawing.Point(260, 12);
            this.区段客流.Name = "区段客流";
            this.区段客流.Size = new System.Drawing.Size(99, 23);
            this.区段客流.TabIndex = 0;
            this.区段客流.Text = "3.区段客流填充";
            this.区段客流.UseVisualStyleBackColor = true;
            this.区段客流.Click += new System.EventHandler(this.区段客流_Click);
            // 
            // 旅客OD客流
            // 
            this.旅客OD客流.Location = new System.Drawing.Point(108, 11);
            this.旅客OD客流.Name = "旅客OD客流";
            this.旅客OD客流.Size = new System.Drawing.Size(123, 23);
            this.旅客OD客流.TabIndex = 1;
            this.旅客OD客流.Text = "2.旅客OD客流填充";
            this.旅客OD客流.UseVisualStyleBackColor = true;
            this.旅客OD客流.Click += new System.EventHandler(this.旅客OD客流_Click);
            // 
            // Cal
            // 
            this.Cal.Location = new System.Drawing.Point(382, 12);
            this.Cal.Name = "Cal";
            this.Cal.Size = new System.Drawing.Size(75, 23);
            this.Cal.TabIndex = 2;
            this.Cal.Text = "4.统计";
            this.Cal.UseVisualStyleBackColor = true;
            this.Cal.Click += new System.EventHandler(this.Cal_Click);
            // 
            // Sta
            // 
            this.Sta.Location = new System.Drawing.Point(12, 11);
            this.Sta.Name = "Sta";
            this.Sta.Size = new System.Drawing.Size(75, 23);
            this.Sta.TabIndex = 3;
            this.Sta.Text = "1.站名填充";
            this.Sta.UseVisualStyleBackColor = true;
            this.Sta.Click += new System.EventHandler(this.Sta_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(600, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 车次统计
            // 
            this.车次统计.Location = new System.Drawing.Point(492, 12);
            this.车次统计.Name = "车次统计";
            this.车次统计.Size = new System.Drawing.Size(75, 23);
            this.车次统计.TabIndex = 7;
            this.车次统计.Text = "车次统计";
            this.车次统计.UseVisualStyleBackColor = true;
            this.车次统计.Click += new System.EventHandler(this.车次统计_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 262);
            this.Controls.Add(this.车次统计);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Sta);
            this.Controls.Add(this.Cal);
            this.Controls.Add(this.旅客OD客流);
            this.Controls.Add(this.区段客流);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 区段客流;
        private System.Windows.Forms.Button 旅客OD客流;
        private System.Windows.Forms.Button Cal;
        private System.Windows.Forms.Button Sta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button 车次统计;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

