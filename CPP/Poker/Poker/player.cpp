#include "player.h"

player::player(){
	name = "Player";
	cards = NULL;
	amCards = 0;
	coins = 0;
	points = 0;
	isEndGame = false;
}
void player::endGame(){ isEndGame = true; }
bool player::getEndGame(){ return isEndGame; }
void player::newGame(){
	if(cards) free(cards);
	cards = NULL;
	amCards = 0;
	points = 0;
}
void player::setName(const std::string& name){
	this->name = name;
}
void player::giveCard(const card& _card){
	cards = (card*)realloc(cards,++amCards*sizeof(card));
	cards[amCards-1] = _card;
	if(amCards>1) sort();
}
void player::giveCoins(const unsigned& amount){
	coins += amount;
}
void player::givePoints(const int& points){
	this->points = points;
}
unsigned player::getCoins(){
	return coins;
}
int player::getPoints(){
	return points;
}
card* player::getCards(){
	return cards;
}
unsigned player::getAmCards(){
	return amCards;
}
std::string player::getName(){
	return name;
}
unsigned player::takeCoins(const unsigned& amount){
	if(amount <= coins){
		coins -= amount;
		return amount;
	}
	return 0;
}
void player::sort(){
	//Пузырьковая сортировка по рангу карты
	for(size_t i = 1; i < amCards; i++){
		for(size_t j = amCards - 1; j >= i; j--){
			if(cards[j]._rank < cards[j - 1]._rank){
				card temp = cards[j - 1];
				cards[j - 1] = cards[j];
				cards[j] = temp;
			}
		}
	}
	//Пузырьковая сортировка по масти карты
	//for(size_t i = 1; i < amCards; i++){
	//	for(size_t j = amCards - 1; j >= i; j--){
	//		if(cards[j]._suit < cards[j - 1]._suit){
	//			card temp = cards[j - 1];
	//			cards[j - 1] = cards[j];
	//			cards[j] = temp;
	//		}
	//	}
	//}
}
player::~player(){
	if(cards) free(cards);
}
