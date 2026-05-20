using System;
using System.Collections.Generic;

namespace Task_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaskItem> myTasks = new List<TaskItem>();
            bool isRunning = true;
            int nextId = 1;

            while (isRunning)
            {
                ShowMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":

                        if (AddTask(myTasks, nextId))
                        {
                            nextId++;
                        }
                        break;

                    case "2":

                        ViewTasks(myTasks);
                        break;

                    case "3":

                        EditTask(myTasks);
                        break;

                    case "4":

                        CompleteTask(myTasks);
                        break;

                    case "5":

                        DeleteTask(myTasks);
                        break;

                    case "6":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.\n");
                        break;
                }           
            }
        }

        static bool AddTask(List<TaskItem> tasks, int taskId)
        {
            Console.WriteLine("Enter title");
            string title = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty.\n");
                return false;
            }
            Console.WriteLine("Enter description");
            string description = Console.ReadLine() ?? "";

            TaskItem newTask = new TaskItem(taskId, title, description);
            tasks.Add(newTask);

            return true;
        }

        static void ViewTasks(List<TaskItem> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.\n");
                return;
            }
            
            foreach (TaskItem task in tasks)
            {
                 PrintTask(task);
            }
            
        }

        static void EditTask(List<TaskItem> tasks)
        {
            if (!TryReadTaskId("edit", out int taskIdToEdit))
            {
                return;
            }

            TaskItem? taskToEdit = FindTaskById(tasks, taskIdToEdit);

            if (taskToEdit == null)
            {
                Console.WriteLine("Task not found.\n");
                return;
            }

            bool changed = false;

            Console.WriteLine($"Current title: {taskToEdit.Title}");
            Console.WriteLine("Enter new title (leave empty to keep current):");

            string newTitleInput = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(newTitleInput))
            {
                taskToEdit.Title = newTitleInput;
                changed = true;
            }

            Console.WriteLine($"Current description: {taskToEdit.Description}");
            Console.WriteLine("Enter new description (leave empty to keep current):");

            string newDescriptionInput = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(newDescriptionInput))
            {
                taskToEdit.Description = newDescriptionInput;
                changed = true;
            }

            if (changed)
            { 
                Console.WriteLine("Task updated.\n");
            }
            else
            {
                Console.WriteLine("No changes made.\n");
            }
        }

        static void CompleteTask(List<TaskItem> tasks)
        {
            if (!TryReadTaskId("complete", out int taskIdToComplete))
            {
                return;
            }

            TaskItem? taskToComplete = FindTaskById(tasks, taskIdToComplete);

            if (taskToComplete == null)
            {
                Console.WriteLine("Task not found.\n");
                return;
            }

            taskToComplete.IsCompleted = true;
            Console.WriteLine("Task marked as completed.\n");
        }

        static void DeleteTask(List<TaskItem> tasks)
        {

            if (!TryReadTaskId("delete", out int taskIdToDelete))
            {
                return;
            }

            TaskItem? taskToDelete = FindTaskById(tasks, taskIdToDelete);

            if (taskToDelete == null)
            {
                Console.WriteLine("Task not found.\n");
                return;
            }

            tasks.Remove(taskToDelete);
            Console.WriteLine("Task deleted.\n");
        }

        static TaskItem? FindTaskById(List<TaskItem> tasks, int taskId)
        {
            foreach (TaskItem task in tasks)
            {
                if (task.Id == taskId)
                {
                    return task;
                }
            }

            return null;
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Edit task");
            Console.WriteLine("4. Complete task");
            Console.WriteLine("5. Delete task");
            Console.WriteLine("6. Exit\n");
        }

        static void PrintTask(TaskItem task)
        {
            Console.WriteLine($"ID: {task.Id}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Is completed: {task.IsCompleted}\n");
        }

        static bool TryReadTaskId(string action, out int taskId)
        {
            Console.WriteLine($"Enter task ID to {action}:");
            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out taskId))
            {
                Console.WriteLine("Please enter a valid number.");
                return false;
            }

            return true;
        }
    }
}