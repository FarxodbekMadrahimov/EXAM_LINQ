using System;
using System.Collections.Generic;
using System.Linq;

public class LINQ7
{
    public static List<T> GetCommonElements<T>(List<T> list1, List<T> list2)
    {
        return list1.Intersect(list2).OrderBy(item => item).ToList();
    }

    public static List<T> MergeLists<T>(List<T> list1, List<T> list2)
    {
        return list1.Concat(list2).OrderBy(item => item).ToList();
    }

    public static List<T> GetElementsFromFirstListNotInSecond<T>(List<T> list1, List<T> list2)
    {
        return list1.Except(list2).OrderBy(item => item).ToList();
    }

    public static List<string> GetWordsStartingWithA(List<string> words)
    {
        return words.Where(word => word.StartsWith("A", StringComparison.OrdinalIgnoreCase)).OrderBy(word => word).ToList();
    }

    public static List<T> GetListDifference<T>(List<T> list1, List<T> list2)
    {
        return list1.Except(list2).Concat(list2.Except(list1)).OrderBy(item => item).ToList();
    }

    public static List<T> MergeListsWithStartingM<T>(List<T> list1, List<T> list2)
    {
        List<T> mergedList = list1.Concat(list2).OrderBy(item => item).ToList();
        return mergedList.Where(item => item.ToString().StartsWith("M", StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public static void Main()
    {
        List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5 };
        List<int> numbers2 = new List<int> { 3, 4, 5, 6, 7 };

        List<string> words1 = new List<string> { "Apple", "Banana", "Cherry", "Date" };
        List<string> words2 = new List<string> { "Cherry", "Date", "Grapes", "Mango" };

        // 7.1
        List<int> commonNumbers = GetCommonElements(numbers1, numbers2);
        Console.WriteLine("7.1. Bir xil sonlar: " + string.Join(", ", commonNumbers));

        // 7.2
        List<int> mergedNumbers = MergeLists(numbers1, numbers2);
        Console.WriteLine("7.2. Birleshgan sonlar: " + string.Join(", ", mergedNumbers));

        // 7.3
        List<int> numbersFromFirstListNotInSecond = GetElementsFromFirstListNotInSecond(numbers1, numbers2);
        Console.WriteLine("7.3. Birinchi ro'yxatdagi, ikkinchi ro'yxatda yo'q sonlar: " + string.Join(", ", numbersFromFirstListNotInSecond));

        // 7.4
        List<string> wordsStartingWithA = GetWordsStartingWithA(words1);
        Console.WriteLine("7.4. Bosh harfi 'A' bilan boshlanadigan so'zlar: " + string.Join(", ", wordsStartingWithA));

        // 7.5
        List<int> listDifference = GetListDifference(numbers1, numbers2);
        Console.WriteLine("7.5. Ro'yxatlarning farqi: " + string.Join(", ", listDifference));

        // 7.6
        List<string> mergedListStartingWithM = MergeListsWithStartingM(words1, words2);
        Console.WriteLine("7.6. 'M' bilan boshlanadigan elementlar: " + string.Join(", ", mergedListStartingWithM));
    }
}
