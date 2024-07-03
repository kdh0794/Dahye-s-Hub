using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] fees, string[] records)
{
    int[] answer = new int[] { };

    var basicTime = fees[0];
    var basicPay = fees[1];
    var unitTime = fees[2];
    var unitPay = fees[3];

    var tempDic = new Dictionary<string, int>();
    for(int i = 0; i < records.Length; i++)
    {
        var firstRecord = records[i].Split(' ');
        var index = FindIndexOfValue(records, firstRecord[1], i);

        if (firstRecord[2].Contains("OUT"))
        {
            continue;
        }

        string secondTime = string.Empty;
        if(index != -1)
        {
            if (index <= i)
            {
                continue;
            }
            var secondRecord = records[index].Split(' ');
            secondTime = secondRecord[0];
        }
        else
        {
            secondTime = "23:59";
        }

        var timeDiffernce = TimeSpan.Parse(secondTime) - TimeSpan.Parse(firstRecord[0]);

        var minutesDifference = (int)timeDiffernce.TotalMinutes;
        AddOrUpdate(tempDic, firstRecord[1], minutesDifference);
    }

    var temp = tempDic.OrderBy(kvp => Convert.ToInt32(kvp.Key)).ToList();

    var resultList = new List<int>();
    foreach(var record in temp)
    {
        int finalPay = record.Value <= basicTime ? basicPay : basicPay + (int)Math.Ceiling(((double)(record.Value - basicTime) / unitTime)) * unitPay;
        resultList.Add(finalPay);
    }

    answer = resultList.ToArray();

    return answer;
}

static int FindIndexOfValue(string[] arr, string target, int currentIndex)
{
    for (int i = currentIndex + 1; i < arr.Length; i++)
    {
        if(arr[i].Contains(target))
        {
            return i;
        }
    }
    return -1;
}

static void AddOrUpdate(Dictionary<string, int> dict, string key, int value)
{
    if (dict.ContainsKey(key))
    {
        dict[key] += value;
    }
    else
    {
        dict.Add(key, value);
    }
}
}