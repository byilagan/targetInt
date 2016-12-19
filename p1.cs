//Bailey Ilagan
//September 29, 2016 
//p1.cs 
//The purpose of this class is to test the variables and functions of the targetInt class through the use of a puesdo
//guessing game. A test is considered one run through of all the targetInt objects using the game. In total, there are two
//tests, one where the data fields of the objects are filled by the constructor and one that resets the data fields using
//the reset function.  


using System;
using Target; 

namespace Program1 
{
    class p1
    {
        //assumes that the target number needs to be a random number passed into the constructor
        //the limit for the random numbers is set at 100

        const int HANDICAP = 5; //amount of guesses before the user receives more assistance 
        const int NUM_OBJ = 2; //number of targetInt objects being used in a test 
        const int NUM_TESTS = 7; //number of test guesses that will be run on each targetInt object
        const int RAND_LIMIT = 100; //limits of the random number generator 
        static Random random = new Random();

        //prints out the stats for each test 
        //takes in a targetInt array that holds all the objects that will be tested
        //no variables are changed
        static void stats(targetInt[] tar)
        {
            for (int i = 0; i < NUM_OBJ; i++)
            {
                Console.WriteLine("Object " + (i + 1));
                Console.WriteLine("--------");
                Console.WriteLine("Number of Guesses: " + tar[i].numGuess);
                Console.WriteLine("Highest Guess: " + tar[i].highGuess);
                Console.WriteLine("Lowest Guess: " + tar[i].lowGuess);
                Console.WriteLine("Average Guess: " + tar[i].avgGuess);
                Console.WriteLine("\n");
            }
        }

        //runs the test on all the targetInt objects in the passed array 
        //takes in a targetInt array that holds all the objects that will be tested 
        //no variables are changed
        static void runTest(targetInt[] tar)
        {
            for (int i = 0; i < NUM_OBJ; i++)
            {
                Console.WriteLine("Object " + (i + 1) + ": Target number is " + tar[i].numToGuess);
                Console.WriteLine("----------------------------");

                int count = 0;

                //keeps running until guess limit is reached(NUM_TESTS) or the number is guessed correctly 
                while (!tar[i].found() && count < NUM_TESTS) 
                {

                    int guess = random.Next(RAND_LIMIT); //random guess
                    
                    //tests the "known" state of the targetInt object
                    if (count == (NUM_TESTS - 1) && i == (NUM_OBJ - 1))
                        guess = tar[i].numToGuess; 

                    Console.WriteLine("Guess " + (count + 1) + ": " + guess);

                    //updates the data fields in the targetInt object
                    tar[i].update(guess);

                    if (tar[i].found())
                    {
                        Console.WriteLine("Correct! You have found the right number");
                    }
                    else
                    {
                        if (count < HANDICAP)
                        {
                            if (guess < tar[i].numToGuess)
                                Console.WriteLine("Incorrect...guess higher!");
                            else if (guess > tar[i].numToGuess)
                                Console.WriteLine("Incorrect...guess lower!");
                        }
                        else
                        {
                            //After a set amount of guesses, the user will be provided with more assistance 
                            Console.WriteLine("Incorrect...you are " + (Math.Abs(tar[i].numToGuess - guess)) + " away!");
                        }
                    }
                    count++;
                }
                Console.WriteLine("\n");
            }
        }

        static void Main(string[] args)
        {
          
            //array of targetInt objects
            targetInt[] arr = new targetInt[NUM_OBJ];  
            
            //initializes targetInt objects
            for (int i = 0; i < NUM_OBJ; i++)  
                arr[i] = new targetInt(random.Next(RAND_LIMIT)); //have to pass random number to constructor 

            Console.WriteLine("Welcome to the Guessing Game! (but not really)");
            Console.WriteLine("\n");
            Console.WriteLine("The purpose of this program is to test the targetInt class by using all");
            Console.WriteLine("the variables and implementing all the functions encapsulated in it.");
            Console.WriteLine("\n");

            Console.WriteLine("Press enter to get results of the tests...");
            Console.ReadKey();

            Console.Clear();

            Console.WriteLine("-------------------------"); 
            Console.WriteLine("Test 1: Using Constructor");
            Console.WriteLine("-------------------------");
            Console.WriteLine("\n");

            runTest(arr); 

            Console.WriteLine("---------------------");
            Console.WriteLine("Statistics for Test 1");
            Console.WriteLine("---------------------");
            Console.WriteLine("\n");

            stats(arr);

            //Resets the data fields for the all the targetInt objects 
            for (int i = 0; i < NUM_OBJ; i++)
                arr[i].reset(random.Next(RAND_LIMIT)); 

            Console.WriteLine("----------------------------"); 
            Console.WriteLine("Test 2: Using reset function");
            Console.WriteLine("----------------------------");
            Console.WriteLine("\n");

            runTest(arr); 

            Console.WriteLine("---------------------");
            Console.WriteLine("Statistics for Test 2");
            Console.WriteLine("---------------------");
            Console.WriteLine("\n");

            stats(arr); 

            Console.WriteLine("Press enter to exit program...");
            Console.ReadKey(); 
        }
    }
}