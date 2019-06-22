namespace ScreenShareHost
{
    partial class ScreenShare
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbScreen = new System.Windows.Forms.PictureBox();
            this.btnStreaming = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbHostId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbScreen
            // 
            this.pbScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbScreen.Location = new System.Drawing.Point(267, 12);
            this.pbScreen.Name = "pbScreen";
            this.pbScreen.Size = new System.Drawing.Size(985, 657);
            this.pbScreen.TabIndex = 0;
            this.pbScreen.TabStop = false;
            // 
            // btnStreaming
            // 
            this.btnStreaming.Location = new System.Drawing.Point(110, 621);
            this.btnStreaming.Name = "btnStreaming";
            this.btnStreaming.Size = new System.Drawing.Size(151, 48);
            this.btnStreaming.TabIndex = 1;
            this.btnStreaming.Text = "Streaming";
            this.btnStreaming.UseVisualStyleBackColor = true;
            this.btnStreaming.Click += new System.EventHandler(this.btnStreaming_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.Location = new System.Drawing.Point(12, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(234, 37);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "ScreenShare";
            // 
            // lbHostId
            // 
            this.lbHostId.AutoSize = true;
            this.lbHostId.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbHostId.Location = new System.Drawing.Point(17, 150);
            this.lbHostId.Name = "lbHostId";
            this.lbHostId.Size = new System.Drawing.Size(0, 20);
            this.lbHostId.TabIndex = 3;
            // 
            // ScreenShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lbHostId);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnStreaming);
            this.Controls.Add(this.pbScreen);
            this.Name = "ScreenShare";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbScreen;
        private System.Windows.Forms.Button btnStreaming;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbHostId;
    }
}

