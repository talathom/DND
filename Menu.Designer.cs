namespace DnD
{
    partial class Menu
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
            this.newBUT = new System.Windows.Forms.Button();
            this.loadBUT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newBUT
            // 
            this.newBUT.Location = new System.Drawing.Point(12, 88);
            this.newBUT.Name = "newBUT";
            this.newBUT.Size = new System.Drawing.Size(258, 23);
            this.newBUT.TabIndex = 0;
            this.newBUT.Text = "Create New Character";
            this.newBUT.UseVisualStyleBackColor = true;
            this.newBUT.Click += new System.EventHandler(this.newBUT_Click);
            // 
            // loadBUT
            // 
            this.loadBUT.Location = new System.Drawing.Point(12, 146);
            this.loadBUT.Name = "loadBUT";
            this.loadBUT.Size = new System.Drawing.Size(258, 23);
            this.loadBUT.TabIndex = 1;
            this.loadBUT.Text = "Load Character";
            this.loadBUT.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.loadBUT);
            this.Controls.Add(this.newBUT);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newBUT;
        private System.Windows.Forms.Button loadBUT;
    }
}

