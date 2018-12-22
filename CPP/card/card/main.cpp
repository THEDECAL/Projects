#include <iostream>
#include <time.h>
using namespace std;

const enum VAL{
	JOCKER=1,
	TWO,
	THREE,
	FOUR,
	FIVE,
	SIX,
	SEVEN,
	EACH,
	NINE,
	TEN,
	JACK,
	QUEEN,
	KING,
	ACE,
	VAL__AMOUNT = ACE
};
const enum SUIT{
	BLACK=1,
	WHITE,
	HEARTS,
	DIAMONDS,
	SPADES,
	CLUBS,
	SUIT_AMOUNT = CLUBS
};

struct card{
	SUIT _suit;
	VAL _val;
};

void show(const card* _cards,const unsigned& amount){
	const unsigned height=7;
	const unsigned width=7;
	for(size_t i=0; i<height; i++){
		for(size_t j=0; j<amount; j++){
			const char zero=48;
			char sui=_cards[j]._suit;
			unsigned val=_cards[j]._val;
			
			if(val>TEN){
				if(val == JACK) val='J';
				else if(val == QUEEN) val ='Q';
				else if(val == KING) val ='K';
				else if(val == ACE) val ='A';
			}
			else if(val == JOCKER) val =_cards[j]._suit;
			else val = zero+_cards[j]._val;

			char card[height][width+2]={
				{201,205,205,205,205,205,187,' ','\0'},
				{186,val,' ',' ',' ',' ',186,' ','\0'},
				{186,' ',' ',' ',' ',' ',186,' ','\0'},
				{186,' ',' ',sui,' ',' ',186,' ','\0'},
				{186,' ',' ',' ',' ',' ',186,' ','\0'},
				{186,' ',' ',' ',' ',val,186,' ','\0'},
				{200,205,205,205,205,205,188,' ','\0'}
			};

			printf(card[i]);
		}
		printf("\n");
	}
}

void main(){
	srand(time(0));

	const unsigned AmountCards=54;
	card deck[AmountCards];
	const unsigned UsedCard=52;

	deck[52]._suit = WHITE;
	deck[52]._val = JOCKER;
	deck[53]._suit = BLACK;
	deck[53]._val = JOCKER;
	for(size_t i=0,_suit=HEARTS; i<UsedCard; i+=(VAL__AMOUNT-1),_suit++){
		for(size_t j=0,_val=TWO; j<(VAL__AMOUNT-1); j++,_val++){
			deck[j+i]._suit=(SUIT)_suit;
			deck[j+i]._val=(VAL)_val;
		}
	}

	for(size_t i = 0; i < UsedCard; i++){
		unsigned rnum = rand() % UsedCard;
		card temp=deck[i];
		deck[i] = deck[rnum];
		deck[rnum] = deck[i];
	}

	show(deck,5);

	system("pause");
}
