using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection.Model;

namespace DBConnection.Service
{
    public class RetrieveService
    {
        private AppContext _db = new AppContext();

        /// <summary>
        /// Method for getting specific tree of a user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="treeId"></param>
        /// <returns>
        /// TreeNode
        /// </returns>
        public List<TreeNode> GetTreeByUser(int userId, int treeId)
        {
            List<TreeNode> treeNode = new List<TreeNode>();

            treeNode = (from u in _db.Users
                        join utm in _db.UserTreeMapping on u.Id equals utm.UserId
                        join t in _db.Tree on utm.TreeId equals t.Id
                        join tn in _db.TreeNode on t.Id equals tn.TreeId
                        where u.Id == userId && t.Id == treeId
                        select tn).ToList();

            return treeNode;
        }

        /// <summary>
        /// Method for getting all trees
        /// </summary>
        /// <returns>
        /// treelist
        /// </returns>
        public List<VMTreeList> GetAllTreeList()
        {
            List<VMTreeList> treeList = new List<VMTreeList>();

            treeList = (from u in _db.Users
                        join utm in _db.UserTreeMapping on u.Id equals utm.UserId
                        join t in _db.Tree on utm.TreeId equals t.Id
                        select new VMTreeList()
                        {
                            UserId = u.Id,
                            TreeId = t.Id,
                            Username = u.Username,
                            TreeDescription = t.TreeDescription
                        }).ToList();

            return treeList;
        }
    }
}