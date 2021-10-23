namespace WindowsFormsApp3
{
    partial class FindForm
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
            this.regex = new System.Windows.Forms.CheckBox();
            this.matchWord = new System.Windows.Forms.CheckBox();
            this.matchCase = new System.Windows.Forms.CheckBox();
            this.FindNext = new System.Windows.Forms.Button();
            this.FindPrevious = new System.Windows.Forms.Button();
            this.textToFind = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // regex
            // 
            this.regex.Enabled = false;
            this.regex.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.regex.Location = new System.Drawing.Point(143, 65);
            this.regex.Name = "regex";
            this.regex.Size = new System.Drawing.Size(130, 17);
            this.regex.TabIndex = 12;
            this.regex.Text = "Regular Expressions";
            this.regex.UseVisualStyleBackColor = true;
            // 
            // matchWord
            // 
            this.matchWord.AutoSize = true;
            this.matchWord.Enabled = false;
            this.matchWord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.matchWord.Location = new System.Drawing.Point(12, 65);
            this.matchWord.Name = "matchWord";
            this.matchWord.Size = new System.Drawing.Size(113, 17);
            this.matchWord.TabIndex = 11;
            this.matchWord.Text = "Match whole word";
            this.matchWord.UseVisualStyleBackColor = true;
            // 
            // matchCase
            // 
            this.matchCase.AutoSize = true;
            this.matchCase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.matchCase.Location = new System.Drawing.Point(12, 40);
            this.matchCase.Name = "matchCase";
            this.matchCase.Size = new System.Drawing.Size(80, 17);
            this.matchCase.TabIndex = 10;
            this.matchCase.Text = "Match case";
            this.matchCase.UseVisualStyleBackColor = true;
            // 
            // FindNext
            // 
            this.FindNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FindNext.Location = new System.Drawing.Point(208, 36);
            this.FindNext.Name = "FindNext";
            this.FindNext.Size = new System.Drawing.Size(65, 23);
            this.FindNext.TabIndex = 9;
            this.FindNext.Text = ">";
            this.FindNext.UseVisualStyleBackColor = true;
            // 
            // FindPrevious
            // 
            this.FindPrevious.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FindPrevious.Location = new System.Drawing.Point(143, 36);
            this.FindPrevious.Name = "FindPrevious";
            this.FindPrevious.Size = new System.Drawing.Size(65, 23);
            this.FindPrevious.TabIndex = 8;
            this.FindPrevious.Text = "<";
            this.FindPrevious.UseVisualStyleBackColor = true;
            // 
            // textToFind
            // 
            this.textToFind.Location = new System.Drawing.Point(12, 10);
            this.textToFind.Name = "textToFind";
            this.textToFind.Size = new System.Drawing.Size(261, 20);
            this.textToFind.TabIndex = 7;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 176);
            this.Controls.Add(this.regex);
            this.Controls.Add(this.matchWord);
            this.Controls.Add(this.matchCase);
            this.Controls.Add(this.FindNext);
            this.Controls.Add(this.FindPrevious);
            this.Controls.Add(this.textToFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FindForm";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox regex;
        private System.Windows.Forms.CheckBox matchWord;
        private System.Windows.Forms.CheckBox matchCase;
        private System.Windows.Forms.Button FindNext;
        private System.Windows.Forms.Button FindPrevious;
        private System.Windows.Forms.TextBox textToFind;
    }
}