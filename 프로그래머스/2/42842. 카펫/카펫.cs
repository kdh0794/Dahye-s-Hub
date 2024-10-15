using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int brown, int yellow) {
        List<int> answerList = new List<int>();
        int totalGrid = brown + yellow;

        int column = brown / 2;
        int row = column;

        HashSet<(int x, int y)> gridHash = new HashSet<(int x, int y)>();

        while (column > 0)
        {
            if (totalGrid % column == 0 && gridHash.Contains((column, row)) == false)
            {
                gridHash.Add((column, totalGrid / column));
            }
            column--;
        }

        foreach(var grid in gridHash)
        {
            if(grid.x >= grid.y)
            {
                if((grid.x - 2) * (grid.y - 2) == yellow)
                {
                    answerList.Add(grid.x);
                    answerList.Add(grid.y);
                }
            }
        }

        return answerList.ToArray();
    }
}