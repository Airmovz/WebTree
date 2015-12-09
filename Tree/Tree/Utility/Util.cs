using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection.Model;
using Tree.Models;

namespace Tree.Utility
{
    public class Util
    {
        /// <summary>
        /// Method for sorting tree in descending order
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>
        /// sorted tree
        /// </returns>
        public List<TreeNode> Sort(List<TreeNode> tree)
        {
            List<TreeNode> sortedTree = new List<TreeNode>();

            sortedTree = tree.OrderBy(t => t.ParentId).ThenByDescending(t => t.Value).ToList();

            return sortedTree;
        }
        
        /// <summary>
        /// Method for getting the sum of all
        /// values of the tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>
        /// sum of all node values
        /// </returns>
        public int Sum(List<TreeNode> tree)
        {
            int sum = 0;
            foreach (var node in tree)
            {
                sum += node.Value;
            }

            return sum;
        }

        /// <summary>
        /// Method for getting the minimum value of the tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>
        /// minimum value
        /// </returns>
        public int MinValue(List<TreeNode> tree) {
            int min = 0;            
            min = tree.Min(t => t.Value);
                                   
            return min;
        }

        /// <summary>
        /// Method for getting the tree node with 
        /// the minimum value from the tree.
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>
        /// list of treenode
        /// </returns>
        public List<TreeNode> Min(List<TreeNode> tree)
        {
            int min = 0;
            string sort = "";
            List<TreeNode> minNodeList = new List<TreeNode>();
            List<TreeNode> minNodeMember = new List<TreeNode>();
            List<TreeNode> temp = new List<TreeNode>();
            List<TreeNode> finalList = new List<TreeNode>();
            List<List<TreeNode>> vmTree = new List<List<TreeNode>>();

            min = tree.Min(t => t.Value);
            minNodeList = tree.Where(n => n.Value == min).ToList();

            foreach (var t in minNodeList)
            {
                finalList.Add(t);
                sort = t.Sort + ":";
                temp = tree.Where(n => n.Sort.Contains(sort)).ToList();

                foreach (var x in temp)
                {
                    finalList.Add(x);
                }
                vmTree.Add(finalList);
            }

            return finalList;
        }

        /// <summary>
        /// Method for getting the maximum value of the tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>
        /// maximum value
        /// </returns>
        public int MaxValue(List<TreeNode> tree)
        {
            int max = 0;
            max = tree.Max(t => t.Value);

            return max;
        }

        /// <summary>
        /// Method for getting the tree node with 
        /// the maximum value from the tree.
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>
        /// list of treenode
        /// </returns>
        public List<TreeNode> Max(List<TreeNode> tree)
        {
            int max = 0;
            string sort = "";
            List<TreeNode> maxNodeList = new List<TreeNode>();
            List<TreeNode> temp = new List<TreeNode>();
            List<TreeNode> finalList = new List<TreeNode>();

            max = MaxValue(tree);
            maxNodeList = tree.Where(n => n.Value == max).ToList();

            foreach (var t in maxNodeList)
            {
                finalList.Add(t);
                sort = t.Sort + ":";
                temp = tree.Where(n => n.Sort.Contains(sort)).ToList();

                foreach (var x in temp)
                {
                    finalList.Add(x);
                }
            }

            return finalList;
        }
    }
}
