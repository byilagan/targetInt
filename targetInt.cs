//Bailey Ilagan
//September 29, 2016 
//targetInt.cs 
//The purpose of this is to implement the targetInt object. A targetInt can hold a random number a user
//can try to guess. 


using System; 

namespace Target
{

    class targetInt
    {
        //assumes that most variables can be received but can't changed (private setter)
        //all getters are used to print out stats in the driver    

        public int numGuess { get; private set; } //number of guesses the user has made for this object
        public int highGuess { get; private set; } //highest guess user has made
        public int lowGuess { get; private set; } //lowest guess user has made
        public int avgGuess { get; private set; } //average guess user has made     
        public int numToGuess { get; private set; } //target number user has to guess
        private int total; //the total that all the guesses add up to (used for average calculation)  
        private bool known; //true if number is guessed correctly 
        
        //constructor 
        //int num is the random number passed in that will be the target number (numToGuess) 
        public targetInt(int num)
        {
            numToGuess = num;
            numGuess = 0;
            highGuess = -1;
            lowGuess = -1;
            avgGuess = 0;
            total = 0; 
            known = false; 
        }


        //resets all the data fields back to normal 
        //int num is the random number passed in that will be the target number (numToGuess) 
        public void reset(int num)
        {
            numToGuess = num;
            numGuess = 0;
            highGuess = -1;
            lowGuess = -1;
            avgGuess = 0;
            total = 0; 
            known = false; 
        }

        //returns true if the number was found 
        //no parameters
        //does not change any variables 
        public bool found()
        {
            if (known)
                return true; 
            else
                return false; 
        }

        //updates all the data fields with the passed value 
        //int val is the user guess or in this case the random number acting as a guess 
        public void update(int val)
        {
            if (val > highGuess) //checks to see if val is higher than highGuess
                highGuess = val; 
            if (lowGuess == -1 || val < lowGuess) //checks to see if val is lower than lowGuess
                lowGuess = val;
            if (val == numToGuess) //checks if target number has been found 
                known = true; //changes the state of known to true if found 

            numGuess++; 
            total = total + val; //update total
            avgGuess = total / numGuess; //average calculation 
        }
    }
}
