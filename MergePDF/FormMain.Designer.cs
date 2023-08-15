namespace MergePDF
{
    partial class FormMain
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
            toolStrip1 = new ToolStrip();
            AddFile = new ToolStripButton();
            RemoveFile = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            MoveUp = new ToolStripButton();
            MoveDown = new ToolStripButton();
            MergeFile = new ToolStripButton();
            About = new ToolStripLabel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { AddFile, RemoveFile, toolStripSeparator1, MoveUp, MoveDown, MergeFile, About });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(933, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // AddFile
            // 
            AddFile.Image = Properties.Resources.browse_32;
            AddFile.ImageTransparentColor = Color.Magenta;
            AddFile.Name = "AddFile";
            AddFile.Size = new Size(70, 22);
            AddFile.Text = "Add File";
            // 
            // RemoveFile
            // 
            RemoveFile.Image = Properties.Resources.delete_32;
            RemoveFile.ImageTransparentColor = Color.Magenta;
            RemoveFile.Name = "RemoveFile";
            RemoveFile.Size = new Size(91, 22);
            RemoveFile.Text = "Remove File";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // MoveUp
            // 
            MoveUp.Image = Properties.Resources.arrow_up_32;
            MoveUp.ImageTransparentColor = Color.Magenta;
            MoveUp.Name = "MoveUp";
            MoveUp.Size = new Size(75, 22);
            MoveUp.Text = "Move Up";
            // 
            // MoveDown
            // 
            MoveDown.Image = Properties.Resources.arrow_down_32;
            MoveDown.ImageTransparentColor = Color.Magenta;
            MoveDown.Name = "MoveDown";
            MoveDown.Size = new Size(91, 22);
            MoveDown.Text = "Move Down";
            // 
            // MergeFile
            // 
            MergeFile.Image = Properties.Resources.pdf_merge_32;
            MergeFile.ImageTransparentColor = Color.Magenta;
            MergeFile.Name = "MergeFile";
            MergeFile.Size = new Size(61, 22);
            MergeFile.Text = "Merge";
            // 
            // About
            // 
            About.Alignment = ToolStripItemAlignment.Right;
            About.Name = "About";
            About.Size = new Size(40, 22);
            About.Text = "About";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 497);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(933, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(webView21);
            splitContainer1.Size = new Size(933, 472);
            splitContainer1.SplitterDistance = 339;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Margin = new Padding(4, 3, 4, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(339, 472);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(0, 0);
            webView21.Margin = new Padding(4, 3, 4, 3);
            webView21.Name = "webView21";
            webView21.Size = new Size(589, 472);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormMain";
            Text = "Merge PDF Files";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private ToolStripButton AddFile;
        private ToolStripButton RemoveFile;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton MoveUp;
        private ToolStripButton MoveDown;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripLabel About;
        private ToolStripButton MergeFile;
    }
}

