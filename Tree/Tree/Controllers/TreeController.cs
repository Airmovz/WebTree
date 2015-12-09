using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tree.Utility;
using Tree.Models;
using DBConnection.Model;
using DBConnection.Service;

namespace Tree.Controllers
{
    public class TreeController : Controller
    {
        #region Private variables
        private RetrieveService _retrieveService = new RetrieveService();
        private CreateService _createService = new CreateService();
        private Util util = new Util();
        #endregion

        #region Get Methods
        /// <summary>
        /// Method for viewing all user & it's tree
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UserList()
        {
            List<VMTreeList> treeList = new List<VMTreeList>();
            treeList = _retrieveService.GetAllTreeList().ToList();

            return View(treeList);
        }

        /// <summary>
        /// This method is use for displaying 
        /// tree base on selected user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="treeId"></param>
        /// <returns>
        /// View(VMDisplay)
        /// </returns>
        [HttpGet]
        public ActionResult Index(int userId = 1, int treeId = 1)
        {
            #region Initialize variables
            List<TreeNode> treeNodeList = new List<TreeNode>();
            List<TreeNode> sortedNodeList = new List<TreeNode>();
            VMDisplay vmDisplay = new VMDisplay();
            List<TreeNode> minNode = new List<TreeNode>();
            List<TreeNode> maxNode = new List<TreeNode>();

            int sum = 0;
            int maxValue = 0;
            int minValue = 0;
            int totalNode = 0;
            #endregion

            #region Retrieve Data
            treeNodeList = _retrieveService.GetTreeByUser(userId, treeId);
            #endregion

            vmDisplay.TotalNode = treeNodeList.Count;
            totalNode = treeNodeList.Count;

            if (totalNode != 0)
            {
                sortedNodeList = util.Sort(treeNodeList);
                sum = util.Sum(sortedNodeList);
                minNode = util.Min(sortedNodeList);
                minValue = util.MinValue(sortedNodeList);
                maxNode = util.Max(sortedNodeList);
                maxValue = util.MaxValue(sortedNodeList);

                vmDisplay.UserId = userId;
                vmDisplay.Sum = sum;
                vmDisplay.MinValue = minValue;
                vmDisplay.MinTree = minNode;
                vmDisplay.MaxValue = maxValue;
                vmDisplay.MaxTree = maxNode;
                vmDisplay.CompleteTree = sortedNodeList;
            }

            return View(vmDisplay);
        }

        /// <summary>
        /// Method for displaying Create Tree page
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// View with parameter VMTreeCreate
        /// </returns>
        [HttpGet]
        public ActionResult CreateTree(int userId)
        {
            VMTreeCreate tree = new VMTreeCreate();
            TempData["UserId"] = userId;

            return View(tree);
        }

        /// <summary>
        /// Method for displaying Create child node page
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="sort"></param>
        /// <param name="treeId"></param>
        /// <returns>
        /// View with parameter TreeNode
        /// </returns>
        [HttpGet]
        public ActionResult CreateChildNode(int parentId, string sort, int treeId)
        {
            TreeNode treeNode = new TreeNode();
            ViewBag.ParentId = parentId;
            ViewBag.Sort = sort;
            ViewBag.TreeId = treeId;

            return View(treeNode);
        }

        /// <summary>
        /// Method for displaying Create User page
        /// </summary>
        /// <returns>
        /// View
        /// </returns>
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        #endregion

        #region Post Methods
        /// <summary>
        /// Method for creating new tree
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="userId"></param>
        /// <returns>
        /// Redirect to Index method [HttpGet]
        /// </returns>
        [HttpPost]
        public ActionResult CreateTree(VMTreeCreate tree, int userId)
        {
            int newTreeId = 0;
            try
            {
                newTreeId = _createService.CreateTree(userId, tree.Trees, tree.TreeNodes);
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return RedirectToAction("Index", new { userId = userId, treeId = newTreeId });
        }

        /// <summary>
        /// Method for creating new child node
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="parentId"></param>
        /// <param name="sort"></param>
        /// <param name="treeId"></param>
        /// <returns>
        /// Redirect to Index method [HttpGet]
        /// </returns>
        [HttpPost]
        public ActionResult CreateChildNode(TreeNode tree, int parentId, string sort, int treeId)
        {
            int newTreeId = 0;
            try
            {
                newTreeId = _createService.CreateChildNode(1, parentId, treeId, sort, tree);
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return RedirectToAction("Index", new { userId = 1, treeId = treeId });
        }

        /// <summary>
        /// Method for creating new user
        /// </summary>
        /// <param name="userTree"></param>
        /// <returns>
        /// Redirect to UserList method [HttpGet]
        /// </returns>
        [HttpPost]
        public ActionResult CreateUser(VMTreeCreate userTree)
        {
            int newTreeId = 0;
            try
            {
                newTreeId = _createService.CreateUser(userTree.Users, userTree.Trees, userTree.TreeNodes);
            }
            catch (Exception e)
            {
                string error = e.Message;
            }

            return RedirectToAction("UserList");
        }

        #endregion
    }
}