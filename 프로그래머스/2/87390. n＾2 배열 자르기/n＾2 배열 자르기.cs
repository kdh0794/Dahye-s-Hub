using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int n, long left, long right) {
        int[] answer = new int[] { };

        List<int> answerList = new List<int>();

        while(left <= right)
        {
            var share = left / n;
            var remain = left % n;

            answerList.Add((int)Math.Max(share, remain) + 1);

            left++;
        }

        answer = answerList.ToArray();
        return answer;
    }
}