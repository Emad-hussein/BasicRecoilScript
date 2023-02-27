using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int x, int y);

    [DllImport("user32.dll")]
    static extern short GetKeyState(int nVirtKey);

    const int VK_LBUTTON = 0x01;

    static void Main(string[] args)
    {
        while (true)
        {
            // Check if left mouse button is being held down
            if (GetKeyState(VK_LBUTTON) < 0)
            {
                // Get the current mouse cursor position
                POINT currentPosition;
                GetCursorPos(out currentPosition);

                // Move the mouse cursor down by 1 pixel
                SetCursorPos(currentPosition.x, currentPosition.y + 1);

                // Wait for a short period of time to slow down the cursor movement
                System.Threading.Thread.Sleep(10);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    [DllImport("user32.dll")]
    static extern bool GetCursorPos(out POINT lpPoint);
}
