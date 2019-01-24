#pragma once
#include "deck.h"
#include <vector>

class player{
	std::string name;
	unsigned amCards;
	card *cards;
	unsigned coins;
	int points;
	bool isEndGame;
public:
	player();
	void endGame();
	bool getEndGame();
	void newGame();
	void setName(const std::string&);
	void giveCard(const card&);
	void giveCoins(const unsigned&);
	void givePoints(const int&);
	unsigned getCoins();
	int getPoints();
	card* getCards();
	unsigned getAmCards();
	std::string getName();
	unsigned takeCoins(const unsigned&);
	void sort();
	~player();
};
