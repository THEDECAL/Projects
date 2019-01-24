#pragma once

#include <iostream>
#include <string>

const enum RANK{
	TWO=2,
	THREE,
	FOUR,
	FIVE,
	SIX,
	SEVEN,
	EIGHT,
	NINE,
	TEN,
	JACK,
	QUEEN,
	KING,
	ACE,
	RANK_AMOUNT = ACE-1
};
const enum SUIT{
	HEARTS=3,
	DIAMONDS,
	SPADES,
	CLUBS,
	SUIT_AMOUNT = CLUBS-2
};
struct card{
	SUIT _suit;
	RANK _rank;
};

const std::string cardsName[] = {
	"Jack",
	"Queen",
	"King",
	"Ace"
};

class deck{
	unsigned currAmCards;
	card *_deck;
	void shuffle();
public:
	deck();
	void init();
	static void ShowCard(const bool&,const card*,const unsigned& =1);
	void ShowDeck();
	card getCard();
	static std::string getCardName(const unsigned&);
	unsigned getCurrentCards();
	~deck();
};
