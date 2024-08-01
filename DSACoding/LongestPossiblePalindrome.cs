namespace DSACoding;



//Given a string A of size N, find and return the longest palindromic substring in A.
//a n m a d a m m
//0 1 2 3 4 5 6 7


public class LongestPossiblePalindrome
{
    public string longestPossiblePalindrome(string A)
	{
		//Consider number of substrings can be formed from given string.
        //if the length of the given string A is 8 for suppose. 
        //indexe range 0 to 7 and position range 1 to 8.
        //Possible substrings are :    System.String.Substring(startIndex, length);
        // 1 possibility of 8 length = A.Substring(0, 8)
        // 2 possibilities of 7 length = (0, 7) & (1, 7)
        // 3 possibilities of 6 length = (0, 6), (1, 6) & (2, 6)
        //.........
        // 7 possibilities of 2 length = (0, 2), (1, 2), (2, 2), (3, 2), (4, 2), (5, 2) & (6, 2)
        // 8 possibilities of 1 length = <one char is not eligible for palindrome string

        //O(N) => (n * (n+1)/2) combos * (n/2 iterations to identify as palindrome or not) 
        //=> n^3, n-cube

        //Start from highest length till length is 2, as we  have to findout longest possible palindrome
        // currentSubStringLength = Holds length we are considering for substring = range from 8 to 1;
        // Loop from A.Length till 2 in decreasing order;
        // Given currentSubStringLength, maxpossibilities holds maxPossiblities we can have.
        // Get each possible substring of current length and verify if it is a palindrome or not in 
        // separate function

        int currentSubStringLength = A.Length;
		while(currentSubStringLength > 1)
		{
            //For 6 length substring for example, there are 3 possibilities out of given string A.
            //
			int maxpossibilities = A.Length - currentSubStringLength; 
			
			int startIndex = 0;
			while(startIndex <= maxpossibilities)
			{
				if(isPalindrome(A.Substring(startIndex, currentSubStringLength)))
				{
					return A.Substring(startIndex, currentSubStringLength);
				}
				startIndex++;
			}
			
			currentSubStringLength--;
		}
		
		return string.Empty;
	}
		
	private bool isPalindrome(string str) {
 		int length = str.Length;
		bool isPalindrome = true;
		int i = 0;
		while(i <= length/2)
		{
			if(str[i] != str[length-1-i])
			{
				isPalindrome = false;
				break;
			}
		}
		
		return isPalindrome;
	}
}