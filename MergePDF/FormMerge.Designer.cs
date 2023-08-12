namespace MergePDF
{
    partial class FormMerge
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
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            splitContainer2 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            radioButtonAll = new RadioButton();
            radioButtonSelected = new RadioButton();
            textBoxSelectedPages = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            MergeNow = new Button();
            MergeCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(933, 519);
            splitContainer1.SplitterDistance = 306;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(933, 306);
            dataGridView1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(4, 3, 4, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer2.Size = new Size(933, 208);
            splitContainer2.SplitterDistance = 114;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.75F));
            tableLayoutPanel1.Controls.Add(radioButtonAll, 0, 0);
            tableLayoutPanel1.Controls.Add(radioButtonSelected, 0, 1);
            tableLayoutPanel1.Controls.Add(textBoxSelectedPages, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(933, 114);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // radioButtonAll
            // 
            radioButtonAll.Anchor = AnchorStyles.Right;
            radioButtonAll.AutoSize = true;
            radioButtonAll.Location = new Point(148, 19);
            radioButtonAll.Margin = new Padding(4, 3, 4, 3);
            radioButtonAll.Name = "radioButtonAll";
            radioButtonAll.Size = new Size(176, 19);
            radioButtonAll.TabIndex = 0;
            radioButtonAll.TabStop = true;
            radioButtonAll.Text = "Merge all pages from all files";
            radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // radioButtonSelected
            // 
            radioButtonSelected.Anchor = AnchorStyles.Right;
            radioButtonSelected.AutoSize = true;
            radioButtonSelected.Location = new Point(149, 76);
            radioButtonSelected.Margin = new Padding(4, 3, 4, 3);
            radioButtonSelected.Name = "radioButtonSelected";
            radioButtonSelected.Size = new Size(175, 19);
            radioButtonSelected.TabIndex = 1;
            radioButtonSelected.TabStop = true;
            radioButtonSelected.Text = "Merge selected pages            ";
            radioButtonSelected.UseVisualStyleBackColor = true;
            // 
            // textBoxSelectedPages
            // 
            textBoxSelectedPages.Anchor = AnchorStyles.Left;
            textBoxSelectedPages.Location = new Point(332, 74);
            textBoxSelectedPages.Margin = new Padding(4, 3, 4, 3);
            textBoxSelectedPages.Name = "textBoxSelectedPages";
            textBoxSelectedPages.Size = new Size(340, 23);
            textBoxSelectedPages.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(MergeNow, 0, 0);
            tableLayoutPanel2.Controls.Add(MergeCancel, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel2.Size = new Size(933, 89);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // MergeNow
            // 
            MergeNow.Anchor = AnchorStyles.None;
            MergeNow.Location = new Point(645, 22);
            MergeNow.Margin = new Padding(4, 3, 4, 3);
            MergeNow.Name = "MergeNow";
            MergeNow.Size = new Size(108, 44);
            MergeNow.TabIndex = 1;
            MergeNow.Text = "Merge Now";
            MergeNow.UseVisualStyleBackColor = true;
            MergeNow.Click += MergeNow_Click;
            // 
            // MergeCancel
            // 
            MergeCancel.Anchor = AnchorStyles.None;
            MergeCancel.Location = new Point(179, 22);
            MergeCancel.Margin = new Padding(4, 3, 4, 3);
            MergeCancel.Name = "MergeCancel";
            MergeCancel.Size = new Size(108, 44);
            MergeCancel.TabIndex = 0;
            MergeCancel.Text = "Cancel";
            MergeCancel.UseVisualStyleBackColor = true;
            MergeCancel.Click += MergeCancel_Click;
            // 
            // FormMerge
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(splitContainer1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormMerge";
            Text = "Form2";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private SplitContainer splitContainer2;
        private TableLayoutPanel tableLayoutPanel1;
        private RadioButton radioButtonAll;
        private RadioButton radioButtonSelected;
        private TextBox textBoxSelectedPages;
        private TableLayoutPanel tableLayoutPanel2;
        private Button MergeCancel;
        private Button MergeNow;
    }
}