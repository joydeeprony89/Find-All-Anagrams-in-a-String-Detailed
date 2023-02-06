// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// https://jaydeepwise.medium.com/find-all-anagrams-in-a-string-1345a4da4cf1
// https://leetcode.com/problems/find-all-anagrams-in-a-string/description/

public class Solution
{
  public IList<int> FindAnagrams(string s, string p)
  {
    if (s.Length < p.Length)
      return new List<int>();

    int[] sArray = new int[26];
    int[] pArray = new int[26];

    for (int i = 0; i < p.Length; i++)
    {
      sArray[s[i] - 'a']++;
      pArray[p[i] - 'a']++;
    }

    List<int> result = new List<int>();

    for (int i = 0; i < s.Length - p.Length; i++)
    {
      if (IsSame(sArray, pArray))
        result.Add(i);

      sArray[s[i] - 'a']--;
      sArray[s[i + p.Length] - 'a']++;
    }

    if (IsSame(sArray, pArray))
      result.Add(s.Length - p.Length);

    return result;
  }

  private bool IsSame(int[] sArray, int[] pArray)
  {
    for (int i = 0; i < sArray.Length; i++)
    {
      if (sArray[i] != pArray[i])
        return false;
    }

    return true;
  }
}