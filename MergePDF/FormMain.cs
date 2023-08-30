using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergePDF
{
    /// <summary>
    /// The main form of the application. 
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// The root node of the <see cref="TreeNode"/> holding uploaded pdf files.
        /// </summary>
        private TreeNode Root;

        /// <summary>
        /// Available merge actions. Each <see cref="MergeAction"/> must mirror the name property of a toolstrip1 child component.
        /// </summary>
        enum MergeAction
        {
            // must mirror name property of toolstrip1 buttons
            AddFile,
            RemoveFile,
            MoveUp,
            MoveDown,
            MergeFile,
            About
        }

        /// <summary>
        /// A constructor for <see cref="FormMain"/>. Initializes all components.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            Root = treeView1.Nodes.Add("PDF Files");
            treeView1.SelectedNode = Root;

            webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
            webView21.EnsureCoreWebView2Async();

            UpdateComponents();
        }

        /// <summary>
        /// Initializes WebView2 component.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebView21_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            webView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            webView21.NavigateToString("<html><body></body></html>");
        }

        /// <summary>
        /// Updates <see cref="FormMain"/> components after treeView select/focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateComponents();
        }

        /// <summary>
        /// Updates all components in the <see cref="FormMain"/> form.
        /// </summary>
        private void UpdateComponents()
        {
            UpdateStatusStrip1();
            UpdateButtons();
            UpdateWebView21();
        }

        /// <summary>
        /// Updates the StatusStrip to the filename of the currently selected treeView node.
        /// </summary>
        private void UpdateStatusStrip1()
        {
            if (treeView1.SelectedNode.Equals(Root))
            {
                toolStripStatusLabel1.Text = "";
            }
            else
            {
                toolStripStatusLabel1.Text = ((PdfFileInfo)treeView1.SelectedNode.Tag).Filename;
            }
        }

        /// <summary>
        /// Updates the states of all buttons.
        /// </summary>
        private void UpdateButtons()
        {
            RemoveFile.Enabled = true;
            MoveUp.Enabled = true;
            MoveDown.Enabled = true;
            MergeFile.Enabled = true;

            if (Root.Nodes.Count == 0)
            {
                RemoveFile.Enabled = false;
                MoveUp.Enabled = false;
                MoveDown.Enabled = false;
                MergeFile.Enabled = false;
            }
            else if (treeView1.SelectedNode.Equals(Root))
            {
                RemoveFile.Enabled = false;
                MoveUp.Enabled = false;
                MoveDown.Enabled = false;
            }
            else if (treeView1.SelectedNode.Index == 0)
            {
                MoveUp.Enabled = false;
            }
            else if (treeView1.SelectedNode.Index == Root.Nodes.Count - 1)
            {
                MoveDown.Enabled = false;
            }
        }

        /// <summary>
        /// Updates the WebView2 to display the pdf file of the currently selected treeView node.
        /// </summary>
        private void UpdateWebView21()
        {
            if (!treeView1.SelectedNode.Equals(Root))
            {
                webView21.CoreWebView2.Navigate(((PdfFileInfo)treeView1.SelectedNode.Tag).Filename);
            }
        }

        /// <summary>
        /// Merge action controller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // try parsing toolstripitem name to merge action enum
            if (!Enum.TryParse<MergeAction>(e.ClickedItem.Name, out MergeAction action))
            {
                LogMessage.Log($"invalid toolstripitem ({e}); no matching MergeAction");
                return;
            }

            switch (action)
            {
                case MergeAction.AddFile:
                    AddFileHandler();
                    UpdateComponents();
                    break;
                case MergeAction.RemoveFile:
                    RemoveFileHandler();
                    UpdateComponents();
                    break;
                case MergeAction.MoveUp:
                    MoveUpHandler();
                    UpdateComponents();
                    break;
                case MergeAction.MoveDown:
                    MoveDownHandler();
                    UpdateComponents();
                    break;
                case MergeAction.MergeFile:
                    MergeFileHandler();
                    UpdateComponents();
                    break;
                case MergeAction.About:
                    AboutHandler();
                    UpdateComponents();
                    break;
            }
        }

        /// <summary>
        /// Handles the <see cref="MergeAction.About">About</see> action.
        /// </summary>
        private void AboutHandler()
        {
            // opens generated aboutbox
            // edit details through Project -> MergePDF Properties -> Assembly Information
            using (AboutBox box = new AboutBox())
            {
                box.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the <see cref="MergeAction.AddFile">AddFile</see> action.
        /// </summary>
        private void AddFileHandler()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = PdfFileInfo.pdfFilter;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        PdfFileInfo pfi = new PdfFileInfo(fileName);
                        TreeNode node = Root.Nodes.Add(pfi.Name);
                        node.Tag = pfi;
                    }
                    Root.ExpandAll();
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="MergeAction.RemoveFile">RemoveFile</see> action.
        /// </summary>
        private void RemoveFileHandler()
        {
            if (!treeView1.SelectedNode.Equals(Root))
            {
                Root.Nodes.Remove(treeView1.SelectedNode);
            }
            if (Root.Nodes.Count == 0)
            {
                webView21.NavigateToString("<html><body></body></html>");
            }
        }

        /// <summary>
        /// Handles the <see cref="MergeAction.MoveUp">MoveUp</see> action.
        /// </summary>
        private void MoveUpHandler()
        {
            int nodeIdx = Root.Nodes.IndexOf(treeView1.SelectedNode);
            int newIdx = nodeIdx - 1;

            if (newIdx >= 0)
            {
                SwapTreeNodes(Root.Nodes[nodeIdx], Root.Nodes[newIdx]);
                treeView1.SelectedNode = Root.Nodes[newIdx];
            }
        }

        /// <summary>
        /// Handles the <see cref="MergeAction.MoveDown">MoveDown</see> action.
        /// </summary>
        private void MoveDownHandler()
        {
            int nodeIdx = Root.Nodes.IndexOf(treeView1.SelectedNode);
            int newIdx = nodeIdx + 1;

            if (newIdx < Root.Nodes.Count)
            {
                SwapTreeNodes(Root.Nodes[nodeIdx], Root.Nodes[newIdx]);
                treeView1.SelectedNode = Root.Nodes[newIdx];
            }
        }

        /// <summary>
        /// Swaps the selected nodes <paramref name="node1"/>, <paramref name="node2"/>.
        /// </summary>
        /// <param name="node1">A node from a <see cref="TreeNode"/>.</param>
        /// <param name="node2">A node from a <see cref="TreeNode"/>.</param>
        private void SwapTreeNodes(TreeNode node1, TreeNode node2)
        {
            // swap tags of node1/node2
            object temp = node1.Tag;
            node1.Tag = node2.Tag;
            node2.Tag = temp;

            // update all relevent node properties from tag
            node1.Text = ((PdfFileInfo)node1.Tag).Name;
            node2.Text = ((PdfFileInfo)node2.Tag).Name;
        }

        /// <summary>
        /// Handles the <see cref="MergeAction.MergeFile">MergeFile</see> action. Opens the <see cref="FormMerge"/> form.
        /// </summary>
        /// <seealso cref="FormMerge"/>
        private void MergeFileHandler()
        {
            List<PdfFileInfo> pdfs = new List<PdfFileInfo>();
            foreach (TreeNode node in Root.Nodes)
            {
                pdfs.Add((PdfFileInfo)node.Tag);
            }

            using (FormMerge mergeForm = new FormMerge(pdfs))
            {
                if (mergeForm.ShowDialog() == DialogResult.OK)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = PdfFileInfo.pdfFilter;
                    saveFileDialog1.Title = "Save as PDF";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        mergeForm.MergeOption.Merge(saveFileDialog1.FileName);
                    }
                }
            }
        }
    }
}
