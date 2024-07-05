using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] topping) {
        int answer = 0;
        var toppingLength = topping.Length;

        int[] leftUniqueCounts = new int[toppingLength];
        int[] rightUniqueCounts = new int[toppingLength];

        HashSet<int> leftSet = new HashSet<int>();
        for (int i = 0; i < toppingLength; i++)
        {
            leftSet.Add(topping[i]);
            leftUniqueCounts[i] = leftSet.Count;
        }

        HashSet<int> rightSet = new HashSet<int>();
        for (int i = toppingLength - 1; i >= 0; i--)
        {
            rightSet.Add(topping[i]);
            rightUniqueCounts[i] = rightSet.Count;
        }

        for (int i = 0; i < toppingLength - 1; i++)
        {
            if (leftUniqueCounts[i] == rightUniqueCounts[i + 1])
            {
                answer++;
            }
        }

        return answer;
    }
}