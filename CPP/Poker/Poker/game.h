#pragma once

#include <string>
#include <vector>
#include "deck.h"
#include "player.h"
using std::string;
using std::vector;
using std::cout;
using std::cin;
using std::endl;

const enum combo{
	HIGH_CARD = 1,
	ONE_PAIR,
	TWO_PAIRS,
	THREE_OF_A_KIND,
	STRAIGHT,
	FLUSH,
	FULL_HOUSE,
	FOUR_OF_A_KIND,
	STRAIGHT_FLUSH,
	ROYAL_FLUSH
};
const string messCombo[] = {
	"High Card",
	"One Pair",
	"Two Pair",
	"Three of a Kind",
	"Straight",
	"Flush",
	"Full House",
	"Four of a Kind",
	"Straight Flush",
	"Royal Flush"
};

class game{
	deck _deck;
	const unsigned maxAmPlayers;
	player *players;
	vector<string> messages;
	unsigned bank;
	unsigned cntGames;
	bool GameOver;
public:
	game(const unsigned&,const string&);
	void init(); //������� ����� � ����� ��������� ������
	void newGame();
	void show(const bool& = true); //�������� ����� ������ � ������� ���� ����������
	int getCombo(const unsigned&); //������� ����������
	string showCombo(const unsigned&);
	void placeBet(); //������� ������
	void checkWinners();
	bool debug();
	~game();
};
