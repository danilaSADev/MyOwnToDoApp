using System;
using System.Collections;
using System.Collections.Generic;

namespace TasksLibrary {
    public class TaskCollection : IEnumerable<Task> {
        private static TaskCollection obj;
        private static List<Task> tasksList;

        static TaskCollection() {
            tasksList = new List<Task>();
        }
        private TaskCollection() {}

        public static TaskCollection getInstance() {
            if (obj == null)
                obj = new TaskCollection();
            return obj;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return tasksList.GetEnumerator();
        }

        IEnumerator<Task> IEnumerable<Task>.GetEnumerator() {
            return tasksList.GetEnumerator();
        }

        public static void Create(string name, string desc, DateTime deadline) {
            Task newTask = new Task(name, desc, deadline);
            System.Console.WriteLine(newTask.GetHashCode());
            tasksList.Add(newTask);
        }
        public static bool Edit(int index, string Name, string Description, DateTime Deadline) {
            if (index < tasksList.Count && index > 0) {
                tasksList[index].Edit(Name, Description, Deadline);
                return true;
            } else
                return false;
        } 
        public static bool Edit(int index, string Name, string Description) {
            if (index < tasksList.Count && index > 0) {
                tasksList[index].Edit(Name, Description);
                return true;
            } else
                return false;
        } 
        public static bool Edit(int index, string Name) {
            if (index < tasksList.Count && index > 0) {
                tasksList[index].Edit(Name);
                return true;
            } else
                return false;
        } 
        public static bool Remove(int index) {
            if (index < tasksList.Count && index > 0) {
                tasksList.RemoveAt(index);
                //TaskCollection.Refresh();
                return true;
            } else
                return false;
        }

        public static void Refresh( ) {
            for (int i = 0; i < tasksList.Count; i++) {
                Task tmp = tasksList[i];
                if (tmp.IsOutdated) {
                    tasksList.RemoveAt(i);
                    i--;
                }
            }
            tasksList.Sort();
        }

        public static int Count { get => tasksList.Count; }


    }   
}