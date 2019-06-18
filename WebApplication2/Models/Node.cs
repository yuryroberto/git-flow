using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Models
{
    //https://stackoverflow.com/questions/66893/tree-data-structure-in-c-sharp#comment5199065_2012855
    public class Node<T> : IEnumerable<Node<T>>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }

        public Boolean IsRoot
        {
            get { return Parent == null; }
        }
        public Boolean IsLeaf
        {
            get { return Children.Count == 0; }
        }

        public int Level
        {
            get
            {
                if (this.IsRoot)
                    return 0;
                return Parent.Level + 1;
            }
        }

        public Node(T data)
        {
            this.Data = data;
            this.Children = new List<Node<T>>();

            this.ElementsIndex = new LinkedList<Node<T>>();
            this.ElementsIndex.Add(this);
        }

        public Node<T> AddChild(T child)
        {
            Node<T> childNode = new Node<T>(child) { Parent = this };
            Children.Add(childNode);
            return childNode;
        }

        public bool RemoveChild(Node<T> node)
        {
            return Children.Remove(node);
        }

        #region searching

        private ICollection<Node<T>> ElementsIndex { get; set; }

        private void RegisterChildForSearch(Node<T> node)
        {
            ElementsIndex.Add(node);
            if (Parent != null)
                Parent.RegisterChildForSearch(node);
        }

        public Node<T> FindTreeNode(Func<Node<T>, bool> predicate)
        {
            return this.ElementsIndex.FirstOrDefault(predicate);
        }

        #endregion

        #region iterating

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            yield return this;
            foreach (var directChild in this.Children)
            {
                foreach (var anyChild in directChild)
                    yield return anyChild;
            }
        }

        #endregion
    }
}