/*
 * Ryan Zhang
 * PE - Magic 8 Ball
 * https://docs.google.com/document/d/13OBHKxRLnRKNiYijs119CSW9Y7kW77oRCd1uovYR-Hs/edit?usp=sharing
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Magic8Ball_Zhang
{
    /// <summary>
    /// Class for Magic 8 Ball, gives the owner a response when the ball is shaken.
    /// </summary>
    internal class MagicEightBall
    {
        // name of the person holding the ball
        private string owner;
        // number of times the ball has been shaken
        private int timesShaken;
        // list of potential responses the ball can tell the user
        private string[] responses;
       
        private Random random;

        /// <summary>
        /// Constructs a magic 8 ball with the owner as an input/
        /// </summary>
        /// <param name="owner"></param>
        public MagicEightBall(string owner)
        {
            this.owner = owner;
            timesShaken = 0;
            responses = new string[5] {"Definitely.", "Not likely.", "Never.", "Cannot predict right now.", "Ask again later."};
            random = new Random();
        }

        /// <summary>
        /// Shakes the Magic 8 Ball and returns a random response. Increments the number of times shaken by one.
        /// </summary>
        /// <returns></returns>
        public string ShakeBall()
        {
            timesShaken++;
            return responses[random.Next(0, 5)];
        }

        /// <summary>
        /// Returns a string stating how many times the ball has been shaken.
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            switch (timesShaken)
            {
                case 0:
                    return String.Format("{0} has not shaken the ball yet.", owner);

                case 1:
                case 2:
                case 3:
                    return String.Format("{0} has shaken the ball {1} times.", owner, timesShaken);

                case >= 4:
                    return String.Format("{0} has shaken the ball {1} times. That's a lot of questions!", owner, timesShaken);

                default:
                    return null;
            }
        }
    }
}
