#pragma once
#include "utility.h"
#include "deck.h"
#define SIZE_NAME 11

class player{
	char name[SIZE_NAME];
	card *cards;
	int cntCards;
	int score;
	bool croupier;
	deck _deck;
	public:
	player(const bool& =false);
	player(const player&);
	player(const char* name){ set_name(name); };
	player& operator=(const player& o);
	void set_name(const char*);
	char* get_name();
	void get(const bool& =false);
	void get_deck();
	int get_score();
	void add_card(const card&);
	card issue_card();
	void clear();
	~player();
};
