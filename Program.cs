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
                Console.WriteLine("3. Exit");

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