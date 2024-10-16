using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int k, int[,] dungeons) {
        int answer = -1;

        List<(int start, int end)> dungeonsList = new List<(int, int)>();
        for (int i = 0; i < dungeons.GetLength(0); i++)
        {
            dungeonsList.Add((dungeons[i, 0], dungeons[i, 1]));
        }

        bool[] visited = new bool[dungeonsList.Count];
        DungeonExploration(k, dungeonsList, visited, 0, ref answer);

        return answer;
    }
    private void DungeonExploration(int k, List<(int start, int end)> dungeons, bool[] visited, int count, ref int answer)
    {
        answer = Math.Max(answer, count);

        for(int i = 0; i < dungeons.Count; i++)
        {
            if (visited[i] == false && k >= dungeons[i].start)
            {
                visited[i] = true;
                DungeonExploration(k - dungeons[i].end, dungeons, visited, count + 1, ref answer);
                visited[i] = false;
            }
        }
    }
}