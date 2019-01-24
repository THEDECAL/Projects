#include "deck.h"

#define AM_CARDS 52
#define ASCII_ZERO 48

deck::deck(){
	_deck = new card[AM_CARDS];
	init();
}
void deck::init(){
	currAmCards = AM_CARDS;
	for(size_t i = 0,_suit = HEARTS; i<AM_CARDS; i += RANK_AMOUNT,_suit++){
		for(size_t j = 0,_rank = TWO; j<RANK_AMOUNT; j++,_rank++){
			_deck[j + i]._suit = (SUIT)_suit;
			_deck[j + i]._rank = (RANK)_rank;
		}
	}
	shuffle();
}
void deck::shuffle(){
	for(size_t i = 0; i < AM_CARDS; i++){
		unsigned rnum = rand() % AM_CARDS;
		card temp = _deck[i];
		_deck[i] = _deck[rnum];
		_deck[rnum] = temp;
	}
}
void deck::ShowCard(const bool& isHide,const card *_cards,const unsigned& amount){
	const unsigned height = 7;
	const unsigned width = 7;
	for(size_t i = 0; i<height+2; i++){
		for(size_t j = 0; j<amount; j++){
			char spc,spa,sui,ran;
			if(isHide) spc = spa = sui = ran = 206; //Для показа рубашки карты
			else{
				spc = spa = ' ';
				sui = _cards[j]._suit;
				ran = _cards[j]._rank;

				if(ran >= TEN){
					if(ran == TEN){
						ran = '1'; spc = '0';
					}
					else if(ran == JACK) ran = 'J';
					else if(ran == QUEEN) ran = 'Q';
					else if(ran == KING) ran = 'K';
					else if(ran == ACE) ran = 'A';
				}
				else ran = ASCII_ZERO + _cards[j]._rank;
			}

			char card[height+2][width + 2] = {
				{196,196,196,196,196,196,196,196,'\0'}, //рамка
				{201,205,205,205,205,205,187,' ','\0'},
				{186,ran,spc,spa,spa,spa,186,' ','\0'},
				{186,spa,spa,spa,spa,spa,186,' ','\0'},
				{186,spa,spa,sui,spa,spa,186,' ','\0'},
				{186,spa,spa,spa,spa,spa,186,' ','\0'},
				{186,spa,spa,spa,ran,spc,186,' ','\0'},
				{200,205,205,205,205,205,188,' ','\0'},
				{196,196,196,196,196,196,196,196,'\0'}}; //рамка

			if(j == 0){
				if(i == 0) std::cout << (char)218 << (char)196; //рамка
				else if(i == height + 1) std::cout << (char)192 << (char)196; //рамка
				else std::cout << (char)179 << ' '; //рамка
			}
			printf(card[i]);
		}
		if(i == 0) std::cout<<(char)191; //рамка
		else if(i == height + 1) std::cout << (char)217; //рамка
		else std::cout << (char)179; //рамка
		printf("\n");
	}
}
void deck::ShowDeck(){
	const unsigned AmountCards = 4;

	for(size_t i = 0; i < AM_CARDS; i+=AmountCards){
		card cards[AmountCards];
		for(size_t j = 0; j < AmountCards; j++)
			cards[j] = _deck[i+j];
		ShowCard(false,cards,AmountCards);
	}
}
card deck::getCard(){
	return _deck[currAmCards---1];
}
unsigned deck::getCurrentCards(){
	return currAmCards;
}
std::string deck::getCardName(const unsigned& rank){
	if(rank >=JACK && rank<=ACE) return cardsName[rank - JACK];
	else if(rank>=TWO && rank<=TEN) return std::to_string(rank);
	else throw "There is no such card";
}
deck::~deck(){
	delete[]_deck;
}
