using System;

public class Solution {
    public int solution(int storey) {
        int answer = 0;
        int half = 5;

        while (storey > 0)
        {
            int lastDigit = storey % 10;

            if (lastDigit > half || (lastDigit == half && (storey / 10) % 10 >= half))
            {
                storey += (10 - lastDigit);
                answer += (10 - lastDigit);
            }
            else
            {
                storey -= lastDigit;
                answer += lastDigit;
            }

            storey /= 10;
        }

        return answer;
    }
}