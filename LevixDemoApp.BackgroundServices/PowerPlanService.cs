using System;
using System.Diagnostics;

namespace LevixDemoApp.BackgroundServices
{
    public class PowerPlanService
    {
        public void ChangePowerPlan()
        {
            try
            {
                // Prevent the system from going into sleep mode
                ExecuteCommand("powercfg /change standby-timeout-ac 0");
                ExecuteCommand("powercfg /change standby-timeout-dc 0");

                // Log execution
                Console.WriteLine("Power plan changed to prevent sleep mode.");
            }
            catch (Exception ex)
            {
                // Log detailed error
                Console.WriteLine($"Error changing power plan: {ex.Message}\n{ex.StackTrace}");
            }
        }

        public void ScheduleShutdown(string time)
        {
            try
            {
                // Expecting time in 24-hour format as HH:mm, e.g., "20:00" for 8 PM
                var shutdownTime = DateTime.Today.Add(TimeSpan.Parse(time));
                var currentTime = DateTime.Now;

                // Adjust shutdownTime to the next day if currentTime has passed shutdownTime
                if (currentTime > shutdownTime)
                {
                    shutdownTime = shutdownTime.AddDays(1);
                }

                var delayInSeconds = (int)(shutdownTime - currentTime).TotalSeconds;

                if (delayInSeconds > 0)
                {
                    // Schedule shutdown
                    ExecuteCommand($"shutdown -s -t {delayInSeconds}");

                    // Log execution
                    Console.WriteLine($"Shutdown scheduled at {shutdownTime}.");
                }
                else
                {
                    Console.WriteLine("Invalid shutdown time provided. Time must be in the future.");
                }
            }
            catch (FormatException ex)
            {
                // Log detailed error for invalid time format
                Console.WriteLine($"Error scheduling shutdown due to invalid time format: {ex.Message}\n{ex.StackTrace}");
            }
            catch (Exception ex)
            {
                // Log detailed error for other exceptions
                Console.WriteLine($"Error scheduling shutdown: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void ExecuteCommand(string command)
        {
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                
                using (Process proc = new Process())
                {
                    proc.StartInfo = procStartInfo;
                    proc.Start();

                    // Read the output stream first and then wait.
                    string result = proc.StandardOutput.ReadToEnd();
                    proc.WaitForExit();

                    // Log command execution
                    Console.WriteLine($"Executed command: {command}\nResult: {result}");
                }
            }
            catch (Exception ex)
            {
                // Log detailed error
                Console.WriteLine($"Error executing command '{command}': {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}