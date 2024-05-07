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
     * Complete the 'chess_puzzle' function below.
     *
     * The function accepts INTEGER n as parameter.
     */
    // 행의 몇 번째 열에 체스말이 놓여있는지 저장
    private static int[] positions;
    // 경우의 수를 도달 여부
    private static bool findPath = false;

    // 퍼즐 실행 함수
    public static void chess_puzzle(int n)
    {
        // 행 배열 초기화
        positions = new int[n];

        // 0번 행부터 DFS 탐색
        DFS(0);
    }

    public static void DFS(int row)
    {
        // 경우의 수를 찾았을 경우 함수를 바로 종료함
        if (findPath)
        {
            return;
        }
        
        // N을 행의 크기로 초기화
        int N = positions.Length;
        
        // 경우의 수가 마지막 행까지 도달했을 경우 실행
        if (row == N)
        {
            // 경우의 수 도달 여부 true로 변환
            findPath = true;
            
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // i번째 행의 j번 열에 체스 말이 놓아졌을 경우 위치 출력
                    if (positions[i] == j)
                    {
                        Console.WriteLine($"{i} {j}");
                    }
                }
            }
            return;
        }

        // 현재 행의 열 탐색
        for (int col = 0; col < N; col++)
        {
            // 현재 행, 열에 체스 말을 놓을 수 있는지 확인
            if (IsSafe(row, col))
            {
                // 현재 행, 열에 체스 말을 놓고 다음 행으로 이동
                positions[row] = col;
                DFS(row + 1);
            }
        }
    }
    
    // 체스 말을 놓을 수 있는지 확인하는 함수
    private static bool IsSafe(int row, int col)
    {
        // 현재 체스 말이 놓여질 행 전까지 검사
        for (int i = 0; i < row; i++)
        {
            // i행 체스 말의 열 위치
            int otherCol = positions[i];
            // 다른 행의 말이 같은 열에 위치해있거나, x y 좌표 차이가 같을 경우(대각선에 존재) 부적격 판별
            if (otherCol == col || Math.Abs(otherCol - col) == row - i)
            {
                return false;
            }
        }
        return true;
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.chess_puzzle(n);
    }
}