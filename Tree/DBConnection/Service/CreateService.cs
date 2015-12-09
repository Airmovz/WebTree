using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection.Model;

namespace DBConnection.Service
{
    public class CreateService
    {
        private AppContext _db = new AppContext();

        /// <summary>
        /// Method for creating tree
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tree"></param>
        /// <param name="treeNode"></param>
        /// <returns>
        /// newly inserted tree id
        /// </returns>
        public int CreateTree(int userId, Tree tree, TreeNode treeNode)
        {

            #region Initialize variables
            Tree t = new Tree();
            UserTreeMapping utm = new UserTreeMapping();
            TreeNode tn = new TreeNode();
            int treeId = 0;
            #endregion

            try
            {
                #region inserting data to Tree table
                t.TreeDescription = tree.TreeDescription;
                _db.Tree.Add(t);
                _db.SaveChanges();
                #endregion
                treeId = t.Id;

                #region inserting data to UserTreeMapping table
                utm.UserId = userId;
                utm.TreeId = treeId;
                _db.UserTreeMapping.Add(utm);
                _db.SaveChanges();
                #endregion

                #region inserting data to TreeNode table
                tn.ParentId = 0;
                tn.TreeId = treeId;
                tn.Value = treeNode.Value;
                tn.Text = treeNode.Text;
                _db.TreeNode.Add(tn);
                _db.SaveChanges();
                #endregion

                #region update sort column in TreeNode table
                tn.Sort = "0:" + tn.Id.ToString();
                _db.Entry(tn).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                #endregion
            }
            catch (Exception e)
            {
                treeId = -1;
            }

            return treeId;
        }

        /// <summary>
        /// Method for creating child node
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="parentId"></param>
        /// <param name="treeId"></param>
        /// <param name="sort"></param>
        /// <param name="treeNode"></param>
        /// <returns>
        /// newly inserted child node id
        /// </returns>
        public int CreateChildNode(int userId, int parentId, int treeId, string sort, TreeNode treeNode)
        {
            #region Initialize variables
            TreeNode tn = new TreeNode();
            TreeNode t = new TreeNode();
            int childNodeId = 0;
            #endregion

            try
            {
                #region Inserting data to TreeNode table
                tn.ParentId = parentId;
                tn.TreeId = treeId;
                tn.Value = treeNode.Value;
                tn.Text = treeNode.Text;
                _db.TreeNode.Add(tn);
                _db.SaveChanges();
                #endregion
                childNodeId = tn.Id;

                #region Modify sort column of TreeNode table
                tn.Sort = sort + ":" + childNodeId.ToString();
                _db.Entry(tn).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                #endregion
            }
            catch (Exception e)
            {
                childNodeId = -1;
            }

            return childNodeId;
        }

        /// <summary>
        /// Method for creating User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="tree"></param>
        /// <param name="treeNode"></param>
        /// <returns>
        /// newly created user id
        /// </returns>
        public int CreateUser(Users user, Tree tree, TreeNode treeNode)
        {
            #region Initialize variables
            Users u = new Users();
            Tree t = new Tree();
            UserTreeMapping utm = new UserTreeMapping();
            TreeNode tn = new TreeNode();
            int treeId = 0;
            int userId = 0;
            #endregion

            try
            {
                #region Inserting data to Users table
                u.Username = user.Username;
                _db.Users.Add(u);
                _db.SaveChanges();
                #endregion
                userId = u.Id;

                #region Inserting data to Tree table
                t.TreeDescription = tree.TreeDescription;
                _db.Tree.Add(t);
                _db.SaveChanges();
                #endregion
                treeId = t.Id;

                #region Inserting data to UserTreeMapping table
                utm.UserId = userId;
                utm.TreeId = treeId;
                _db.UserTreeMapping.Add(utm);
                _db.SaveChanges();
                #endregion

                #region Inserting data to TreeNode table
                tn.ParentId = 0;
                tn.TreeId = treeId;
                tn.Value = treeNode.Value;
                tn.Text = treeNode.Text;
                _db.TreeNode.Add(tn);
                _db.SaveChanges();
                #endregion

                #region Updating sort column of TreeNode table
                tn.Sort = "0:" + tn.Id.ToString();
                _db.Entry(tn).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                #endregion
            }
            catch (Exception e)
            {
                userId = -1;
            }

            return userId;
        }
    }
}
