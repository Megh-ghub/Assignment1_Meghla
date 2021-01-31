using System; //Contains fundamental classes and base classes 
using System.Collections.Generic; //Contains interfaces and classes that define generic collections, 
using System.Linq; //Provides classes and interfaces that support queries that use Language-Integrated Query (LINQ)


namespace Assignment1_Spring2021
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n >= 0)
            {
                printTriangle(n);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The input number is a non-negative integer & you need to enter positive number.");
            }

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            if (n3 >= 0)
            {
                bool flag = squareSums(n3);
                if (flag)
                {
                    Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                }
                else
                {
                    Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
                }
            }
            else
            {
                Console.WriteLine("The input number is a non-negative integer");
            }

            //Question 4:
            int[] arr = { 1, 3, 1, 5, 4 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" }};
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }

        /// <summary>
        ///Print a pattern with n rows given n as input
        ///n – number of rows for the pattern, integer (int)
        ///This method prints a triangle pattern.
        ///For example n = 5 will display the output as: 
        ///     *
        ///    ***
        ///   *****
        ///   *******
        ///  *********
        ///returns      : N/A
        ///return type  : void
        /// </summary>
        /// <param name="n"></param>

        private static void printTriangle(int n)
        {
            int i, j;
            //using try catch block to protect the program from running into errors
            try
            {
                //Using For loop to compute the numbers based on input number
                for (i = 0; i <= n; i++)
                {
                    for (j = 1; j <= n - i; j++) //if condition is true, it will go inside 
                    {
                        Console.Write(" "); //if condition is true, it will print space
                    }
                    for (j = 1; j <= 2 * i - 1; j++)
                    {
                        Console.Write("*"); //if condition is true, it will print *
                    }
                    Console.Write("\n");
                }
            }
            //Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///<para>
        ///In mathematics, the Pell numbers are an infinite sequence of integers.
        ///The sequence of Pell numbers starts with 0 and 1, and then each Pell number is the sum of twice of the previous Pell number and 
        ///the Pell number before that.:thus, 70 is the companion to 29, and 70 = 2 × 29 + 12 = 58 + 12. The first few terms of the sequence are :
        ///0, 1, 2, 5, 12, 29, 70, 169, 408, 985, 2378, 5741, 13860,… 
        ///Write a method that prints first n numbers of the Pell series
        /// Returns : N/A
        /// Return type: void
        ///</para>
        /// </summary>
        /// <param name="n2"></param>

        private static void printPellSeries(int n2)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                //Creating an array of integers to hold calculated number series
                int[] series = new int[n2];

                //Using For loop to compute the numbers based on input number
                for (int i = 1; i < n2; i++)
                {
                    //using if conditon to print first 2 numbers of the series i.e 0,1. This is to protect the program from avoiding out of Range error
                    if (i < 2)
                    {
                        series[i] = i;
                    }
                    else
                    {
                        series[i] = (series[i - 1] * 2) + series[i - 2];
                    }
                }
                //using foreach statement to print all items in the array
                foreach (var item in series)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
            }
            //Catch block for error handling
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///Given a non-negative integer c, decide whether there're two integers a and b such that a^2 + b^2 = c.
        ///For example:
        ///Input: C = 5 will return the output: true (1*1 + 2*2 = 5)
        ///Input: A = 3 will return the output : false
        ///Input: A = 4 will return the output: true
        ///Input: A = 1 will return the output : true
        ///Note: You cannot use inbuilt Math Class functions.
        /// </summary>
        /// <param name="n3"></param>
        /// <returns>True or False</returns>

        private static bool squareSums(int n3)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                //Using two nested for loop starting from 0 & incremented to input number
                //and checking if the input number is summation of two integer squares.
                for (int n1 = 0; n1 * n1 <= n3; n1++)
                {
                    for (int n2 = 0; n2 * n2 <= n3; n2++)
                    {
                        if (n1 * n1 + n2 * n2 == n3)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            //Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Given an array of integers and an integer n, you need to find the number of unique
        /// n-diff pairs in the array.Here a n-diff pair is defined as an integer pair (i, j),
        ///where i and j are both numbers in the array and their absolute difference is n.
        ///Example 1:
        ///Input: [3, 1, 4, 1, 5], k = 2
        ///Output: 2
        ///Explanation: There are two 2-diff pairs in the array, (1, 3) and(3, 5).
        ///Although we have two 1s in the input, we should only return the number of unique   
        ///pairs.
        ///Example 2:
        ///Input:[1, 2, 3, 4, 5], k = 1
        ///Output: 4
        ///Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and
        ///(4, 5).
        ///Example 3:
        ///Input: [1, 3, 1, 5, 4], k = 0
        ///Output: 1
        ///Explanation: There is one 0-diff pair in the array, (1, 1).
        ///Note : The pairs(i, j) and(j, i) count as same.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns>Number of pairs in the array with the given number as difference</returns>

        private static int diffPairs(int[] nums, int k)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                //Performing an input check
                if (nums == null || nums.Length == 0 || k < 0)
                {
                    return 0;
                }

                //Declaring variables 
                var pairs = new List<int[]>();
                var NumSet = new HashSet<int>();
                var NumExists = new HashSet<int>();

                //using for each loop to read through each variable in the declared loop
                foreach (var number in nums)
                {
                    // Calculating the number bigger than the number by the difference 
                    var BigNum = number + k;

                    // Calculating the number smaller than the number by the difference 
                    var SmallNum = number - k;

                    // Using HashSet.Contains to check if HashSet contains the number
                    if (NumSet.Contains(BigNum))
                    {
                        // Using HashSet.Contains checking if HashSet contains the bigger number
                        if (!NumExists.Contains(BigNum))
                        {
                            // Using List.Add method add the pair
                            pairs.Add(new int[] { BigNum, number });
                            NumExists.Add(BigNum);
                        }
                    }

                    if (NumSet.Contains(SmallNum))
                    {
                        if (!NumExists.Contains(number))
                        {
                            pairs.Add(new int[] { number, SmallNum });
                            NumExists.Add(number);
                        }
                    }

                    NumSet.Add(number);
                }

                return pairs.Count;
            }
            catch (Exception e)
            {
                //returning standard error message in case on invalid input
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /// <summary>
        /// An Email has two parts, local name and domain name. 
        /// Eg: rocky @usf.edu – local name : rocky, domain name : usf.edu
        /// Besides lowercase letters, these emails may contain '.'s or '+'s.
        /// If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.
        /// For example, "bulls.z@usf.com" and "bullsz@leetcode.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
        /// If you add a plus('+') in the local name, everything after the first plus sign will be ignored.This allows certain emails to be filtered, for example ro.cky+bulls @usf.com will be forwarded to rocky@email.com.  (Again, this rule does not apply for domain names.)
        /// It is possible to use both of these rules at the same time.
        /// Given a list of emails, we send one email to each address in the list.Return, how many different addresses actually receive mails?
        /// Eg:
        /// Input: ["dis.email+bull@usf.com","dis.e.mail+bob.cathy@usf.com","disemail+david@us.f.com"]
        /// Output: 2
        /// Explanation: "disemail@usf.com" and "disemail@us.f.com" actually receive mails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns>The number of unique emails in the given list</returns>

        private static int UniqueEmails(List<string> emails)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                //declaring variables
                bool flag = false;
                bool flag2 = false;
                List<string> result = new List<string>();
                //using foreach loop to read through each string in the declared loop
                foreach (string value in emails)
                {
                    string curr = "";
                    //using second for each loop to read through each character in the declared loop
                    foreach (char ch in value)
                    {
                        //if condition block to obtaing appropriately formatted email addresses to  curr string
                        if (ch == '@') { flag2 = true; flag = false; curr += ch; }
                        if ((char.IsLetter(ch) || char.IsDigit(ch)) && !flag) { curr += ch; }
                        if (ch == '.' && flag2) { curr += ch; }
                        if (ch == '+' && !flag && !flag2) { flag = true; }
                    }
                    //adding formatted email addresses to  curr string
                    result.Add(curr);
                    //resetting curr, flag and flag2 values for next iteration of for each loop
                    curr = ""; flag = false; flag2 = false;
                }
                //using distint function to eliminate repeatead emails and store it in 'Final Result'
                List<string> finalresult = result.Distinct().ToList();
                //returning int finalresult.count which is number of unique email adderesses.
                return finalresult.Count();
            }
            //Catch block for error handling
            catch (Exception e)
            {
                Console.Write(e.Message);
                return 0;
            }
        }

        /// <summary>
        /// You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi. Return the destination city, that is, the city without any path outgoing to another city.
        /// It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        /// Example 1:
        /// Input: paths = [["London", "New York"], ["New York","Tampa"], ["Delhi","London"]]
        /// Output: "Tampa" 
        /// Explanation: Starting at "Delhi" city you will reach "Tampa" city which is the destination city.Your trip consist of: "Delhi" -> "London" -> "New York" -> "Tampa".
        /// Input: paths = [["B","C"],["D","B"],["C","A"]]
        /// Output: "A"
        /// Explanation: All possible trips are: 
        /// "D" -> "B" -> "C" -> "A". 
        /// "B" -> "C" -> "A". 
        /// "C" -> "A". 
        /// "A". 
        /// Clearly the destination city is "A".
        /// </summary>
        /// <param name="paths"></param>
        /// <returns>The destination city string</returns>

        private static string DestCity(string[,] paths)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                string temp = "";
                int length = paths.Length;
                //Using for loop for getting all Destination cities in a variable 'dest'
                for (int i = 0; i < length / 2; i++)
                {
                    string dest = paths[i, 1];
                    for (int j = 0; j < length / 2; j++) //Using for loop for comparing source cities
                    {
                        if (dest == paths[j, 0]) //Using if condition checking whether city is in Source city list, If not, return that city as destination city
                        {
                            break;
                        }
                        else
                        {
                            temp = dest;
                        }
                    }
                }
                return temp;
            }
            //Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }
    }
}

/*Comments By Meghla Sarkar (U90053065)
 
*It took me some 20+ hours to complete the assignment.
*While working on the assignment, I got more familiarized with extensive usage of 'for' & 'if' loops, Lists & HashSet.
*Also learnt about usage of foreach loop.
*Integration of independent code blocks and exception handling is another learning I will take from this assignment.
*No recommendation as such, Some of the problems were challenging to solve and exiting to work on, 
*and the notes and examples shared had really helped.
 */