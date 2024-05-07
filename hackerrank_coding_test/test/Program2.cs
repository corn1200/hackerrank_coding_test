using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'twoSum' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY nums
     *  2. INTEGER target
     */

    // 배열 내에서 두 수를 더해 목표 값을 만드는 함수
    public static List<int> twoSum(List<int> nums, int target)
    {
        // 답안
        List<int> answer = new List<int>();
        
        // 모든 경우의 수 탐색
        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = 0; j < nums.Count; j++)
            {
                // 숫자 중복 사용 방지
                if (i != j)
                {
                    // 두 숫자 조합이 목표 값일 경우 답안 제출
                    if (nums[i] + nums[j] == target)
                    {
                        answer.Add(i);
                        answer.Add(j);
                        return answer;
                    }
                }
            }
        }

        return answer;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int numsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> nums = new List<int>();

        for (int i = 0; i < numsCount; i++)
        {
            int numsItem = Convert.ToInt32(Console.ReadLine().Trim());
            nums.Add(numsItem);
        }

        int target = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> result = Result.twoSum(nums, target);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}