using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection.Model
{
    public class TreeNode
    {
        public int Id { get; set; }
        public int TreeId { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }
        public int ParentId { get; set; }
        public string Sort { get; set; }
    }
}
