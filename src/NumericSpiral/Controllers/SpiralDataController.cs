using System;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;


namespace NumericSpiral.Controllers
{
    public class SpiralDataController : Controller
    {

        public string Generate(int id)
        {
            // Basic numeric validation
            if (id < 0) return "[[0]]";

            // Determine the size of the grid and allocate memory
            id++;
            double b = Math.Sqrt(id);
            int a = (int) Math.Truncate(b);
            if (b - a > 0) a++;
            int i = (int) Math.Pow(a, 2);
            int[,] result = new int[a,a];

            // Set Initial Conditions
            int x = a-1, y = 0;
            int xr = -1, yr = 0;

            // Draw the spiral in memory using left turns
            for (var p = i; p > 0; p--)
            {
                // Set the number in memory, move on to
                // the next location
                result[y, x] = p-1;
                x += xr;
                y += yr;

                // Turn detection
                if (!(x < 0 || y < 0 || x > a-1 || y > a-1))
                    if (result[y, x] == 0) continue;

                // Turn cases
                if (xr == -1)
                {
                    x++; y++; xr = 0; yr = 1;
                    continue;
                }
                p++;
                if (yr == 1)
                {
                    y--; xr = 1; yr = 0;
                    continue;
                }
                if (xr == 1)
                {
                    x--; xr = 0; yr = -1;
                    continue;
                }
                if (yr == -1)
                {
                    y++; xr = -1; yr = 0;
                }
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}
