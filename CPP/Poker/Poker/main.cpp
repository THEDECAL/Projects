#include <time.h>
#include <conio.h>
#include <windows.h>
#include "game.h"
#include "menu.cpp"

enum KEYS{
	ENTER = 13,
	S = 83,
	W = 87,
	s = 115,
	w = 119
};

void main(){
	try{
		srand(time(NULL));

		const unsigned sizeName = 16;
		char name[sizeName] = "Real Player";
		name[sizeName - 1] = '\0';
		const unsigned maxAmPlayers = 10;
		unsigned players = 2;
		char select = 0;
		int arrow = 0;
		do{
			system("cls");
			if(arrow < 0) arrow = EXIT;
			else if(arrow > EXIT) arrow = NEW_GAME;

			std::cout << "\t\t\t<--P-O-K-E-R-->\n";
			for(size_t i = 0; i <= EXIT; i++){
				printf((arrow == i)?"->":"  ");
				std::cout << menu[i] << '\n';
			}
			printf("\n  W/w - UP, S/s - DOWN\n");
			select = _getch();

			if(select == w || select == W) arrow--;
			else if(select == s || select == S) arrow++;
			else if(select == ENTER){
				switch(arrow){
					case NEW_GAME:{
						int select = -1;
						bool isShowCards = false;
						game _game(players,name);

						do{
							system("cls");
							for(size_t i = PLACE_BET; i <= END_GAME; i++)
								std::cout << i << ". " << submenu[i] << '\n';

							switch(select){
								case PLACE_BET:{
									_game.show();
									_game.placeBet();
									break;
								}
								case SHOW_CARDS:{
									isShowCards = true;
									_game.checkWinners();
									_game.show(false);

									break;
								}
								case CONTINUE:{
									if(isShowCards){
										_game.newGame();
										isShowCards = false;
									}
									_game.show();
									
									break;
								}
								default: _game.show();
							}

							select = _getch()-48; //т.к. getch возвращает char вычитаем 48, для преобразования в int

						} while(select!=END_GAME);
						break;
					}
					case SLCT_NAME:{
						char temp[sizeName];
						std::cout << "Please enter your name (" << sizeName - 1 << " symbols): ";
						std::cin >> temp;
						strcmp(name,temp);
						break;
					}
					case SLCT_PLAYERS:{
						do{
							std::cout << "Please enter amount players (2-" << maxAmPlayers << " players): ";
							std::cin >> players;
						} while(players < 2 || players > maxAmPlayers);
						break;
					}
					case EXIT: return;
				}
			}
			else if(select == '0'){
				while(true){
					srand(time(NULL));
					game _game(10,name);
					if(_game.debug()) break;
				}
			}
		} while(true);
	}
	catch(const char* message){
		std::cout << "Error." << message << ".\n";
		system("pause");
	}
	catch(...){
		std::cout << "\tUnexpected Error\n";
		system("pause");
	}
}
