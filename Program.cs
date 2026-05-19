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
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. View tasks");
                Console.WriteLine("3. Complete task");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter title");
                        string title = Console.ReadLine() ?? "";
                        if (title == "")
                        {
                            Console.WriteLine("Title cannot be empty.");
                            break;
                        }
                        Console.WriteLine("Enter description");
                        string description = Console.ReadLine() ?? "";

                        TaskItem newTask = new TaskItem(nextId, title, description);
                        myTasks.Add(newTask);
                        nextId++;
                        break;

                    case "2":
                        foreach (TaskItem task in myTasks)
                        {
                            Console.WriteLine($"ID: {task.Id}");
                            Console.WriteLine($"Title: {task.Title}");
                            Console.WriteLine($"Description: {task.Description}");
                            Console.WriteLine($"Is completed: {task.IsCompleted}\n");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Enter task ID to complete:");
                        string input = Console.ReadLine() ?? "";

                        if (!int.TryParse(input, out int taskId))
                        {
                            Console.WriteLine("Please enter a valid number.");
                            break;
                        }

                        TaskItem? taskToComplete = null;

                        foreach (TaskItem task in myTasks)
                        {
                            if (task.Id == taskId)
                            {
                                taskToComplete = task;
                                break;
                            }
                        }

                        if (taskToComplete == null)
                        {
                            Console.WriteLine("Task not found.");
                        }
                        else
                        {
                            taskToComplete.IsCompleted = true;
                            Console.WriteLine("Task marked as completed.");
                        }

                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }           
            }
        }
    }
}