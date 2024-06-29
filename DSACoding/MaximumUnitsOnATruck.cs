/// <summary>
/// 1710. Maximum Units on a Truck
/// https://leetcode.com/problems/maximum-units-on-a-truck/description/s
/// Array, Greedy, Sorting
/// </summary>\

using System.Linq;

public static class Solution {
    public static int MaximumUnits(int[][] boxTypes, int truckSize) {
        //Sort based on units per box
        
        //[[5,10],[2,5],[4,7],[3,9]]
        Array.Sort(boxTypes, (a,b) => b[1] - a[1]);
        int totalUnits = 0;
        for(int i = 0; i < boxTypes.Length && truckSize > 0; i++)
        {
            int boxCount = boxTypes[i][0];
            int unitsPerBox = boxTypes[i][1];

            int boxesToAdd = Math.Min(boxCount, truckSize);
            totalUnits += boxesToAdd * unitsPerBox;
            truckSize -= boxesToAdd;
        }
        return totalUnits;
        // Array.ForEach(boxTypes, array => {
        //     Array.ForEach(array, item => Console.Write($"{item} "));
        //     Console.WriteLine();
        // });
        
        // int maxUnits = 0;
        // int length = boxTypes.Length;
        // for(int i = 0; i < length; i++)
        // {
        //     if(truckSize == 0) break;
        //     int[][] temp = new int[1][];
        //     int pivot = boxTypes[i][1];
        //     int largestIndex = i;
        //     for(int j = i+1; j < length; j++)
        //     {
        //         if(boxTypes[j][1] > pivot)
        //         {
        //             largestIndex = j;
        //             pivot = boxTypes[j][1];
        //         }              
        //     }

        //     if(largestIndex > i)
        //     {
        //         temp[0]= boxTypes[i];
        //         boxTypes[i] = boxTypes[largestIndex];
        //         boxTypes[largestIndex] = temp[0];
        //     }

        //     if(truckSize >= boxTypes[i][0])
        //     {
        //         maxUnits += boxTypes[i][0] * boxTypes[i][1];
        //         truckSize -= boxTypes[i][0];
        //     }
        //     else
        //     {
        //         maxUnits += truckSize * boxTypes[i][1];
        //         truckSize -= truckSize;
        //     }
        // }        
        // return maxUnits;
    }
}