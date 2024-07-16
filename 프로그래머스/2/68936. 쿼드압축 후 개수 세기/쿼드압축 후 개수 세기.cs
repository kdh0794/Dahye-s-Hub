using System;

public class Solution {
    public int[] solution(int[,] arr) {
        int[] answer = new int[] { };

        int rowCount = arr.GetLength(0);
        answer = DivisionArea(arr, 0, 0, rowCount);

        return answer;
    }

    private int[] DivisionArea(int[,] arr, int row, int col, int size)
    {
        if (IsSameValue(arr, row, col, size))
        {
            var value = arr[row, col];
            return value == 0 ? new int[] { 1, 0 } : new int[] { 0, 1 };
        }

        int newSize = size / 2;
        int[] leftTop = DivisionArea(arr, row, col, newSize);
        int[] rightTop = DivisionArea(arr, row + newSize, col, newSize);
        int[] leftBottom = DivisionArea(arr, row, col + newSize, newSize);
        int[] rightBottom = DivisionArea(arr, row + newSize, col + newSize, newSize);

        return new int[] { leftTop[0] + rightTop[0] + leftBottom[0] + rightBottom[0],
                          leftTop[1] + rightTop[1] + leftBottom[1] + rightBottom[1] };
    }

    private bool IsSameValue(int[,] arr, int x, int y, int size)
    {
        int value = arr[x, y];
        for (int i = x; i < x + size; i++)
        {
            for (int j = y; j < y + size; j++)
            {
                if (arr[i, j] != value)
                {
                    return false;
                }
            }
        }
        return true;
    }
}