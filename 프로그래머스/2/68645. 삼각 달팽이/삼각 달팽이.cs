using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int n) {
        var totalCount = n * (n + 1) / 2;

        int[][] snailTriangle = new int[n][];
        for (int i = 0; i < n; i++)
        {
            snailTriangle[i] = new int[i + 1];
        }

        // 0 : 아래, 1 : 오른쪽, 2 : 위쪽
        int[] dirX = { 1, 0, -1 };
        int[] dirY = { 0, 1, -1 };

        var x = -1;
        var y = 0;
        var number = 1;
        var dir = 0;

        while (number <= totalCount)
        {
            int indexX = x + dirX[dir];
            int indexY = y + dirY[dir]; 

            if (indexX >= n || indexY >= indexX + 1 || indexY < 0 || snailTriangle[indexX][indexY] != 0)
            {
                dir = (dir + 1) % 3;
                indexX = x + dirX[dir];
                indexY = y + dirY[dir];
            }

            snailTriangle[indexX][indexY] = number++;
            x = indexX;
            y = indexY;
        }

        List<int> result = new List<int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                result.Add(snailTriangle[i][j]);
            }
        }

        return result.ToArray();
    }
}