#include "player.h"
#include <string.h>

player::player(const bool& croupier){
	if(croupier){
		this->croupier=croupier;
		_deck.init_deck();
	}
	cards=NULL;
	cntCards=0;
	strcpy_s(name,"Player");
	score=0;
}
player::player(const player& o){
	strcpy_s(this->name,o.name);
	utility::arrayToArray(this->cards,o.cards,cntCards);
	this->cntCards=o.cntCards;
	this->score=o.score;
}
player& player::operator=(const player& o){
	strcpy_s(this->name,o.name);
	utility::arrayToArray(this->cards,o.cards,cntCards);
	this->cntCards=o.cntCards;
	this->score=o.score;

	return *this;
}
void player::clear(){
	if(cards) delete[]cards;
	cntCards=0;
	score=0;
}
void player::set_name(const char* name){
	strncpy_s(this->name,name,SIZE_NAME-1);
}
char* player::get_name(){
	return name;
}
card player::issue_card(){
	if(_deck.get_cntCards())
		--_deck;
	return _deck[_deck.get_cntCards()];
}
void player::add_card(const card& refCard){
	score+=refCard.get_value();
	if (cntCards){
		//if(cards[0].get_value()==ace&&refCard.get_value()==ace)
		//	score-=20;
		card *temp = new card[cntCards + 1];
		utility::arrayToArray(temp, cards, cntCards);
		delete[]cards;
		cards = new card[cntCards + 1];
		utility::arrayToArray(cards, temp, cntCards);
		cards[cntCards]=refCard;
		delete[]temp;
	}
	else{
		cards = new card[cntCards + 1];
		cards[cntCards] = refCard;
	}
	cntCards++;
}
void player::get_deck(){
	_deck.get();
}
int player::get_score(){
	return score;
}
void player::get(const bool& hide){
	std::cout<<"----------------\n";
	std::cout<<"Name: "<<name<<"\n";
	std::cout<<"----------------\n";
	std::cout<<"Cards: "<<"\n";
	for(int i=0; i<cntCards; i++){
		if(hide && i==0) cards[i].get(hide);
		else cards[i].get();
	}
	std::cout<<"\n";
	std::cout<<"----------------\n";
	std::cout<<"Score: "<<"\n";
	if(croupier) std::cout<<score-cards[0].get_value()<<"\n";
	else std::cout<<score<<"\n";
	std::cout<<"----------------\n";
}
player::~player(){
	if(cards) delete[]cards;
}
