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
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        float length = arr.Count;
        int postive = 0;
        int negative = 0;
        int zero = 0;
        foreach (var i in arr)
        {
            if (i > 0)
            {
                postive++;
            } else if (i < 0)
            {
                negative++;
            }
            else
            {
                zero++;
            }
        }
        Console.WriteLine(String.Format("{0:0.000000}", postive / length));
        Console.WriteLine(String.Format("{0:0.000000}", negative / length));
        Console.WriteLine(String.Format("{0:0.000000}", zero / length));
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}