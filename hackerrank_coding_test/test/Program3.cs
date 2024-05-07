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
     * Complete the 'isHappy' function below.
     *
     * The function is expected to return a BOOLEAN.
     * The function accepts INTEGER n as parameter.
     */

    // 해피넘버를 찾는 함수
    // 각 자릿수를 제곱하여 더하는 걸 반복하다 1이 될 경우 해피넘버이며, 반복이 생길 경우 언해피넘버다
    public static bool isHappy(int n)
    {
        // 현재 값을 시작 값으로 초기화한다 
        int current = n;
        // 해피넘버를 검증하며 나온 값들을 중복 없이 저장
        HashSet<int> set = new HashSet<int>();
        
        // 현재 값이 1이면 반복을 종료하고 해피넘버 반환
        while (current != 1)
        {
            // 새로 계산한 값
            int newSum = 0;
            
            // 각 자릿수의 값을 전부 제곱으로 더할 때까지 실행
            while (current > 0)
            {
                // 현재 숫자에서 1의 자리 값을 제곱으로 더함
                newSum += (current % 10) * (current % 10);
                // 마지막 자리를 제거
                current /= 10;
            }

            // 이전에 계산한 값 중에 새로 계산한 값이 있는지 확인(반복 확인)
            if (set.Contains(newSum))
            {
                // 언해피넘버
                return false;
            }
            else
            {
                // 현재 값을 새로 계산한 값으로 초기화
                current = newSum;
                // 해시셋에 현재 값 추가
                set.Add(current);
            }
        }

        return true;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        bool result = Result.isHappy(n);

        textWriter.WriteLine((result ? 1 : 0));

        textWriter.Flush();
        textWriter.Close();
    }
}