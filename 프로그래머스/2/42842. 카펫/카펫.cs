using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int brown, int yellow) {
        List<int> answerList = new List<int>();
        int totalGrid = brown + yellow;

        int column = brown / 2;

        while (column > 0)
        {
            if (totalGrid % column == 0)
            {
                var row = totalGrid / column;

                if(column >= row)
                {
                    if((column - 2) * (row - 2) == yellow)
                    {
                        answerList.Add(column);
                        answerList.Add(row);
                        break;
                    }
                }
            }
            column--;
        }

        return answerList.ToArray();
    }
}