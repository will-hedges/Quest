using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            Robe robe = new();
            robe.Colors = new List<string>() { "red", "white", "blue" };
            robe.Length = 69;

            Hat hat = new();
            hat.ShininessLevel = 6;

            Prize prize = new Prize("a treasure chest filled with gold");

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.Write($"What is your name?: ");
            string userName = Console.ReadLine().Trim();
            Adventurer theAdventurer = new Adventurer(userName, robe, hat);

            // main game loop
            ChallengeGame(theAdventurer);
            while (true)
            {
                // show the prize
                prize.ShowPrize(theAdventurer);

                // ask the user if they want to play again
                Console.WriteLine();
                Console.Write(
                    $"Do you wish to take on the challenge again, {theAdventurer.Name}? (Y/N): "
                );
                string repeatQuest = Console.ReadLine().ToLower().Trim();

                // if they answer "y", repeat the main game
                if (repeatQuest == "y")
                {
                    // set initial awesomeness to 50 * # of correct answers from the last game
                    // and reset correct answers to 0;
                    theAdventurer.Awesomeness = 50 + (theAdventurer.CorrectAnswers * 10);
                    theAdventurer.CorrectAnswers = 0;
                    ChallengeGame(theAdventurer);
                }
                else
                {
                    break;
                }
            }

            void ChallengeGame(Adventurer adventurer)
            {
                // Create a few challenges for our Adventurer's quest
                // The "Challenge" Constructor takes three arguments
                //   the text of the challenge
                //   a correct answer
                //   a number of awesome points to gain or lose depending on the success of the challenge
                Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
                Challenge theAnswer = new Challenge(
                    "What's the answer to life, the universe and everything?",
                    42,
                    25
                );
                Challenge whatSecond = new Challenge(
                    "What is the current second?",
                    DateTime.Now.Second,
                    50
                );

                int randomNumber = new Random().Next() % 10;
                Challenge guessRandom = new Challenge(
                    "What number am I thinking of?",
                    randomNumber,
                    25
                );

                Challenge favoriteBeatle = new Challenge(
                    @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                    4,
                    20
                );

                Challenge howManyStrings = new Challenge(
                    @"How many strings does a bass guitar have?
    1) One
    2) Two
    3) Three
    4) Four
",
                    4,
                    20
                );

                Challenge floofyCat = new Challenge(
                    @"Who is the floofiest cat?
    1) George
    2) Sammy
    3) Pie
    4) Bingus
",
                    2,
                    25
                );

                Challenge luckyNumber = new Challenge("What is my lucky number?", 6, 50);

                Challenge birthYear = new Challenge("What year was I born in?", 1992, 25);

                Challenge chileYear = new Challenge("What year did I go to Chile?", 2013, 30);

                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>()
                {
                    twoPlusTwo,
                    theAnswer,
                    whatSecond,
                    guessRandom,
                    favoriteBeatle,
                    howManyStrings,
                    floofyCat,
                    luckyNumber,
                    birthYear,
                    chileYear
                };

                // Before the adventurer starts their challenge, call the GetDescription method
                //  and print the results to the console.
                Console.WriteLine($"{theAdventurer.GetDescription()}");

                // choose 5 challenges at random
                Random rnd = new Random();
                List<Challenge> randomChallenges = new List<Challenge>();

                while (randomChallenges.Count < 5)
                {
                    Challenge randomChallenge = challenges[rnd.Next(challenges.Count)];
                    if (!randomChallenges.Contains(randomChallenge))
                    {
                        randomChallenges.Add(randomChallenge);
                    }
                }

                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in randomChallenges)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine(
                        "I guess you did...ok? ...sorta. Still, you should get out of my sight."
                    );
                }
            }
        }
    }
}
