using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection.Model;

namespace Tree.Models
{
    public class VMDisplay
    {
        public int UserId { get; set; }
        public List<TreeNode> CompleteTree { get; set; }
        public List<TreeNode> MinTree { get; set; }
        public List<TreeNode> MaxTree { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int Sum { get; set; }
        public int TotalNode { get; set; }
    }
}
