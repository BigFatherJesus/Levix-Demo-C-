using System;
using System.Runtime.InteropServices;

namespace LevixDemoApp.BackgroundServices
{
    public class VolumeService
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;
        private static IntPtr HWND_BROADCAST = new IntPtr(0xffff);

        public void MuteSystemVolume()
        {
            try
            {
                SendMessageW(HWND_BROADCAST, WM_APPCOMMAND, HWND_BROADCAST, (IntPtr)APPCOMMAND_VOLUME_MUTE);
                Console.WriteLine("System volume has been muted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while trying to mute system volume: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}