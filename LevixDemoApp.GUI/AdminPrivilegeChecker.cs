using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace LevixDemoApp.GUI
{
    public static class AdminPrivilegeChecker
    {
        public static bool IsAppRunningAsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void CheckAndPromptForAdmin()
        {
            if (!IsAppRunningAsAdmin())
            {
                MessageBox.Show("The application needs to be run as Administrator. Please restart the application with Administrator privileges.", "Administrator Privileges Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
            }
        }
    }
}