using System;

// K칸 점프 = -K
// 현재거리 * 2 = 0

class Solution
{
    static void Main(string[] args)
    {
        Solution sol = new Solution(); 
        Console.WriteLine($"answer = {sol.solution(5000)}");
    }

    public int solution(int n)
    {
        int[] dp = new int[n+1]; 
        int answer = 0;
        dp[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i / 2 > 0 && i%2 == 0)
            {
                dp[i] = dp[i / 2];
            }
            else
            {
                dp[i] = dp[i - 1] + 1;
            }
        }
        answer = dp[n];
        return answer;
    }
}