using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int n, int[,] wires) {
        int answer = -1;

        int rows = wires.GetLength(0);
        int columns = wires.GetLength(1);

        var wiresDic = new Dictionary<int, List<int>>();
        for (int i = 0; i < rows; i++)
        {
            if (wiresDic.ContainsKey(wires[i, 0]) == false)
            {
                wiresDic.Add(wires[i, 0], new List<int>());
            }
            wiresDic[wires[i, 0]].Add(wires[i, 1]);

            if (wiresDic.ContainsKey(wires[i, 1]) == false)
            {
                wiresDic.Add(wires[i, 1], new List<int>());
            }
            wiresDic[wires[i, 1]].Add(wires[i, 0]);
        }

        answer = int.MaxValue;
        for (int i = 0; i < rows; i++)
        {
            var leftNumber = wires[i, 0];
            var rightNumber = wires[i, 1];

            wiresDic[leftNumber].Remove(rightNumber);
            wiresDic[rightNumber].Remove(leftNumber);

            int firstCount = BFS(wiresDic, n, leftNumber);
            int secondCount = n - firstCount;

            var difference = Math.Abs(firstCount - secondCount);
            if (answer > difference)
            {
                answer = difference;
            }

            wiresDic[leftNumber].Add(rightNumber);
            wiresDic[rightNumber].Add(leftNumber);
        }

        return answer;
    }
    int BFS(Dictionary<int, List<int>> graph, int n, int start)
    {
        var visited = new bool[n + 1];
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;
        int count = 0;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            count++;

            foreach (var neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return count;
    }
}