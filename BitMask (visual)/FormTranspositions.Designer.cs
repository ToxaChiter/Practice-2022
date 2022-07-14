namespace BitMask_Visual
{
    partial class FormTranspositions
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
            this.TextBoxReadOnly = new System.Windows.Forms.Label();
            this.TextBoxAmount = new System.Windows.Forms.TextBox();
            this.Lexi = new System.Windows.Forms.Button();
            this.Anti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxReadOnly
            // 
            this.TextBoxReadOnly.CausesValidation = false;
            this.TextBoxReadOnly.Location = new System.Drawing.Point(360, 197);
            this.TextBoxReadOnly.Name = "TextBoxReadOnly";
            this.TextBoxReadOnly.Size = new System.Drawing.Size(323, 27);
            this.TextBoxReadOnly.TabIndex = 8;
            this.TextBoxReadOnly.Text = "Введите элементы множества через пробел";
            this.TextBoxReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBoxAmount
            // 
            this.TextBoxAmount.Location = new System.Drawing.Point(376, 227);
            this.TextBoxAmount.Name = "TextBoxAmount";
            this.TextBoxAmount.PlaceholderText = "Допускаются лишь целые числа";
            this.TextBoxAmount.Size = new System.Drawing.Size(284, 27);
            this.TextBoxAmount.TabIndex = 9;
            this.TextBoxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAmount_KeyPress);
            // 
            // Lexi
            // 
            this.Lexi.Location = new System.Drawing.Point(389, 260);
            this.Lexi.Name = "Lexi";
            this.Lexi.Size = new System.Drawing.Size(253, 29);
            this.Lexi.TabIndex = 10;
            this.Lexi.Text = "Лексиографический порядок";
            this.Lexi.UseVisualStyleBackColor = true;
            this.Lexi.Visible = false;
            // 
            // Anti
            // 
            this.Anti.Location = new System.Drawing.Point(389, 295);
            this.Anti.Name = "Anti";
            this.Anti.Size = new System.Drawing.Size(253, 29);
            this.Anti.TabIndex = 11;
            this.Anti.Text = "Антилексиографический порядок";
            this.Anti.UseVisualStyleBackColor = true;
            this.Anti.Visible = false;
            // 
            // FormTranspositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 529);
            this.Controls.Add(this.Anti);
            this.Controls.Add(this.Lexi);
            this.Controls.Add(this.TextBoxAmount);
            this.Controls.Add(this.TextBoxReadOnly);
            this.Name = "FormTranspositions";
            this.Text = "Перестановки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label TextBoxReadOnly;
        private TextBox TextBoxAmount;
        private Button Lexi;
        private Button Anti;
    }
}