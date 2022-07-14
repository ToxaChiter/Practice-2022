using Practice;

namespace BitMask_Visual
{
    partial class FormSetOperations
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddSet = new System.Windows.Forms.Button();
            this.Union = new System.Windows.Forms.Button();
            this.ListSets = new System.Windows.Forms.ListBox();
            this.TextBoxReadOnly = new System.Windows.Forms.Label();
            this.TextBoxAmount = new System.Windows.Forms.TextBox();
            this.Intersection = new System.Windows.Forms.Button();
            this.Difference = new System.Windows.Forms.Button();
            this.SymmetricalDifference = new System.Windows.Forms.Button();
            this.Negation = new System.Windows.Forms.Button();
            this.Choice = new System.Windows.Forms.Button();
            this.TextBoxTip = new System.Windows.Forms.Label();
            this.Bulean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddSet
            // 
            this.AddSet.Location = new System.Drawing.Point(268, 12);
            this.AddSet.Name = "AddSet";
            this.AddSet.Size = new System.Drawing.Size(138, 53);
            this.AddSet.TabIndex = 0;
            this.AddSet.Text = "Добавить множество";
            this.AddSet.UseVisualStyleBackColor = true;
            this.AddSet.Visible = false;
            this.AddSet.Click += new System.EventHandler(this.AddSet_Click);
            // 
            // Union
            // 
            this.Union.Location = new System.Drawing.Point(268, 85);
            this.Union.Name = "Union";
            this.Union.Size = new System.Drawing.Size(138, 53);
            this.Union.TabIndex = 1;
            this.Union.Text = "Объединение";
            this.Union.UseVisualStyleBackColor = true;
            this.Union.Visible = false;
            // 
            // ListSets
            // 
            this.ListSets.FormattingEnabled = true;
            this.ListSets.ItemHeight = 20;
            this.ListSets.Location = new System.Drawing.Point(27, 52);
            this.ListSets.Name = "ListSets";
            this.ListSets.Size = new System.Drawing.Size(150, 384);
            this.ListSets.TabIndex = 6;
            this.ListSets.Visible = false;
            // 
            // TextBoxReadOnly
            // 
            this.TextBoxReadOnly.CausesValidation = false;
            this.TextBoxReadOnly.Location = new System.Drawing.Point(699, 25);
            this.TextBoxReadOnly.Name = "TextBoxReadOnly";
            this.TextBoxReadOnly.Size = new System.Drawing.Size(347, 27);
            this.TextBoxReadOnly.TabIndex = 7;
            this.TextBoxReadOnly.Text = "Введите количество элементов универсума";
            // 
            // TextBoxAmount
            // 
            this.TextBoxAmount.Location = new System.Drawing.Point(731, 58);
            this.TextBoxAmount.Name = "TextBoxAmount";
            this.TextBoxAmount.PlaceholderText = "Допускается лишь целое число";
            this.TextBoxAmount.Size = new System.Drawing.Size(284, 27);
            this.TextBoxAmount.TabIndex = 8;
            this.TextBoxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAmount_KeyPress_First);
            // 
            // Intersection
            // 
            this.Intersection.Location = new System.Drawing.Point(268, 158);
            this.Intersection.Name = "Intersection";
            this.Intersection.Size = new System.Drawing.Size(138, 53);
            this.Intersection.TabIndex = 2;
            this.Intersection.Text = "Пересечение";
            this.Intersection.UseVisualStyleBackColor = true;
            this.Intersection.Visible = false;
            // 
            // Difference
            // 
            this.Difference.Location = new System.Drawing.Point(268, 230);
            this.Difference.Name = "Difference";
            this.Difference.Size = new System.Drawing.Size(138, 53);
            this.Difference.TabIndex = 3;
            this.Difference.Text = "Разность";
            this.Difference.UseVisualStyleBackColor = true;
            this.Difference.Visible = false;
            // 
            // SymmetricalDifference
            // 
            this.SymmetricalDifference.Location = new System.Drawing.Point(268, 301);
            this.SymmetricalDifference.Name = "SymmetricalDifference";
            this.SymmetricalDifference.Size = new System.Drawing.Size(138, 53);
            this.SymmetricalDifference.TabIndex = 4;
            this.SymmetricalDifference.Text = "Симметрическая разность";
            this.SymmetricalDifference.UseVisualStyleBackColor = true;
            this.SymmetricalDifference.Visible = false;
            // 
            // Negation
            // 
            this.Negation.Location = new System.Drawing.Point(268, 373);
            this.Negation.Name = "Negation";
            this.Negation.Size = new System.Drawing.Size(138, 53);
            this.Negation.TabIndex = 5;
            this.Negation.Text = "Дополнение";
            this.Negation.UseVisualStyleBackColor = true;
            this.Negation.Visible = false;
            // 
            // Choice
            // 
            this.Choice.Location = new System.Drawing.Point(27, 12);
            this.Choice.Name = "Choice";
            this.Choice.Size = new System.Drawing.Size(150, 29);
            this.Choice.TabIndex = 9;
            this.Choice.Text = "Выбрать";
            this.Choice.UseVisualStyleBackColor = true;
            this.Choice.Visible = false;
            // 
            // TextBoxTip
            // 
            this.TextBoxTip.CausesValidation = false;
            this.TextBoxTip.Location = new System.Drawing.Point(183, 12);
            this.TextBoxTip.Name = "TextBoxTip";
            this.TextBoxTip.Size = new System.Drawing.Size(548, 53);
            this.TextBoxTip.TabIndex = 10;
            this.TextBoxTip.Visible = false;
            // 
            // Bulean
            // 
            this.Bulean.Location = new System.Drawing.Point(752, 261);
            this.Bulean.Name = "Bulean";
            this.Bulean.Size = new System.Drawing.Size(237, 112);
            this.Bulean.TabIndex = 11;
            this.Bulean.Text = "Булеан";
            this.Bulean.UseVisualStyleBackColor = true;
            this.Bulean.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1058, 529);
            this.Controls.Add(this.Bulean);
            this.Controls.Add(this.TextBoxTip);
            this.Controls.Add(this.Choice);
            this.Controls.Add(this.Negation);
            this.Controls.Add(this.SymmetricalDifference);
            this.Controls.Add(this.Difference);
            this.Controls.Add(this.Intersection);
            this.Controls.Add(this.TextBoxAmount);
            this.Controls.Add(this.TextBoxReadOnly);
            this.Controls.Add(this.ListSets);
            this.Controls.Add(this.Union);
            this.Controls.Add(this.AddSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Битовая маска";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button AddSet;
        private Button Union;
        private ListBox ListSets;
        private Label TextBoxReadOnly;
        private TextBox TextBoxAmount;
        private Label TextBoxTip;
        private Button Intersection;
        private Button Difference;
        private Button SymmetricalDifference;
        private Button Negation;
        private Button Choice;
        private Button Bulean;

        private BitMask MainBitMask;
        private Dictionary<string, int[]> Sets = new();
        private int[] tempSet;
        private enum SetOperations
        {
            Union,
            Intersection,
            Difference,
            SymmetricalDifference,
            Negation,
            Bulean,
            Error = -1
        }
        private SetOperations SetOperation;
        private string[][] Texts;
        private Button[] Buttons;
        private SaveFileDialog saveFile;
    }
}