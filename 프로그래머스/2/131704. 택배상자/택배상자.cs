using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] order) {
        int answer = 0;

        var deliveryQueue = new Queue<int>();
        for(int i = 0; i < order.Length; i++)
        {
            deliveryQueue.Enqueue(i + 1);
        }

        var tempDeliveryStack = new Stack<int>();
        for (int i = 0; i < order.Length;)
        {
            var firstDelivery = deliveryQueue.Dequeue();
            if (firstDelivery == order[i])
            {
                answer++;
                i++;
            }
            else
            {
                tempDeliveryStack.Push(firstDelivery);
            }

            while (tempDeliveryStack.Count > 0 && tempDeliveryStack.Peek() == order[i])
            {
                answer++;
                i++;
                tempDeliveryStack.Pop();
            }

            if (deliveryQueue.Count <= 0)
                break;
        }

        return answer;
    }
}