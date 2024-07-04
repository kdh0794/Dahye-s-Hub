// 문제가 개편되었습니다. 이로 인해 함수 구성이나 테스트케이스가 변경되어, 과거의 코드는 동작하지 않을 수 있습니다.
// 새로운 함수 구성을 적용하려면 [코드 초기화] 버튼을 누르세요. 단, [코드 초기화] 버튼을 누르면 작성 중인 코드는 사라집니다.
using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
        List<int> answerList = new List<int>();

        var featureDevelopmentQueue = new Queue<int>();
        foreach (var progress in progresses)
        {
            featureDevelopmentQueue.Enqueue(progress);
        }

        var day = 0;
        var count = 0;

        for (int i = 0; i < speeds.Length; i++)
        {
            var currentFeature = featureDevelopmentQueue.Peek();
            currentFeature = currentFeature + (speeds[i] * day);
            if (currentFeature >= 100)
            {
                count++;
                featureDevelopmentQueue.Dequeue();

                if(i >= speeds.Length - 1)
                {
                    answerList.Add(count);
                }

                continue;
            }

            if(count > 0)
            {
                answerList.Add(count);
                count = 0;
            }

            while (currentFeature < 100)
            {
                currentFeature += speeds[i];
                day++;
            }

            count++;
            featureDevelopmentQueue.Dequeue();

            if(i >= speeds.Length - 1)
            {
                answerList.Add(count);
            }
        }

        return answerList.ToArray();
    }
}