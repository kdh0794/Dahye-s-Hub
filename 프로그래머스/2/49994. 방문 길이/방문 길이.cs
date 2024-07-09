using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string dirs) {
        int answer = 0;

        HashSet<string> visited = new HashSet<string>();

        Dictionary<char, (int, int)> directions = new Dictionary<char, (int, int)>
        {
            { 'U', (0, 1) },
            { 'D', (0, -1) },
            { 'L', (-1, 0) },
            { 'R', (1, 0) }
        };

        int x = 0;
        int y = 0;

        foreach (char dir in dirs)
        {
            int nextX = x + directions[dir].Item1;
            int nextY = y + directions[dir].Item2;

            if (nextX < -5 || nextX > 5 || nextY < -5 || nextY > 5)
                continue;

            string path1 = $"{x},{y}-{nextX},{nextY}";
            string path2 = $"{nextX},{nextY}-{x},{y}";

            if (!visited.Contains(path1) && !visited.Contains(path2))
            {
                visited.Add(path1);
                visited.Add(path2);
                answer++;
            }

            x = nextX;
            y = nextY;
        }

        return answer;
    }
}