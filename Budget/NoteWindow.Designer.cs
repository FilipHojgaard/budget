namespace Budget {
    partial class NoteWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gemButton = new System.Windows.Forms.Button();
            this.annullerButton = new System.Windows.Forms.Button();
            this.noteTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // gemButton
            // 
            this.gemButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.gemButton.Location = new System.Drawing.Point(35, 178);
            this.gemButton.Name = "gemButton";
            this.gemButton.Size = new System.Drawing.Size(75, 23);
            this.gemButton.TabIndex = 1;
            this.gemButton.Text = "Okay";
            this.gemButton.UseVisualStyleBackColor = true;
            this.gemButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // annullerButton
            // 
            this.annullerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annullerButton.Location = new System.Drawing.Point(138, 178);
            this.annullerButton.Name = "annullerButton";
            this.annullerButton.Size = new System.Drawing.Size(75, 23);
            this.annullerButton.TabIndex = 2;
            this.annullerButton.Text = "Annuller";
            this.annullerButton.UseVisualStyleBackColor = true;
            this.annullerButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(12, 12);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(228, 160);
            this.noteTextBox.TabIndex = 3;
            this.noteTextBox.Text = "";
            // 
            // NoteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 210);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(this.annullerButton);
            this.Controls.Add(this.gemButton);
            this.Name = "NoteWindow";
            this.Text = "NoteWindow";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button gemButton;
        private System.Windows.Forms.Button annullerButton;
        private System.Windows.Forms.RichTextBox noteTextBox;
    }
}