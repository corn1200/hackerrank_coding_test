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
     * Complete the 'merge' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY nums1
     *  2. INTEGER n
     *  3. INTEGER_ARRAY nums2
     *  4. INTEGER m
     */

    // 정렬된 두 배열 합치기
    public static List<int> merge(List<int> nums1, int n, List<int> nums2, int m)
    {
        // 힙 생성
        SortedSet<(int, int)> heap = new SortedSet<(int, int)>();
        // 데이터 삽입 횟수
        int max = Math.Max(n, m);
        
        for (int i = 0; i < max; i++)
        {
            // 삽입 가능한 데이터가 남았을 경우 데이터 삽입
            if (nums1.Count > i)
            {
                heap.Add((nums1[i], i));
            }
            if (nums2.Count > i)
            {
                heap.Add((nums2[i], i + 1));
            }
        }

        // 정렬된 데이터 원본만 반환
        return heap.Select(g => g.Item1).ToList();
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int nums1Count = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> nums1 = new List<int>();

        for (int i = 0; i < nums1Count; i++)
        {
            int nums1Item = Convert.ToInt32(Console.ReadLine().Trim());
            nums1.Add(nums1Item);
        }

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int nums2Count = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> nums2 = new List<int>();

        for (int i = 0; i < nums2Count; i++)
        {
            int nums2Item = Convert.ToInt32(Console.ReadLine().Trim());
            nums2.Add(nums2Item);
        }

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> result = Result.merge(nums1, n, nums2, m);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}