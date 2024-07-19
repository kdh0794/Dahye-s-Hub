using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] cards) {
        int answer = 0;

        int startIndex = 0;
        while(startIndex < cards.Length)
        {
            var currentScore = CalPlayScore(cards, startIndex);
            if (answer < currentScore || answer == 0)
            {
                answer = currentScore;
            }

            startIndex++;
        }

        return answer;
    }

    int CalPlayScore(int[] cards, int startIndex)
    {
        var firseGroup = new List<int>();
        var secondGroup = new List<int>();

        var startCard = cards[startIndex];
        firseGroup.Add(startCard);

        while (true)
        {
            var index = startCard - 1;
            if (firseGroup.Find(x => x == cards[index]) == 0)
            {
                firseGroup.Add(cards[index]);
                startCard = cards[index];
            }
            else
            {
                break;
            }
        }
        
        if(firseGroup.Count == cards.Length)
        {
            return 0;
        }
        
        startIndex = startIndex == cards.Length - 1 ? 0 : startIndex + 1; 
        startCard = cards[startIndex];
        secondGroup.Add(startCard);

        while (true)
        {
            var index = startCard - 1;

            if (secondGroup.Find(x => x == cards[index]) == 0
                && firseGroup.Find(x => x == cards[index]) == 0)
            {
                secondGroup.Add(cards[index]);
                startCard = cards[index];
            }
            else
            {
                break;
            }
        }

        return firseGroup.Count * secondGroup.Count;
    }
}