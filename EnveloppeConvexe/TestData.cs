using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnveloppeConvexe
{
    internal static class TestData
    {
        static float[,] data = new float[,]
        {
            { 1, 4 },
            { 3, 8 },
            { 4, 5 },
            { 4, 4 },
            { 3, 3 },
            { 3, 1 },
            { 5, 7 },
            { 6, 5 },
            { 6, 3 },
            { 7, 2 },
            { 9, 5 },
        };

        public static Point[] GetDatas()
        {
            int size = data.GetLength(0);
            Point[] points = new Point[size];
            for (int i = 0; i < size; i++)
            {
                points[i] = new Point(data[i, 0], data[i, 1]);
            }
            return points;
        }
    }
}
