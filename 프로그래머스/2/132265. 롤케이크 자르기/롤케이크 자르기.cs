using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] topping) {
        int answer = 0;
        var toppingLength = topping.Length;

        int[] leftTopping = new int[toppingLength];
        int[] RightTopping = new int[toppingLength];

        HashSet<int> leftToppingSet = new HashSet<int>();
        for (int i = 0; i < toppingLength; i++)
        {
            leftToppingSet.Add(topping[i]);
            leftTopping[i] = leftToppingSet.Count;
        }

        HashSet<int> rightToppingSet = new HashSet<int>();
        for (int i = toppingLength - 1; i >= 0; i--)
        {
            rightToppingSet.Add(topping[i]);
            RightTopping[i] = rightToppingSet.Count;
        }

        for (int i = 0; i < toppingLength - 1; i++)
        {
            if (leftTopping[i] == RightTopping[i + 1])
            {
                answer++;
            }
        }

        return answer;
    }
}