namespace NostaleUselessTrainer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reconnectButton = new System.Windows.Forms.Button();
            this.portLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reconnectButton);
            this.groupBox1.Controls.Add(this.portLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.connectionStatusLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PacketLogger Connection";
            // 
            // reconnectButton
            // 
            this.reconnectButton.Location = new System.Drawing.Point(7, 49);
            this.reconnectButton.Name = "reconnectButton";
            this.reconnectButton.Size = new System.Drawing.Size(87, 27);
            this.reconnectButton.TabIndex = 4;
            this.reconnectButton.Text = "Reconnect";
            this.reconnectButton.UseVisualStyleBackColor = true;
            this.reconnectButton.Click += new System.EventHandler(this.reconnectButton_Click);
            // 
            // portLabel
            // 
            this.portLabel.Location = new System.Drawing.Point(55, 32);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(117, 27);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "unknown";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port:";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.connectionStatusLabel.Location = new System.Drawing.Point(55, 19);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(117, 27);
            this.connectionStatusLabel.TabIndex = 1;
            this.connectionStatusLabel.Text = "Not connected";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stats:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 334);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button reconnectButton;

        #endregion
    }
}