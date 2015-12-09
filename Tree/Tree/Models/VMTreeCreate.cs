using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection.Model;

namespace Tree.Models
{
    public class VMTreeCreate
    {
        public Users Users { get; set; }
        public DBConnection.Model.Tree Trees { get; set; }
        public TreeNode TreeNodes { get; set; }
    }
}
