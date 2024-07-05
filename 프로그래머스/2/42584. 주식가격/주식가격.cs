using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] prices) {
        int[] answer = new int[] { };

var resultList = new List<int>();

var index = 0;
var second = 0;

while (index < prices.Length)
{
    for (int i = index + 1; i < prices.Length; i++)
{
    second++;
    if (prices[index] > prices[i])
    {
        break;
    }
}

    resultList.Add(second);

    second = 0;
    index++;
}

answer = resultList.ToArray();
return answer;
    }
}