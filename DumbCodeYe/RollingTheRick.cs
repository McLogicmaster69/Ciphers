using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe
{
    public static class RollingTheRick
    {
        public static void Roll()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 1000) == 57)
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
    }
}
