using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day22
    {
        public class Player
        {
            public List<int> Cards { get; set; }
            public List<string> PastPlays { get; set; }

            public static Player Create(string input)
            {
                var list = input.Split(
                    new[] {"\r\n", "\r", "\n"},
                    StringSplitOptions.None).ToList();

                list.RemoveAt(0);
                return new Player()
                {
                    Cards = list.Select(int.Parse).ToList()
                };
            }

            public void Win(int cardWin, int CardLoose)
            {
                Cards.Add(cardWin);
                Cards.Add(CardLoose);
            }

            public void Loose()
            {
            }

            public bool Record()
            {
                if (PastPlays == null) PastPlays = new List<string>();
                var list = string.Join(";", Cards);

                if (PastPlays.Contains(list)) return true;
                PastPlays.Add(list);
                return false;
            }

            public Player Clone(int nbCards)
            {
                var cards = new List<int>();

                for (var i = 0; i < nbCards; i++)
                {
                    cards.Add(Cards[i]);
                }

                return new Player()
                {
                    Cards = cards
                };
            }
        }

        public List<Player> PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n\r\n", "\r\r", "\n\n"},
                StringSplitOptions.None);

            return list.Select(x => Player.Create(x)).ToList();
        }

        public long CalculateWinnerScore(List<Player> players)
        {
            Play(players);

            var winner = players.Single(x => x.Cards.Any());

            winner.Cards.Reverse();
            var score = 0;
            for (var x = 0; x < winner.Cards.Count; x++)
            {
                score += winner.Cards[x] * (x + 1);
            }
            return score;
        }

        public void Play(List<Player> players)
        {
            while (players.All(x => x.Cards.Any()))
            {
                var card1 = players[0].Cards.First();
                var card2 = players[1].Cards.First();

                players[0].Cards.RemoveAt(0);
                players[1].Cards.RemoveAt(0);

                if (card1 > card2)
                {
                    players[0].Win(card1, card2);
                    players[1].Loose();
                }
                else
                {
                    players[1].Win(card2, card1);
                    players[0].Loose();
                }
            }
        }

        public static Dictionary<string, int> PastPlays = new Dictionary<string, int>();

        public int PlayRecursive(List<Player> players, int level = 0)
        {
            int round = 0;
            while (players.All(x => x.Cards.Any()))
            {
                if (players.All(player => player.Record())) return 0;

                var card1 = players[0].Cards.First();
                var card2 = players[1].Cards.First();

                if (players.All(x => x.Cards.Any() && x.Cards.First() <= x.Cards.Count - 1))
                {
                    players[0].Cards.RemoveAt(0);
                    players[1].Cards.RemoveAt(0);
                    
                    var player0 = players[0].Clone(card1);
                    var player1 = players[1].Clone(card2);

                    var p0 = string.Join("", player0.Cards);
                    var p1 = string.Join(";", player1.Cards);
                    var key = $"{p0}::{p1}";

                    var indexOfWinner = 0;

                    if (!PastPlays.ContainsKey(key))
                    {
                        PastPlays[key] = PlayRecursive(new List<Player>() {player0, player1}, level+1);
                    }
                    
                    indexOfWinner = PastPlays[key];

                    if (indexOfWinner == 0)
                    {
                        players[0].Win(card1, card2);
                        players[1].Loose();
                    }
                    else
                    {
                        players[1].Win(card2, card1);
                        players[0].Loose();
                    }

                }
                else
                {
                    players[0].Cards.RemoveAt(0);
                    players[1].Cards.RemoveAt(0);

                    if (card1 > card2)
                    {
                        players[0].Win(card1, card2);
                        players[1].Loose();
                    }
                    else
                    {
                        players[1].Win(card2, card1);
                        players[0].Loose();
                    }
                }

                round++;
            }

            var winner = players.Single(x => x.Cards.Any());
            return players.IndexOf(winner);
        }

        public long CalculateWinnerRecursiveScore(List<Player> players)
        {
            var indexOfWinner  = PlayRecursive(players);

            var winner = players[indexOfWinner];

            winner.Cards.Reverse();
            var score = 0;
            for (var x = 0; x < winner.Cards.Count; x++)
            {
                score += winner.Cards[x] * (x + 1);
            }
            return score;
        }
    }
}
