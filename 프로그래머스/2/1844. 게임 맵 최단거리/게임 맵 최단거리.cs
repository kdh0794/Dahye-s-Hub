using System;
using System.Collections.Generic;

class Solution {
    public int solution(int[,] maps) {
        var rowCount = maps.GetLength(0);
        var columnCount = maps.GetLength(1);

        int[] dirX = { -1, 1, 0, 0 };
        int[] dirY = { 0, 0, -1, 1 };

        Queue<(int, int, int)> queue = new Queue<(int, int, int)>(); 
        bool[,] visited = new bool[rowCount, columnCount];

        queue.Enqueue((0, 0, 1));
        visited[0, 0] = true;

        while (queue.Count > 0)
        {
            var (x, y, distance) = queue.Dequeue();

            if (x == rowCount - 1 && y == columnCount - 1)
            {
                return distance;
            }

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dirX[i];
                int ny = y + dirY[i];

                if (nx >= 0 && nx < rowCount && ny >= 0 && ny < columnCount && maps[nx, ny] == 1 && !visited[nx, ny])
                {
                    queue.Enqueue((nx, ny, distance + 1));
                    visited[nx, ny] = true;
                }
            }
        }

        return -1;
    }
}