using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("       EXERCISE 1 - STUDENT GRADES");
        Console.WriteLine("========================================");

        Exercise1();

        Console.WriteLine("\n========================================");
        Console.WriteLine("       EXERCISE 2 - LEADERBOARD");
        Console.WriteLine("========================================");

        Exercise2();

        Console.WriteLine("\n========================================");
        Console.WriteLine("       EXERCISE 3 - PHONE BOOK");
        Console.WriteLine("========================================");

        Exercise3();

        Console.WriteLine("\n========================================");
        Console.WriteLine("       EXERCISE 4 - EMAIL VALIDATOR");
        Console.WriteLine("========================================");

        Exercise4();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }


    // =========================================================
    // EXERCISE 1 - STUDENT GRADE MANAGER
    // =========================================================

    static void Exercise1()
    {
        // 1. Create a Collection with grades
        List<int> grades = new List<int>
        {
            85, 92, 78, 95, 88, 70, 100, 65
        };

        // 2. Print collection, Count, first and last grade
        Console.WriteLine("Original Grades:");
        Console.WriteLine(string.Join(", ", grades));

        Console.WriteLine("Count: " + grades.Count);
        Console.WriteLine("First Grade: " + grades.First());
        Console.WriteLine("Last Grade: " + grades.Last());

        // 3. Sort grades ascending
        grades.Sort();

        Console.WriteLine("\nGrades after sorting ascending:");
        Console.WriteLine(string.Join(", ", grades));

        // 4. Get the first grade above 90
        int firstAbove90 = grades.FirstOrDefault(g => g > 90);

        Console.WriteLine("\nFirst grade above 90: " + firstAbove90);

        // 5. Get all grades below 75
        List<int> failingGrades = grades
            .Where(g => g < 75)
            .ToList();

        Console.WriteLine("\nFailing grades (below 75):");
        Console.WriteLine(string.Join(", ", failingGrades));

        // 6. Remove all failing grades
        grades.RemoveAll(g => g < 75);

        Console.WriteLine("\nGrades after removing failing grades:");
        Console.WriteLine(string.Join(", ", grades));

        // 7. Check if any grade equals 100
        bool has100 = grades.Any(g => g == 100);

        Console.WriteLine("\nDoes any grade equal 100? " + has100);

        // 8. Create List<string> where each grade becomes "Grade: X"
        List<string> gradeStrings = grades
            .Select(g => "Grade: " + g)
            .ToList();

        Console.WriteLine("\nGrades as strings:");

        foreach (string grade in gradeStrings)
        {
            Console.WriteLine(grade);
        }
    }


    // =========================================================
    // EXERCISE 2 - LEADERBOARD
    // =========================================================

    static void Exercise2()
    {
        // SortedDictionary automatically sorts by KEY
        SortedDictionary<int, string> leaderboard =
            new SortedDictionary<int, string>();

        // 1. Add players
        leaderboard.Add(500, "Ahmed");
        leaderboard.Add(200, "Sara");
        leaderboard.Add(800, "Ali");
        leaderboard.Add(350, "Mona");

        // 2. Print all entries
        Console.WriteLine("Leaderboard:");

        foreach (KeyValuePair<int, string> player in leaderboard)
        {
            Console.WriteLine("Score: " + player.Key +
                              " - Player: " + player.Value);
        }

        // 3. Access first key and first value
        KeyValuePair<int, string> firstPlayer = leaderboard.First();

        Console.WriteLine("\nFirst Key: " + firstPlayer.Key);
        Console.WriteLine("First Value: " + firstPlayer.Value);

        // 4. Check if score 500 exists
        bool score500Exists = leaderboard.ContainsKey(500);

        Console.WriteLine("\nDoes score 500 exist? " + score500Exists);

        // 5. Safely get player with score 999
        if (leaderboard.TryGetValue(999, out string? player999))
        {
            Console.WriteLine("Player with score 999: " + player999);
        }
        else
        {
            Console.WriteLine("Player with score 999: Not Found");
        }

        // 6. Remove player with score 200
        leaderboard.Remove(200);

        Console.WriteLine("\nLeaderboard after removing score 200:");

        foreach (KeyValuePair<int, string> player in leaderboard)
        {
            Console.WriteLine("Score: " + player.Key +
                              " - Player: " + player.Value);
        }
    }


    // =========================================================
    // EXERCISE 3 - PHONE BOOK
    // =========================================================

    static void Exercise3()
    {
        // 1. Create Collection with 4 contacts
        Dictionary<string, string> phoneBook =
            new Dictionary<string, string>();

        phoneBook.Add("Ahmed", "01011111111");
        phoneBook.Add("Sara", "01022222222");
        phoneBook.Add("Ali", "01033333333");
        phoneBook.Add("Mona", "01044444444");

        // 2. Add a new contact using [] syntax
        phoneBook["Omar"] = "01055555555";

        // Print phone book
        Console.WriteLine("Phone Book:");

        foreach (KeyValuePair<string, string> contact in phoneBook)
        {
            Console.WriteLine(contact.Key + " -> " + contact.Value);
        }

        // 3. Try adding duplicate using Add()
        Console.WriteLine("\nTrying to add duplicate using Add():");

        try
        {
            phoneBook.Add("Ahmed", "01199999999");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        // 4. Try adding duplicate using TryAdd()
        Console.WriteLine("\nTrying to add duplicate using TryAdd():");

        bool added = phoneBook.TryAdd("Ahmed", "01199999999");

        Console.WriteLine("Was the contact added? " + added);

        // 5. Search for a contact that doesn't exist
        string searchName = "Youssef";

        Console.WriteLine("\nSearching for: " + searchName);

        if (phoneBook.ContainsKey(searchName))
        {
            Console.WriteLine("Contact found.");
        }
        else
        {
            Console.WriteLine("Contact does not exist.");
        }

        // 6. Get a contact with fallback "Not Found"
        string nameToGet = "Youssef";

        if (phoneBook.TryGetValue(nameToGet, out string? phone))
        {
            Console.WriteLine(
                "\n" + nameToGet + " phone: " + phone);
        }
        else
        {
            Console.WriteLine(
                "\n" + nameToGet + " phone: Not Found");
        }

        // 7. Print all Keys on one line
        Console.WriteLine("\nAll Keys:");
        Console.WriteLine(string.Join(", ", phoneBook.Keys));

        // Print all Values on another line
        Console.WriteLine("\nAll Values:");
        Console.WriteLine(string.Join(", ", phoneBook.Values));
    }


    // =========================================================
    // EXERCISE 4 - UNIQUE EMAIL VALIDATOR
    // =========================================================

    static void Exercise4()
    {
        // 1. HashSet with case-insensitive comparer
        HashSet<string> emails =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // 2. Add emails
        emails.Add("ahmed@test.com");
        emails.Add("AHMED@test.com");
        emails.Add("sara@test.com");
        emails.Add("Sara@Test.Com");

        // 3. Print Count
        Console.WriteLine("Stored Emails:");

        foreach (string email in emails)
        {
            Console.WriteLine(email);
        }

        Console.WriteLine("\nEmail Count: " + emails.Count);

        Console.WriteLine(
            "Why? Because the HashSet uses a case-insensitive comparer, " +
            "so emails that differ only by uppercase/lowercase are considered duplicates.");

        // 4. Create Set A and Set B
        HashSet<int> setA = new HashSet<int>
        {
            1, 2, 3, 4, 5
        };

        HashSet<int> setB = new HashSet<int>
        {
            4, 5, 6, 7, 8
        };

        // 5. UnionWith
        HashSet<int> unionSet = new HashSet<int>(setA);
        unionSet.UnionWith(setB);

        Console.WriteLine("\nUnionWith result:");
        Console.WriteLine(string.Join(", ", unionSet));

        // IntersectWith
        HashSet<int> intersectSet = new HashSet<int>(setA);
        intersectSet.IntersectWith(setB);

        Console.WriteLine("\nIntersectWith result:");
        Console.WriteLine(string.Join(", ", intersectSet));

        // ExceptWith
        HashSet<int> exceptSet = new HashSet<int>(setA);
        exceptSet.ExceptWith(setB);

        Console.WriteLine("\nExceptWith result:");
        Console.WriteLine(string.Join(", ", exceptSet));

        // 6. IsSubsetOf
        HashSet<int> subset = new HashSet<int>
        {
            1, 2
        };

        bool isSubset = subset.IsSubsetOf(setA);

        Console.WriteLine("\nIs {1, 2} a subset of Set A? " + isSubset);
    }
}