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
     * Complete the 'fibonacci' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */
    
    // 피보나치 메모 배열
    public static int[] memo = new int[]{};
    
    // 피보나치 실행 함수
    public static int fibonacci(int n)
    {
        // 피보나치 메모 배열 초기화
        memo = new int[n + 1];
        // 피보나치 재귀함수에 목표 값 넘겨줌
        return fibonacciRecur(n);
    }

    // 피보나치 재귀함수
    public static int fibonacciRecur(int n)
    {
        // 1 이하의 피보나치 수는 값을 그대로 반환
        if (n <= 1)
        {
            return n;
        }

        // 이미 계산한 피보나치 수일 경우 계산한 값 반환
        if (memo[n] != 0)
        {
            return memo[n];
        }

        // 앞의 두 수를 계산하여 더한다
        memo[n] = fibonacciRecur(n - 1) + fibonacciRecur(n - 2);
        return memo[n];
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.fibonacci(n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}