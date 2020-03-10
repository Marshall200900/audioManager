namespace audioManager
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.zeroitMetroButton1 = new Zeroit.Framework.Metro.ZeroitMetroButton();
            this.upperPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dragControl1 = new BaseApp_TabControl.DragControl();
            this.upperPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // zeroitMetroButton1
            // 
            this.zeroitMetroButton1.BackColor = System.Drawing.Color.Turquoise;
            this.zeroitMetroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zeroitMetroButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(47)))));
            this.zeroitMetroButton1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zeroitMetroButton1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zeroitMetroButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.zeroitMetroButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zeroitMetroButton1.Location = new System.Drawing.Point(755, 5);
            this.zeroitMetroButton1.Name = "zeroitMetroButton1";
            this.zeroitMetroButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zeroitMetroButton1.RoundingArc = 20;
            this.zeroitMetroButton1.Size = new System.Drawing.Size(20, 20);
            this.zeroitMetroButton1.TabIndex = 9;
            this.zeroitMetroButton1.Click += new System.EventHandler(this.zeroitMetroButton1_Click);
            // 
            // upperPanel
            // 
            this.upperPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(47)))));
            this.upperPanel.Controls.Add(this.zeroitMetroButton1);
            this.upperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upperPanel.Location = new System.Drawing.Point(0, 0);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(784, 30);
            this.upperPanel.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(50, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Программа для систематизации аудиофайлов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(570, 104);
            this.label2.TabIndex = 11;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.upperPanel;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 404);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.upperPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.upperPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Zeroit.Framework.Metro.ZeroitMetroButton zeroitMetroButton1;
        private System.Windows.Forms.Panel upperPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private BaseApp_TabControl.DragControl dragControl1;
    }
}