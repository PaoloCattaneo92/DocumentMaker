using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This class renders as a list of CheckBoxes (checked or not)
    /// </summary>
    public class TaskList : RenderedObj
    {
        protected List<Task> Items;

        /// <summary>
        /// Constructor. Initialize an empty list.
        /// </summary>
        public TaskList()
        {
            Items = new List<Task>();
        }

        /// <summary>
        /// Constructor. Initialize the list with the given
        /// parameter
        /// </summary>
        /// <param name="items">First elements of the list</param>
        public TaskList(params string[] items) : this()
        {
            foreach(string i in items)
            {
                AddItem(i);
            }
        }

        public TaskList(params Task[] tasks) : this()
        {
            foreach(Task t in tasks)
            {
                AddItem(t);
            }
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="task">A task item</param>
        public void AddItem(Task task)
        {
            Items.Add(task);
        }
        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="taskNotDone">A task (with <see cref="Task.Done"/> set to false)</param>
        public void AddItem(string taskNotDone)
        {
            Items.Add(new Task(taskNotDone));
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="task"><see cref="Task.Text"/></param>
        /// <param name="done"><see cref="Task.Done"/></param>
        public void AddItem(string task, bool done)
        {
            Items.Add(new Task(task, done));
        }
        /// <summary>
        /// Append the rendered content of this <see cref="RenderedObj"/>
        /// to the given StringBuilder.
        /// </summary>
        /// <param name="sb">The StringBuilder where the rendered content will be appended</param>
        /// <returns>The same StringBuilder but with this content appendend</returns>
        public override StringBuilder Render(StringBuilder sb)
        {
            foreach (Task task in Items)
            {
                sb.Append("- [");
                if (task.Done)
                    sb.Append("X] ");
                else
                    sb.Append(" ] ");
                sb.Append(task.Text).Append("\n");
            }
            return sb;
        }
    }
}
