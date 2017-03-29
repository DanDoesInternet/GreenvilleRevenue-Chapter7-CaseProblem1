using System;
using static System.Console;
class GreenvillRevenue
{
    static int lastYearNum, thisYearNum;
    static string[] skillPool = { "S", "D", "M", "O" };
    static int[] skillCounts = { 0, 0, 0, 0 };
    static string[] contestants = { };
    static string[] skills = { };


    private static void Main()
    {
        //Collect participation counts for this and last year
        Write("For last year, ");
        lastYearNum = getCount();
        Write("For this year, ");
        thisYearNum = getCount();
        contestants = new string[thisYearNum];
        skills = new string[thisYearNum];

        //Compare counts and return a comment.
        compareCounts(lastYearNum, thisYearNum);

        //Get information about contestants and fill arrays
        for (int x = 0; x < contestants.Length; ++x)
        {
            getName(x);
            WriteLine("Which talent will {0} be showcasing?", contestants[x]);
            skills[x] = getSkill();
            if (skills[x] == "Q")
                break;
        }

        Write("Enter a talent code below to view a listing of all contestants in that category.");
        string inputString = "";
        do
        {
            
            inputString = getSkill();
            whoHasSkill(inputString);

        } while (inputString != "Q");
    }

    private static int getCount()
    {
        string inputString;
        int count;
        WriteLine("enter the number of contestants in the talent show: ");
        inputString = ReadLine();
        count = Convert.ToInt32(inputString);

        while (count < 0 || count > 30)
        {
            WriteLine("Sorry, the number you have entered is invalid.  You must enter a number between 0 and 30: ");
            inputString = ReadLine();
            count = Convert.ToInt32(inputString);
        }

        return count;
    }

    private static void compareCounts(int num1, int num2)
    {
        string message;
        if (num1 > num2)
            message = "There were less contestants this year.";
        if (num1 < num2)
            message = "There were more contestants this year.";
        else
            message = "Same as last year.";
        WriteLine(message);
        WriteLine();
    }

    private static void getName(int num)
    {
        string inputString;
        Write("Please enter a name for contestant #{0} :", num + 1);
        inputString = ReadLine();
        contestants[num] = inputString;
    }

    private static string getSkill()
    {
        bool isValid = false;
        string inputString = "";

        while (isValid == false)
        {
            WriteLine("Enter S for Singing, D for Dancing, M for Musical instrument, O for Other, or Q to quit: ");
            inputString = ReadLine();
            WriteLine();

            isValid = checkTalent(inputString);

            if (isValid == false)
            {
                WriteLine("The letter you have entered is invalid.  Please try again.");
            }
        }

        return inputString;
    }

    private static bool checkTalent(string talent)
    {
        bool check = false;
        for (int x = 0; x < skillPool.Length; ++x)
        {
            if (talent == skillPool[x] || talent == "Q")
                check = true;
        }
        return check;
    }

    private static void showTable()
    {
        for (int x = 0; x < contestants.Length; ++x)
        {
            WriteLine("{0, 2}. {1, 10} {2, 3}",x + 1, contestants[x], skills[x]);
        }
    }

    private static void getSkillCounts()
    {
        for (int x = 0; x < contestants.Length; ++x)
        {
            for (int y = 0; y < skillPool.Length; ++y)
            {
                if (skills[x] == skillPool[y])
                    skillCounts[y] += 1;
            }
        }

        //for (int x = 0; x < skillPool.Length; ++x)
        //{
        //    WriteLine("{0}: {1}", skillPool[x], skillCounts[x]);
        //}
    }

    private static void whoHasSkill(string skill)
    {
        for (int x = 0; x < skills.Length; ++x)
        {
            if (skills[x] == skill)
            {
                WriteLine("{0}", contestants[x]);
            }
        }
    }
}