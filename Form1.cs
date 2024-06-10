using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using IWshRuntimeLibrary;

namespace Task_Generator
{
    public partial class Form1 : Form
    {
         private Dictionary<DayOfWeek, List<string>> tasks;
        private string weeklyTasksFolder;
       
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            tasks = new Dictionary<DayOfWeek, List<string>>
            {
                { DayOfWeek.Monday, new List<string>() },
                { DayOfWeek.Tuesday, new List<string>() },
                { DayOfWeek.Wednesday, new List<string>() },
                { DayOfWeek.Thursday, new List<string>() },
                { DayOfWeek.Friday, new List<string>() }
            };
            weeklyTasksFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "GK-Weekly-Task");
            if (!Directory.Exists(weeklyTasksFolder))
            {
                Directory.CreateDirectory(weeklyTasksFolder);
            }
            AddShortcutToStartup();
            checkTimeTimer.Interval = 60000; // Set timer interval to 6 seconds
            checkTimeTimer.Start();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkTimeTimer_Tick(object sender, EventArgs e)
        {
            // Get the current Philippine Time
            TimeZoneInfo philippineTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
            DateTime philippineTime = TimeZoneInfo.ConvertTime(DateTime.Now, philippineTimeZone);

            // Debugging output to check current time
            Console.WriteLine($"Current Philippine Time: {philippineTime}");

            // Check if it's 5:30 PM Philippine time
            if (philippineTime.Hour == 17 && philippineTime.Minute == 27)
            {
                Console.WriteLine("It's 5:30 PM Philippine Time");
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();

                // Check if it's Friday, then save the week's tasks to the file
                if (philippineTime.DayOfWeek == DayOfWeek.Monday)
                {
                    SaveWeeklyTasks();
                }
            }
        }

        // Save weekly tasks
        private void SaveWeeklyTasks()
        {
            string filePath = Path.Combine(weeklyTasksFolder, $"{DateTime.Now:yyyy-MM-dd}_WeeklyTasks.txt");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string header = "Weekly Tasks";
                string separator = new string('-', 30);
                writer.WriteLine(header.PadLeft((30 + header.Length) / 2).PadRight(30)); // Center the header
                writer.WriteLine(separator);

                foreach (var day in tasks.Keys)
                {
                    writer.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd} | Day: {day}");
                    if (tasks[day].Count == 0)
                    {
                        writer.WriteLine("**No Task Submitted on this day**");
                    }
                    else
                    {
                        foreach (var task in tasks[day])
                        {
                            writer.WriteLine($"{task}");
                        }
                    }
                    writer.WriteLine();
                }
            }

            // Reset tasks for the next week
            foreach (var day in tasks.Keys.ToList())
            {
                tasks[day].Clear();
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string task = taskTextBox.Text.Trim();

            if (!string.IsNullOrWhiteSpace(task))
            {
                try
                {
                    // Capitalize the first letter and add an asterisk
                    string formattedTask = "* " + char.ToUpper(task[0]) + task.Substring(1);
                    tasks[DateTime.Now.DayOfWeek].Add(formattedTask);

                    taskTextBox.Text = string.Empty;
                    MessageBox.Show("Task saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetFormattedTask()
        {
            // Your method to format the task
            // Example: string task = "* " + char.ToUpper(taskTextBox.Text[0]) + taskTextBox.Text.Substring(1);
            return taskTextBox.Text;
        }

        private void AddShortcutToStartup()
        {
            try
            {
                // Path to the executable
                string exePath = Application.ExecutablePath;

                // Path to the startup folder
                string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

                // Create a shortcut in the startup folder
                string shortcutPath = Path.Combine(startupFolderPath, "Task Generator.lnk");

                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.Description = "Task Generator";
                shortcut.TargetPath = exePath;
                shortcut.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create shortcut in startup folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
