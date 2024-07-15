using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] queue1, int[] queue2) {
        int answer = 0;

        var q1 = new Queue<long>(queue1.Select(s => (long)s));
        var q2 = new Queue<long>(queue2.Select(s => (long)s));

        long sumQueue1 = q1.Sum();
        long sumQueue2 = q2.Sum();

        double totalSum = sumQueue1 + sumQueue2;
        if (totalSum % 2 != 0) 
            return -1;

        double halfSum = totalSum / 2;
        int length = queue1.Length;
        int[] totalArray = new int[2 * length];

        Array.Copy(queue1, 0, totalArray, 0, length);
        Array.Copy(queue2, 0, totalArray, length, length);

        int indexOfQueue1 = 0;
        int indexOfQueue2 = length;

        double currentSum = sumQueue1;

        while (indexOfQueue1 < totalArray.Length && indexOfQueue2 < totalArray.Length)
        {
            if (currentSum == halfSum) 
                return answer;

            if (currentSum < halfSum)
            {
                currentSum += totalArray[indexOfQueue2];
                indexOfQueue2++;
            }
            else
            {
                currentSum -= totalArray[indexOfQueue1];
                indexOfQueue1++;
            }

            answer++;

            if (indexOfQueue1 >= totalArray.Length || indexOfQueue2 >= totalArray.Length)
                break;
        }

        return -1;
    }
}