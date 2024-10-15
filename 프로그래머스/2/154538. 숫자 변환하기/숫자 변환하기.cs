using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int x, int y, int n) {
        if(x == y)
        {
            return 0;
        }

        // (현재 값, 연산 횟수)
        Queue<(int, int)> queue = new Queue<(int, int)>();
        HashSet<int> visited = new HashSet<int>();
        queue.Enqueue((x, 0));
        visited.Add(x);

        while (queue.Count > 0) 
        { 
            var firstQueue = queue.Dequeue();

            if(firstQueue.Item1 == y)
            {
                return firstQueue.Item2;
            }

            var plusN = firstQueue.Item1 + n;
            var multiply2 = firstQueue.Item1 * 2;
            var multiply3 = firstQueue.Item1 * 3;

            if(plusN <= y && !visited.Contains(plusN))
            {
                queue.Enqueue((plusN, firstQueue.Item2 + 1));
                visited.Add(plusN);
            }

            if (multiply2 <= y && !visited.Contains(multiply2))
            {
                queue.Enqueue((multiply2, firstQueue.Item2 + 1));
                visited.Add(multiply2);
            }

            if (multiply3 <= y && !visited.Contains(multiply3))
            {
                queue.Enqueue((multiply3, firstQueue.Item2 + 1));
                visited.Add(multiply3);
            }
        }

        return -1;
    }
}