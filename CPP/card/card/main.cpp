#include <iostream>
using namespace std;

const enum figures{
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
	FIGURES_SIZE=ACE
};
const enum suits{
	BLACK=1,
	WHITE,
	HEARTS,
	DIAMONDS,
	SPADES,
	CLUBS,
	SUITS_SIZE=CLUBS
};
struct card{
	suits suit;
	figures figure;
};

void show(const card& _card){
	cout<<_card.figure<<(char)_card.suit<<endl;
}
void show(const card* _cards,const unsigned& amount){
	const unsigned height=7;
	const unsigned width=7;
	for(size_t i=0; i<height; i++){
		for(size_t j=0; j<amount; j++){
			const char zero=48;
			char suit=_cards[j].suit;
			unsigned figure=_cards[j].figure;
			
			if(figure>TEN){
				if(figure==JACK) figure='J';
				else if(figure==QUEEN) figure='Q';
				else if(figure==KING) figure='K';
				else if(figure==ACE) figure='A';
			}
			else if(figure==JOCKER) figure=_cards[j].suit;
			else figure=zero+_cards[j].figure;
			//char CARD[height][width+2]={
			//	{201,205,205,205,205,205,187,' ','\0'},
			//	{186,figure,' ',' ',' ',' ',186,' ','\0'},
			//	{186,' ',' ',' ',' ',' ',186,' ','\0'},
			//	{186,' ',' ',suit,' ',' ',186,' ','\0'},
			//	{186,' ',' ',' ',' ',' ',186,' ','\0'},
			//	{186,' ',' ',' ',' ',figure,186,' ','\0'},
			//	{200,205,205,205,205,205,188,' ','\0'}
			//};
			//cout<<CARD[i];
			printf("%c%@10c%c",201,205,187);
		}
		cout<<endl;
	}
}

void main(){
	const unsigned AmountCards=54;
	card deck[AmountCards];

	for(size_t i=0,s=HEARTS; i<(AmountCards-2); i+=(FIGURES_SIZE-1),s++){
		for(size_t j=0,f=TWO; j<(FIGURES_SIZE-1); j++,f++){
			deck[j+i].suit=(suits)s;
			deck[j+i].figure=(figures)f;
			//show(deck[j+i]);
		}
	}

	show(deck,3);

	system("pause");
}