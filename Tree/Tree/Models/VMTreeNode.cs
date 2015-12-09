using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection.Model;

namespace Tree.Models
{
    public class VMTreeNode
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Text { get; set; }
        public int ParentId { get; set; }

        public List<TreeNode> TreeNodeList { get; set; }
    }
}
