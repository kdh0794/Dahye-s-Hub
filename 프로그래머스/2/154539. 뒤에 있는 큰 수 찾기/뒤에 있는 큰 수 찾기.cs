using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] numbers) {
        int[] answer = new int[numbers.Length];

        var answerStack = new Stack<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            while (answerStack.Count > 0 && numbers[answerStack.Peek()] < numbers[i])
            {
                answer[answerStack.Pop()] = numbers[i];
            }
            answerStack.Push(i);
        }

        while (answerStack.Count > 0)
        {
            answer[answerStack.Pop()] = -1;
        }

        return answer;
    }
}