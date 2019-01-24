#include "deck.h"

deck::deck(){
	_deck[CNT_CARDS];
	cntCards=0;
}
void deck::init_deck(){
	cntCards=CNT_CARDS;
	const int totalSuits=4;
	const int totalJockers=2;
	const int size=(CNT_CARDS-totalJockers)/totalSuits;

	for(int k=0,i=0; i<totalSuits; i++,k+=size){
		for(int j=0; j<size;j++){
			_deck[j+k].set(j+card2,heart+i);
		}
	}
	_deck[CNT_CARDS-2].set(jocker,white);
	_deck[CNT_CARDS-1].set(jocker,black);
	shuffle();
}
void deck::shuffle(){
	for(int i=0; i<CNT_CARDS;i++){
		card temp(_deck[i]);
		int randomNum=rand()%CNT_CARDS;
		_deck[i]=_deck[randomNum];
		_deck[randomNum]=temp;
	}
}
int deck::get_cntCards(){
	return cntCards;
}
void deck::get(){
	for(int i=0; i<CNT_CARDS; i++){
		std::cout<<i+1<<". ";
		_deck[i].get();
	}
}
card deck::operator[](const int& index){
	return _deck[index];
}
void deck::operator--(){
	if(cntCards>0) cntCards--;
}
