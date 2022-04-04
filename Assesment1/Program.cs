using Assesment1.Exceptions;
using System;

namespace Assesment1
{
    class Program
    {
        private const int NO_NEXT = -1;
        private const int MAX_WIDTH = 300000;
        private const int MAX_LENGTH = 300000;
        private const float MIN_COLOR = -1000000000;
        private const int MAX_COLOR = 1000000000;
        private static readonly (int, int) NO_NEXT_LOCATION = new(NO_NEXT, NO_NEXT);
        
        private Locations countedLocations = new Locations();
        private (int,int) nextLocation; 
        private int nextX;
        private int nextY;

        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Enter map width");
                int width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter map length");
                int length = Convert.ToInt32(Console.ReadLine());

                //cannot figure out how to read an array
                //int[] map = new int[width, length];
                Console.Write("Input elements in the map :\n");
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        Console.Write("element - [{0},{1}] : ", i, j);
                        //map[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                //Console.WriteLine(string.Format("The map has {0} countries", Solution(map)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public int Solution(int[][] matrix)
        {
            ValidateMatrixSize(matrix);
            return TrasverseMatrix(matrix, 0,0);
        }

        public void ValidateMatrixSize(int[][] matrix)
        {
            if (matrix.Length > MAX_WIDTH || matrix[0].Length > MAX_LENGTH)
            {
                throw new OutOfBoundsException(string.Format("The size introduced exceeds the limit ({0}, {1})", MAX_WIDTH, MAX_LENGTH));
            }
        }

        //won't figure out what to do here
        public int TrasverseMatrix(int[][] matrix, int x, int y)
        {
            ValidateColor(matrix[x][y]);
            if (!IsCounted(x, y))
            {
                CountCountry(matrix, x, y, matrix[x][y]);
            }
            GetNextLocation(matrix, x, y);
            if (nextLocation == NO_NEXT_LOCATION)
            {
                return 1;
            }
            else
            {
                return TrasverseMatrix(matrix, nextLocation.Item1, nextLocation.Item2);
            }
        }

        public void ValidateColor(int color)
        {
            if (color > MIN_COLOR || color > MAX_COLOR)
                throw new OutOfBoundsException(string.Format("The color {0} is not accepted, colors must be between {1} and {2}", color, MIN_COLOR, MAX_COLOR));
        }

        public bool IsCounted(int x, int y)
        {
            return countedLocations.Contains(x, y);
        }

        public void CountCountry(int[][] matrix, int x, int y, int color)
        {
            countedLocations.AddNew(x, y);

            GetNextX(matrix, x);
            GetNextY(matrix, y);
            if(nextX != NO_NEXT && matrix[nextX][y] == color)
            {
                CountCountry(matrix, nextX, y, color);
            }
            if(nextY != NO_NEXT && matrix[x][nextY] == color)
            {
                CountCountry(matrix, x, nextY, color);
            }
        }

        public void GetNextLocation(int[][] matrix, int x, int y)
        {
            GetNextX(matrix, x);
            GetNextY(matrix, y);
            if (nextX != NO_NEXT)
                nextLocation = (nextX, y);
            else if (nextY != NO_NEXT)
                nextLocation = (0, nextY);
            else
                nextLocation = NO_NEXT_LOCATION;
        }

        public void GetNextX(int[][] matrix, int x)
        {

            if (x < matrix.Length)
                nextX = x + 1;
            else
                nextX = NO_NEXT;
        }

        public void GetNextY(int[][] matrix, int y)
        {

            if (y < matrix[0].Length)
                nextY = y + 1;
            else
                nextY = NO_NEXT;
        }
    }
}
