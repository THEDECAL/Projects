#include <iostream>
#include <time.h>
#include <conio.h>
#include "player.h"

int main(){
	srand(time(0));

	player _player;
	player croupier(true);
	croupier.set_name("Croupier");

	int select=-1;
	do{
		std::system("cls");
		std::cout<<"<--BlackJack-->\n";
		std::cout<<"Menu:\n";
		std::cout<<"1. Start the game\n";
		std::cout<<"2. Set a name player\n";
		std::cout<<"0. Exit\n";
		std::cin>>select;
		switch(select){
			case 1:{
				std::system("cls");
				int _player_total_score=0;
				int croupier_total_score=0;
				bool end_cycle=false;
				for(int i=0;!end_cycle; i++){
					std::system("cls");
					std::cout<<"<--BlackJack-->\n";
					std::cout<<"Menu:\n";
					std::cout<<"1. Get a card\n";
					std::cout<<"0. Show cards\n";
					if(i) {
						std::cout<<"Total number of player wins: "<<_player_total_score<<"\n\n";
						_player.get();
						std::cout<<"Total number of croupier wins: "<<croupier_total_score<<"\n\n";
						croupier.get(true);
					}
					std::cin>>select;
					switch(select){
						case 1:{
							if(i){
								_player.add_card(croupier.issue_card());
								croupier.add_card(croupier.issue_card());
							}
							else{
								_player.add_card(croupier.issue_card());
								_player.add_card(croupier.issue_card());
								croupier.add_card(croupier.issue_card());
								croupier.add_card(croupier.issue_card());
							}
							break;
						}
						case 0:{
							do{
								std::system("cls");
								std::cout<<"<--BlackJack-->\n";
								std::cout<<"Menu:\n";
								std::cout<<"1. Continue the game\n";
								std::cout<<"0. End the game\n";
								if(_player.get_score()==21&&croupier.get_score()<21||croupier.get_score()>21){
									std::cout<<_player.get_name()<<" a win!\n";
									_player_total_score++;
								}
								else if(croupier.get_score()==21&&_player.get_score()<21||_player.get_score()>21){
									std::cout<<croupier.get_name()<<" a win!\n";
									croupier_total_score++;
								}
								else if(_player.get_score()<21&&croupier.get_score()>21){
									std::cout<<_player.get_name()<<" a win!\n";
									_player_total_score++;
								}
								else if(croupier.get_score()<21&&_player.get_score()>21){
									std::cout<<croupier.get_name()<<" a win!\n";
									croupier_total_score++;
								}
								else if(_player.get_score()>croupier.get_score()){
									std::cout<<_player.get_name()<<" a win!\n";
									_player_total_score++;
								}
								else if(croupier.get_score()>_player.get_score()){
									std::cout<<croupier.get_name()<<" a win!\n";
									croupier_total_score++;
								}
								else std::cout<<"Stay!\n";
								std::cout<<"Total number of player wins: "<<_player_total_score<<"\n\n";
								_player.get();
								std::cout<<"Total number of croupier wins: "<<croupier_total_score<<"\n\n";
								croupier.get();
								std::cin>>select;
								switch(select){
									case 1:{
										_player.clear();
										croupier.clear();
										i=0;
										continue;
									}
								}
							} while(select);
							end_cycle=true;
							break;
						}
					}
				}
				select=-1;
				break;
			}
			case 2:{
				char tmp[SIZE_NAME];
				std::cout<<"Please enter a name player ("<<SIZE_NAME-1<<" symbols): ";
				std::cin>>tmp;
				_player.set_name(tmp);
				break;
			}
		}
	}while(select);

	return 0;
}
