using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] citations) {
        int answer = 0;

        var citationsList = citations.OrderByDescending(citation => citation).ToList();
        for(int i = 0; i < citationsList.Count; i++)
        {
            var searchNumber = i + 1;
            if(citationsList[i] >= searchNumber)
            {
                answer = searchNumber;
            }
            else
            {
                break;
            }
        }

        return answer;
    }
}