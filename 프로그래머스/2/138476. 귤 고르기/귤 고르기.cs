using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int k, int[] tangerine) {
        int answer = 0;
var count = 0;

var tangerineGradeCount = new Dictionary<int, int>();

foreach (var t in tangerine)
{
    if (tangerineGradeCount.ContainsKey(t))
    {
        tangerineGradeCount[t]++;
    }
    else
    {
        tangerineGradeCount[t] = 1;
    }
}

var orderList = tangerineGradeCount.OrderByDescending(kvp => kvp.Value).ToList();
foreach (var tancount in orderList)
{
    if (k <= count)
        break;

    count += tancount.Value;
    answer++;
}

return answer;
    }
}