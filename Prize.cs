using System;
using System.Linq;

namespace Quest
{
    public class Prize
    {
        private string _text { get; }

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness > 0)
            {
                Console.WriteLine("For your awesomeness, you have received:");
                foreach (int value in Enumerable.Range(0, adventurer.Awesomeness))
                    Console.WriteLine(_text);
            }
            else
            {
                Console.WriteLine(
                    "A prize? Oh, uh... here you go. You can have this lint from my pocket... I guess."
                );
            }
        }
    }
}
