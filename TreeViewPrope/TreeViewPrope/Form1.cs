using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewPrope
{
    public partial class Form1 : Form
    {
        public class TreeViewItem
        {
            public int ID { get; set; }
            public int ParentID { get; set; }
            public string Text { get; set; }
        }

        List<TreeViewItem> treeViewList;
        public Form1()
        {
            InitializeComponent();
            treeViewList = new List<TreeViewItem>();

            treeViewList.Add(new TreeViewItem()
            {
                ParentID = 0,
                ID = 1,
                Text = "Parent node"
            });
            treeViewList.Add(new TreeViewItem()
            {
                ParentID = 1,
                ID = 2,
                Text = "First child node"
            });
            treeViewList.Add(new TreeViewItem()
            {
                ParentID = 1,
                ID = 3,
                Text = "Second child node"
            });
            treeViewList.Add(new TreeViewItem()
            {
                ParentID = 3,
                ID = 4,
                Text = "Child of second child node"
            });
            treeViewList.Add(new TreeViewItem()
            {
                ParentID = 3,
                ID = 5,
                Text = "Child of second child node"
            });

            PopulateTreeView(0, null);
        }

        private void PopulateTreeView(int parentId, TreeNode parentNode)
        {
            var filteredItems = treeViewList.Where(item =>
                                        item.ParentID == parentId);

            TreeNode childNode;
            foreach (var i in filteredItems.ToList())
            {
                if (parentNode == null)
                    childNode = treeView1.Nodes.Add(i.Text);
                else
                    childNode = parentNode.Nodes.Add(i.Text);

                PopulateTreeView(i.ID, childNode);
            }
        }

        
    }
}
