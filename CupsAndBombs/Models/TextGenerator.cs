using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupsAndBombs.Models
{
    class TextGenerator
    {
        private String[] quotes;
        private Random r;

        public TextGenerator()
        {
            quotes = new String[]{
            "Luck is what happens when preparation meets opportunity.\nSeneca (5 BC – 65 AD)",
            "By gaming we lose both our time and treasure – two things most precious to the life of man.\nOwen Feltham (1602-1668)",
            "True luck consists not in holding the best of the cards at the table, luckiest he who knows just when to rise and go home.\nJohn Ray (1627-1705)",
            "If you would be wealthy, think of saving as well as getting.\nBenjamin Franklin (1706-1790)",
            "I’m a great believer in luck, and I find the harder I work the more I have of it. Thomas Jefferson (1743-1826)",
            "Chance only favours the prepared mind.\nLouis Pasteur (1822-1895)",
            "It is not a lucky word, this name “impossible”, no good comes of those who have it so often in their mouths.\nThomas Carlyle (1795-1881)",
            "What helps luck is a habit of watching for opportunities, of having a patient, but restless mind, of sacrificing one’s ease or vanity, of uniting a love of detail to foresight, and of passing through hard times bravely and cheerfully.\nCharles Victor Cherbuliez (1829-1899)",
            "A dollar picked up in the road is more satisfaction to us than the 99 which we had to work for, and the money won at Faro or in the stock market snuggles into our hearts in the same way.\nMark Twain (1835-1910)",
            "The only sure thing about luck is that it will change.\nBret Harte (1836-1902)",
            "The gambling known as business looks with austere disfavor upon the business known as gambling.\nAmbrose Bierce (1842-1914), The Devil’s Dictionary",
            "When I was young, people called me a gambler. As the scale of my operations increased I became known as a speculator. Now I am called a banker. But I have been doing the same thing all the time.\nSir Ernest Cassel (1852-1921)",
            "It is better to have a permanent income than to be fascinating.\nOscar Wilde (1854-1900), The Model Millionaire",
            "Experience is the name everyone gives to their mistakes.\nOscar Wilde (1854-1900), Lady Windermere’s Fan, Act III",
            "Whenever a man does a thoroughly stupid thing, it is always from the noblest motives.\nOscar Wilde (1854-1900), The Picture of Dorian Gray",
            "The roulette table pays nobody except him that keeps it. Nevertheless a passion for gaming is common, though a passion for keeping roulette tables is unknown.\nGeorge Bernard Shaw (1856-1950)",
            "In gambling the many must lose in order that the few may win.\nGeorge Bernard Shaw (1856-1950)",
            "The golden rule is that there are no golden rules.\nGeorge Bernard Shaw (1856-1950)",
            "The only man who makes money following the races is one who does it with a broom and shovel.\nElbert Hubbard (1856-1915)",
            "Luck, bad if not good, will always be with us. But it has a way of favoring the intelligent and showing its back to the stupid.\nJohn Dewey (1859-1952)",
            "The safest way to double your money is to fold it over once and put it in your pocket.\nKim Hubbard (1868-1930)",
            "Gambling: The sure way of getting nothing from something.\nWilson Mizner (1876-1933)",
            "The urge to gamble is so universal and its practice so pleasurable, that I assume it must be evil.\nHeywood Broun (1888-1939)",
            "You don’t gamble to win. You gamble so you can gamble the next day.\nBert Ambrose (1896–1971)"
            };

            r = new Random();
        }

        public string GetRandomQuote()
        {
            return quotes[r.Next(0, quotes.Length - 1)];
        }
    }
}
