using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.BST
{
    public class BST
    {
        int count;
        Node root;
        public BST()
        {

        }
        public bool Delete(int data)
        {
            bool isDeleted = false;
            Node deletedNode = Find(data);
            if (deletedNode == null)
                return false;
            isDeleted = DeleteHelper(deletedNode);
            //If the deleteNode is not deleted by the DeleteHelper method then the deleteNode must have both child.
            //So we should delete in the below code
            if(!isDeleted)
            {
                //If not deleted then we can promote the node from any side.
                //Code to get the minimum node from the right side and promote it to current position
                Node aux = FindMinimum(deletedNode.right);
                deletedNode.data = aux.data;
                DeleteHelper(aux);
                
                //Code to get the maximum node from the left side and promote it to current position
                //Node aux = FindMaximum(deletedNode.left);
                //deletedNode.data = aux.data;
                //DeleteHelper(aux);
                //isDeleted = true;
            }
            return isDeleted;
        }
        private bool DeleteHelper(Node node)
        {
            bool isDeleted = false;
            Node aux = node.parent;
            //If it is the child node then just delete the node
            if (node.left == null && node.right == null)
            {
                if (aux.left == node)
                    aux.left = null;
                else
                    aux.right = null;
                isDeleted = true;
            }
            //If the node have only one child then promote the child to the position of the deleted node.
            else if (node.left == null)
            {
                if (aux.left == node)
                    aux.left = node.right;
                else
                    aux.right = node.right;
                isDeleted = true;
            }
            else if (node.right == null)
            {
                if (aux.left == node)
                    aux.left = node.left;
                else
                    aux.right = node.left;
                isDeleted = true;
            }
            return isDeleted;
        }
        public Node Find(int data)
        {
            if (root == null)
                return null;
            Node aux = root;
            while (aux != null || aux.data != data)
            {
                if(aux.data<data)
                {
                    aux = aux.left;
                }
                else
                {
                    aux = aux.right;
                }
            }
            return aux;
        }

        public bool Insert(int data)
        {
            if(root==null)
            {
                root = new Node(data);
                return true;
            }
            Node previous = null;
            Node current = root;
            bool addLeft = true;
            while(current != null)
            {
                if(data<= current.data)
                {
                    previous = current;
                    current = current.left;
                    addLeft = true;
                }
                else
                {
                    previous = current;
                    current = current.right;
                    addLeft = false;
                }
            }
            if(addLeft)
            {
                previous.left = new Node(data);
            }
            else
            {
                previous.right = new Node(data);
            }
            return true;
        }
        public Node Predecessor(Node node)
        {
            Node predecessor = null;
            if (node == null)
                return predecessor;
            if (node.left != null)
                predecessor = FindMaximum(node.left);
            else
            {
                Node aux = node;
                Node parent = aux.parent;
                while(parent!=null && parent.left==aux)
                {
                    aux = parent;
                    parent = parent.parent;
                }
                predecessor = parent;
            }
            return predecessor;
        }
        public Node Successor(Node node)
        {
            Node successor = null;
            if (node == null)
                return successor;
            if(node.right!=null)
            {
                successor = FindMinimum(node.right);
            }
            else
            {
                Node aux = node;
                Node parent = node.parent;
                while(parent!=null && parent.right==aux)
                {
                    aux = parent;
                    parent = parent.parent;
                }
                successor = parent;
            }
            return successor;
        }


        private Node FindMinimum(Node node)
        {
            return (node == null || node.left != null) ? node : FindMinimum(node.left);
        }
        private Node FindMaximum(Node node)
        {
            return (node == null || node.right != null) ? node : FindMaximum(node.right);
        }

    }
    public class Node
    {
        public int data;
        public int height;
        public Node left, right, parent;
        public Node()
        {
        }
        public Node(int data)
        {
            this.data = data;
        }
        public Node(int data, int height)
        {
            this.data = data;
            this.height = height;
        }
        public Node(int data, int height, Node parent)
        {
            this.data = data;
            this.parent = parent;
            this.height = height;
        }
        public Node(int data, int height,Node parent, Node left, Node right)
        {
            this.data = data;
            this.height = height;
            this.parent = parent;
            this.left = left;
            this.right = right;
        }
    }
}
