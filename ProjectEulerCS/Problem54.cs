using PendleCodeMonkey.ProjectEulerCS.Data;
using System.Text;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem54
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 54 - Poker hands


				In the card game poker, a hand consists of five cards and are ranked, from lowest to highest, in the following way:

					High Card: Highest value card.
					One Pair: Two cards of the same value.
					Two Pairs: Two different pairs.
					Three of a Kind: Three cards of the same value.
					Straight: All cards are consecutive values.
					Flush: All cards of the same suit.
					Full House: Three of a kind and a pair.
					Four of a Kind: Four cards of the same value.
					Straight Flush: All cards are consecutive values of same suit.
					Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.

				The cards are valued in the order:
				2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace.

				If two players have the same ranked hands then the rank made up of the highest value wins; for example, a pair of eights beats a pair
				of fives (see example 1 below). But if two ranks tie, for example, both players have a pair of queens, then highest cards in each hand
				are compared (see example 4 below); if the highest cards tie then the next highest cards are compared, and so on.

				Consider the following five hands dealt to two players:

				Hand	 	Player 1	 			Player 2	 			Winner
				1	 		5H 5C 6S 7S KD			2C 3S 8S 8D TD			Player 2
							(Pair of Fives)			(Pair of Eights)

				2	 		5D 8C 9S JS AC			2C 5C 7D 8S QH			Player 1
							(Highest card Ace)		(Highest card Queen)

				3	 		2D 9C AS AH AC			3D 6D 7D TD QD			Player 2
							(Three Aces)			(Flush with Diamonds)

				4	 		4D 6S 9H QH QC			3D 6D 7H QD QS			Player 1
							(Pair of Queens			(Pair of Queens
							Highest card Nine)		Highest card Seven)

				5	 		2H 2D 4C 4D 4S			3C 3D 3S 9S 9D			Player 1
							(Full House				(Full House
							With Three Fours)		with Three Threes)

				The file, p054_poker.txt, contains one-thousand random hands dealt to two players. Each line of the file contains ten cards (separated by a
				single space): the first five are Player 1's cards and the last five are Player 2's cards. You can assume that all hands are valid (no invalid
				characters or repeated cards), each player's hand is in no specific order, and in each hand there is a clear winner.

				How many hands does Player 1 win?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Read the data from the p054_poker.txt file into a list of strings (one per line in the file)
			var data = Problem54Data.GetData();

			int numberOfPlayerOneWins = 0;

			// Handle each game (i.e. line of card data) that has been read from the text file.
			foreach (var gameData in data)
			{
				// Split the game data into its 10 constituent parts (which are separated by space characters) - the first 5 are
				// player one's cards, the remaining 5 are player two's cards.
				string[] cards = gameData.ToUpper().Split(' ');
				// Create a Hand object from the first 5 cards (for player one)
				var playerOneHand = new Hand(cards.Take(5));
				// Create a Hand object from the remaining 5 cards (for player two) by skipping the first 5 and taking the remaining 5.
				var playerTwoHand = new Hand(cards.Skip(5).Take(5));

				// Compare the two Hand objects to determine the winning hand.
				if (playerOneHand > playerTwoHand)
				{
					// Player one wins this hand so increment the count.
					numberOfPlayerOneWins++;
				}
			}

			return numberOfPlayerOneWins;
		}
	}

	// Class that represents a single card.
	class Card : IComparable
	{
		// Enumeration of the possible face values for a card.
		internal enum FaceValues
		{
			Two,
			Three,
			Four,
			Five,
			Six,
			Seven,
			Eight,
			Nine,
			Ten,
			Jack,
			Queen,
			King,
			Ace
		}

		// Enumeration of the possible suits for a card.
		internal enum Suits
		{
			Clubs,
			Diamonds,
			Hearts,
			Spades
		}

		// Dictionary that maps the character representation of a card (e.g. "K") with its enumerated FaceValue (e.g. FaceValues.King).
		internal readonly Dictionary<char, FaceValues> faceValuesMap = new() {
			{ '2', FaceValues.Two },
			{ '3', FaceValues.Three },
			{ '4', FaceValues.Four },
			{ '5', FaceValues.Five },
			{ '6', FaceValues.Six },
			{ '7', FaceValues.Seven },
			{ '8', FaceValues.Eight },
			{ '9', FaceValues.Nine },
			{ 'T', FaceValues.Ten },
			{ 'J', FaceValues.Jack },
			{ 'Q', FaceValues.Queen },
			{ 'K', FaceValues.King },
			{ 'A', FaceValues.Ace }
		};

		// Dictionary that maps the character representation of a suit (e.g. "D") with its enumerated Suits value (e.g. Suits.Diamonds).
		internal readonly Dictionary<char, Suits> suitMap = new() {
			{ 'C', Suits.Clubs },
			{ 'D', Suits.Diamonds },
			{ 'H', Suits.Hearts },
			{ 'S', Suits.Spades }
		};

		internal FaceValues FaceValue { get; private set; }
		internal Suits Suit { get; private set; }

		// Constructor that takes a string containing the shortened (2-character) representation of a card (e.g. 2H for the Two of Hearts)
		public Card(string cardString)
		{
			// The first character is the card's face value so map this character to the corresponding FaceValues enumerated value.
			FaceValue = faceValuesMap[cardString[0]];
			// The second character is the card's suit so map this character to the corresponding Suits enumerated value.
			Suit = suitMap[cardString[1]];
		}

		public override int GetHashCode()
		{
			return (int)Suit * 20 + (int)FaceValue;
		}

		public override string ToString()
		{
			return FaceValue.ToString() + " of " + Suit.ToString();
		}

		// Compares the current card with the supplied object (which obviously must also be a Card object).
		// This compares the face values of the two cards (as the suits don't matter)
		public int CompareTo(Object? obj)
		{
			Card compareCard = obj as Card ?? throw new ArgumentException("Comparison object is not a Card");
			if (FaceValue == compareCard.FaceValue)
			{
				return 0;
			}

			return FaceValue > compareCard.FaceValue ? 1 : -1;
		}

		public override bool Equals(Object? obj)
		{
			if (obj is not Card)
			{
				return false;
			}

			return CompareTo(obj) == 0;
		}

		public static bool operator ==(Card card1, Card card2)
		{
			return card1.Equals(card2);
		}

		public static bool operator !=(Card card1, Card card2)
		{
			return !(card1 == card2);
		}
		public static bool operator >(Card card1, Card card2)
		{
			return card1.CompareTo(card2) > 0;
		}

		public static bool operator <(Card card1, Card card2)
		{
			return card1.CompareTo(card2) < 0;
		}
	}

	// Class that represents a hand of 5 cards.
	// Performs a calculation to determine the ranking of the hand, and comparison
	// with another hand to determine the winner.
	class Hand : IComparable
	{
		// Enumeration of the possible ranking values.
		internal enum Rankings
		{
			HighCard,
			OnePair,
			TwoPairs,
			ThreeOfAKind,
			Straight,
			Flush,
			FullHouse,
			FourOfAKind,
			StraightFlush,
			RoyalFlush
		}

		// List of the five cards in this hand.
		internal List<Card> CardsInHand { get; private set; }

		// The calculated ranking for this hand.
		internal Rankings Ranking { get; private set; }

		// Constructor that builds the hand of cards.
		// Takes an enumerable collection of five card strings (e.g. "8C", "TS", "KC", "9H", "4S") and
		// creates a Card object corresponding to each, adding them to the list of cards.
		public Hand(IEnumerable<string> cards)
		{
			CardsInHand = new List<Card>();
			foreach (var card in cards)
			{
				CardsInHand.Add(new Card(card));
			}

			// Determine the ranking of this hand.
			Ranking = CalculateRanking();
		}

		// Calculate the ranking for this hand of cards.
		private Rankings CalculateRanking()
		{
			// Get a dictionary containing the face values of the cards in the hand, grouped by frequency.
			var groupedByFreq = GroupByFrequency();
			// Detrermine the number of distinct suits in the hand.
			int numberOfDistinctSuits = CardsInHand.Select(x => x.Suit).Distinct().Count();

			// Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.			(when lowest card is a 10)
			// Straight Flush: All cards are consecutive values of same suit.   (when lowest card is anything other than a 10)
			if (numberOfDistinctSuits == 1 && AllFaceValuesAreConsecutive())
			{
				// Only a single distinct suit (so all cards are of the same suit) and all cards have consecutive face values; therefore
				// we either have a Royal Flush or a Straight Flush (depending on the value of the lowest card)
				return LowestCardValue() == Card.FaceValues.Ten ? Rankings.RoyalFlush : Rankings.StraightFlush;
			}

			// Four of a Kind: Four cards of the same value.
			if (groupedByFreq.Any(x => x.Frequency == 4))
			{
				// Grouping by frequency of face values yielded a group of 4 cards with the same face value.
				return Rankings.FourOfAKind;
			}

			// Full House: Three of a kind and a pair.
			if (groupedByFreq.Count == 2)
			{
				// Grouping by frequency of face values yielded only 2 groups, so one must be for three of a kind and
				// the other must be a pair.
				return Rankings.FullHouse;
			}

			// Flush: All cards of the same suit.
			if (numberOfDistinctSuits == 1)
			{
				// Only a single distinct suit; therefore all cards must be of that suit.
				return Rankings.Flush;
			}

			// Straight: All cards are consecutive values.
			if (AllFaceValuesAreConsecutive())
			{
				// We've already handled Royal Flush and Straight Flush (which also have all consecutive face values), so at this
				// stage, this hand must be a Straight.
				return Rankings.Straight;
			}

			// Three of a Kind: Three cards of the same value.
			if (groupedByFreq.Any(x => x.Frequency == 3))
			{
				// Grouping by frequency of face values yielded a group of 3 cards with the same face value.
				return Rankings.ThreeOfAKind;
			}

			// Two Pairs: Two different pairs.
			if (groupedByFreq.Where(x => x.Frequency == 2).Count() == 2)
			{
				// Grouping by frequency of face values yielded 2 groups with 2 cards of the same face value; therefore it's two pairs.
				return Rankings.TwoPairs;
			}

			// One Pair: Two cards of the same value.
			if (groupedByFreq.Where(x => x.Frequency == 2).Count() == 1)
			{
				// Grouping by frequency of face values yielded a single group with 2 cards of the same face value; therefore it's one pair.
				return Rankings.OnePair;
			}

			// High Card: Highest value card.
			return Rankings.HighCard;
		}

		// Retrieve the face value of the lowest card in the hand.
		private Card.FaceValues LowestCardValue()
		{
			return CardsInHand.OrderBy(card => card.FaceValue).First().FaceValue;
		}

		// Retrieve the face value of the highest card in the hand.
		private Card.FaceValues HighestCardValue()
		{
			return CardsInHand.OrderBy(card => card.FaceValue).Last().FaceValue;
		}

		// Determine if all cards are of consecutive value (for example: 8, 9, 10, J, Q)
		private bool AllFaceValuesAreConsecutive()
		{
			// Get a list of the cards sorted by face value.
			var sortedHand = CardsInHand.OrderBy(card => card.FaceValue);

			// Get the value of the first (i.e. smallest) card.
			int currentValue = (int)sortedHand.First().FaceValue;

			// Iterate through the remaining cards in the hand (i.e. skipping the first), checking if the
			// face value of each is one greater than the preceding card.
			foreach (var card in sortedHand.Skip(1))
			{
				int nextValue = (int)card.FaceValue;
				if (currentValue + 1 != nextValue)
				{
					return false;
				}
				currentValue = nextValue;
			}
			return true;
		}

		// Group the cards by the frequency of which their face value occurs in the hand.
		// This returns a list of tuples, each containing a face value and the frequency with which that value occurs in the hand.
		private List<(Card.FaceValues FaceValue, int Frequency)> GroupByFrequency()
		{
			return CardsInHand
				.GroupBy(card => card.FaceValue)
				.Select(x => new ValueTuple<Card.FaceValues, int>(x.Key, x.Count()))
				.OrderByDescending(x => x.Item2)
				.ToList();
		}

		public override int GetHashCode()
		{
			int hash = 0;
			int count = 0;
			foreach (var card in CardsInHand)
			{
				hash += (count * 100) + card.GetHashCode();
				count++;
			}

			return hash;
		}

		public int CompareTo(Object? obj)
		{
			Hand otherHand = obj as Hand ?? throw new ArgumentException("Comparison object is not a Hand");

			// If the two hands have equal ranking then we need to perform some additional checks to determine the winning hand.
			if (otherHand.Ranking == Ranking)
			{
				switch (Ranking)
				{
					// Cases where we also need to compare groups of cards.
					case Rankings.OnePair:
					case Rankings.TwoPairs:
					case Rankings.ThreeOfAKind:
					case Rankings.FullHouse:
					case Rankings.FourOfAKind:
						var groups = GroupByFrequency();
						var otherHandGroups = otherHand.GroupByFrequency();

						for (int i = 0; i < groups.Count; i++)
						{
							int compare;
							if ((compare = groups[i].FaceValue.CompareTo(otherHandGroups[i].FaceValue)) == 0)
							{
								continue;
							}
							return compare;
						}
						return 0;

					// Cases where the highest card value wins.
					case Rankings.HighCard:
					case Rankings.Straight:
					case Rankings.Flush:
					case Rankings.StraightFlush:
						return HighestCardValue().CompareTo(otherHand.HighestCardValue());
				}

			}

			return Ranking > otherHand.Ranking ? 1 : -1;
		}

		public override bool Equals(Object? obj)
		{
			if (obj is not Hand)
			{
				return false;
			}

			return CompareTo(obj) == 0;
		}

		public static bool operator ==(Hand hand1, Hand hand2)
		{
			return hand1.Equals(hand2);
		}

		public static bool operator !=(Hand hand1, Hand hand2)
		{
			return !(hand1 == hand2);
		}

		public static bool operator <(Hand hand1, Hand hand2)
		{
			return hand1.CompareTo(hand2) < 0;
		}

		public static bool operator >(Hand hand1, Hand hand2)
		{
			return hand1.CompareTo(hand2) > 0;
		}

		public override string ToString()
		{
			// Order cards by face value before generating the string representation.
			var orderedCards = CardsInHand.OrderBy(card => card.FaceValue).ToList();
			StringBuilder sb = new();
			foreach (var card in orderedCards)
			{
				if (sb.Length > 0)
				{
					sb.Append("| ");
				}
				sb.AppendFormat("{0} ", card.ToString());
			}
			sb.AppendFormat("   [Ranking: {0}]", Enum.GetName(typeof(Rankings), Ranking));
			return sb.ToString();
		}
	}
}
