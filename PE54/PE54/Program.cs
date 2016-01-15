using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE54
{


    class PE54
    {
        static void Main(string[] args)
        {
            string[] handString = System.IO.File.ReadAllLines("p054_poker.txt");
            int p1Wins = 0;
            int p2Wins = 0;
            for (int i = 0; i < handString.Length; i++)
            {
                int lastWin = p1Wins;
                string[] hands = handString[i].Split(new char[] { ' ' });

                Card[] p1Cards = new Card[5];
                Card[] p2Cards = new Card[5];

                for (int j = 0; j < hands.Length; j++)
                {
                    if (j < 5)
                        p1Cards[j] = new Card(hands[j].ToUpper());
                    else
                    {
                        p2Cards[j - 5] = new Card(hands[j].ToUpper());
                    }
                }

                Hand p1 = new Hand(p1Cards);
                Hand p2 = new Hand(p2Cards);


                for (int j = 0; j < p1.ranks.Count; j++)
                {
                    bool breakOuterLoop = false;
                    if (p1.ranks[j] > p2.ranks[j])
                    {
                        Console.WriteLine("Hand " + i + " winner = 1");
                        p1Wins++;
                        break;
                    }
                    else if (p1.ranks[j] < p2.ranks[j])
                    {
                        Console.WriteLine("Hand " + i + " winner = 2");
                        p2Wins++;
                        break;
                    }
                    else if (p1.ranks[j] != 0 && p1.ranks[j] == p2.ranks[j])
                    {
                        for (int k = 4; k >= 0; k--)
                        {
                            if (p1.cards[k].value > p2.cards[k].value)
                            {
                                Console.WriteLine("Hand " + i + " winner = 1");
                                p1Wins++;
                                breakOuterLoop = true;
                                break;
                            }
                            else if (p1.cards[k].value < p2.cards[k].value)
                            {
                                Console.WriteLine("Hand " + i + " winner = 2");
                                p2Wins++;
                                breakOuterLoop = true;
                                break;

                            }
                        }
                    }

                    if (breakOuterLoop)
                        break;
                }

              
            }

            Console.WriteLine("p1wins: " + p1Wins);
            Console.WriteLine("p2wins: " + p2Wins);
            Console.WriteLine("total hands = " + (p1Wins + p2Wins).ToString());
            Console.ReadLine();
        }

        public class Hand
        {
            public List<Card> cards;

            public int highCard = 0;

            public int flush = 1;

            public int straight;

            public List<int> ranks = new List<int>();

            public Hand(Card[] crds)
            {
                cards = crds.ToList();

                cards.Sort((a, b) => a.value.CompareTo(b.value));

                char tmpSuit = cards[0].suit;
                int highCardNdx = 0;
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].value >= highCard)
                    {
                        highCard = cards[i].value;
                        highCardNdx = i;
                    }

                    if (flush == 1 && cards[i].suit != tmpSuit)
                    {
                        flush = 0;
                    }
                }
              //  Console.WriteLine("highCardNdx = " + highCardNdx);
                if (this.containsNum(highCard - 1) && this.containsNum(highCard - 2) && this.containsNum(highCard - 3) && this.containsNum(highCard - 4))
                {
                    straight = highCard;
                }
                else
                {
                    straight = 0;
                }

                ranks.Add(highCard);
                ranks.Add(onePair);
                ranks.Add(twoPair);
                ranks.Add(threeOAK);
                ranks.Add(straight);
                ranks.Add(flush);
                ranks.Add(fullHouse);
                ranks.Add(fourOAK);
                ranks.Add(straightFlush);
                ranks.Add(royalFlush);

                ranks.Reverse();

            }

            public int onePair
            {
                get
                {
                    for (int i = 0; i < cards.Count; i++)
                    {
                        for (int j = 0; j < cards.Count; j++)
                        {
                            if (j != i && cards[i].value == cards[j].value)
                                return cards[j].value;
                        }
                    }

                    return 0;
                }
            }

            public int twoPair
            {
                get
                {
                    if (onePair == 0)
                        return 0;

                    for (int i = 0; i < cards.Count; i++)
                    {
                        for (int j = 0; j < cards.Count; j++)
                        {
                            if (j != i && cards[i].value == cards[j].value && cards[i].value != onePair)
                                return Math.Max(cards[j].value, onePair);
                        }
                    }

                    return 0;
                }
            }

            public int fullHouse
            {
                get
                {
                    if (threeOAK != 0 && onePair != 0 && threeOAK != onePair)
                        return Math.Max(threeOAK, onePair);
                    else
                        return 0;


                }
            }

            public int threeOAK
            {
                get
                {
                    for (int i = 0; i < cards.Count; i++)
                    {
                        int count = 0;
                        int checkVal = cards[i].value;

                        for (int j = 0; j < cards.Count; j++)
                        {
                            if (cards[j].value == checkVal)
                                count++;

                            if (count == 3)
                                return checkVal;
                        }

                    }

                    return 0;
                }
            }

            public int fourOAK
            {
                get
                {
                    int checkThree = threeOAK;

                    if (checkThree == 0)
                        return 0;
                    else
                    {
                        int count = 0;
                        for (int i = 0; i < cards.Count; i++)
                        {
                            if (cards[i].value == checkThree)
                                count++;

                            if (count == 4)
                                return checkThree;
                        }
                    }

                    return 0;
                }
            }

            public int royalFlush
            {
                get
                {
                    if (highCard == 14 && straightFlush != 0)
                        return 1;
                    else
                        return 0;
                }
            }

            public int straightFlush
            {
                get
                {
                    if (straight != 0 && flush == 1)
                        return highCard;
                    else
                        return 0;
                }
            }

            private bool containsNum(int val)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].value == val)
                        return true;
                }

                return false;
            }




        }

        public enum Suits { Spades };
        public class Card
        {
            public int value;
            public char suit;
            public Card(string val)
            {
                suit = val[1];
                if (val[0] == '2')
                {
                    value = 2;
                }
                else if (val[0] == '3')
                {
                    value = 3;
                }
                else if (val[0] == '4')
                {
                    value = 4;
                }
                else if (val[0] == '5')
                {
                    value = 5;
                }
                else if (val[0] == '6')
                {
                    value = 6;
                }
                else if (val[0] == '7')
                {
                    value = 7;
                }
                else if (val[0] == '8')
                {
                    value = 8;
                }
                else if (val[0] == '9')
                {
                    value = 9;
                }
                else if (val[0] == 'T')
                {
                    value = 10;
                }
                else if (val[0] == 'J')
                {
                    value = 11;
                }
                else if (val[0] == 'Q')
                {
                    value = 12;
                }
                else if (val[0] == 'K')
                {
                    value = 13;
                }
                else if (val[0] == 'A')
                {
                    value = 14;
                }
            }
        }
    }
}