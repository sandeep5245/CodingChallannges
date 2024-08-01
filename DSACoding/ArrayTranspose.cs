namespace DSACoding;

public class ArrayTranspose
{
    public static int[][] arrayTranspose(int [][] ipArray)
    {
        int m = ipArray.Length;
        int n = ipArray[0].Length;

        int[][] opArray = new int[n][];

        for(int i = 0; i < n ; i++)
        {
            opArray[i] = new int[m];
            for(int j = 0; j < m; j++)
            {
                if(i == j)
                    opArray[i][j] = ipArray[i][j];
                else
                    opArray[i][j] = ipArray[j][i];
            }
        }

        return opArray;
    }
}