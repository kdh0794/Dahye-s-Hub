using System;

public class Solution {
    public int solution(string[] want, int[] number, string[] discount) {
        int answer = 0;
        int firstDay = 0;

        for (int i = 0; i < want.Length;)
        {
            int currentItemCount = number[i];
            int maxDay = firstDay + 10;

            if (maxDay > discount.Length)
            {
                break;
            }

            for (int j = firstDay; j < maxDay; j++)
            {
                if (want[i].Equals(discount[j]))
                {
                    currentItemCount--;
                    if (currentItemCount <= 0)
                    {
                        i++;

                        if(i >= want.Length)
                        {
                            firstDay++;
                            answer++;
                            i = 0;
                        }

                        break;
                    }
                }
            }

            if (currentItemCount > 0)
            {
                i = 0;
                firstDay++;
            }
        }

        return answer;
    }
}