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