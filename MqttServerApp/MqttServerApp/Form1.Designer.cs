
namespace MqttServerApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.logPanel = new System.Windows.Forms.Panel();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.informationPanel = new System.Windows.Forms.Panel();
            this.startServerButton = new System.Windows.Forms.Button();
            this.currentConnectionStatusLabel = new System.Windows.Forms.Label();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.logPanel.SuspendLayout();
            this.informationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.logTextBox);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logPanel.Location = new System.Drawing.Point(0, 131);
            this.logPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(1067, 431);
            this.logPanel.TabIndex = 0;
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.White;
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.ForeColor = System.Drawing.Color.Black;
            this.logTextBox.Location = new System.Drawing.Point(0, 0);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(1067, 431);
            this.logTextBox.TabIndex = 0;
            // 
            // informationPanel
            // 
            this.informationPanel.Controls.Add(this.ipAddressLabel);
            this.informationPanel.Controls.Add(this.startServerButton);
            this.informationPanel.Controls.Add(this.currentConnectionStatusLabel);
            this.informationPanel.Controls.Add(this.connectionStatusLabel);
            this.informationPanel.Controls.Add(this.urlLabel);
            this.informationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.informationPanel.Location = new System.Drawing.Point(0, 0);
            this.informationPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.informationPanel.Name = "informationPanel";
            this.informationPanel.Size = new System.Drawing.Size(1067, 131);
            this.informationPanel.TabIndex = 1;
            // 
            // startServerButton
            // 
            this.startServerButton.Location = new System.Drawing.Point(707, 66);
            this.startServerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(100, 29);
            this.startServerButton.TabIndex = 3;
            this.startServerButton.Text = "Start Server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.startServerButton_Click);
            // 
            // currentConnectionStatusLabel
            // 
            this.currentConnectionStatusLabel.AutoSize = true;
            this.currentConnectionStatusLabel.Location = new System.Drawing.Point(279, 66);
            this.currentConnectionStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentConnectionStatusLabel.Name = "currentConnectionStatusLabel";
            this.currentConnectionStatusLabel.Size = new System.Drawing.Size(58, 15);
            this.currentConnectionStatusLabel.TabIndex = 2;
            this.currentConnectionStatusLabel.Text = "Stopped";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(59, 66);
            this.connectionStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(127, 15);
            this.connectionStatusLabel.TabIndex = 1;
            this.connectionStatusLabel.Text = "Connection Status";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(59, 30);
            this.urlLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(34, 15);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "URL";
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Location = new System.Drawing.Point(279, 30);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(88, 19);
            this.ipAddressLabel.TabIndex = 4;
            this.ipAddressLabel.Text = "ip address";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.informationPanel);
            this.Controls.Add(this.logPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.informationPanel.ResumeLayout(false);
            this.informationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Panel informationPanel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.Label currentConnectionStatusLabel;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.Label ipAddressLabel;
    }
}

