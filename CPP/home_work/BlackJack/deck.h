#pragma once
#include "card.h"
#define CNT_CARDS 54

class deck{
	card _deck[CNT_CARDS];
	int cntCards=CNT_CARDS;
public:
	deck();
	void init_deck();
	void get();
	int get_cntCards();
	void shuffle();
	card operator[](const int&);
	void operator--();
};
