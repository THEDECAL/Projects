#include <iostream>

enum MENU{
	NEW_GAME,
	SLCT_NAME,
	SLCT_PLAYERS,
	EXIT
};
const std::string menu[] = {
	"Start new game",
	"Selecting a name",
	"Selecting the number of players",
	"Exit"
};
enum SUBMENU{
	PLACE_BET,
	SHOW_CARDS,
	CONTINUE,
	END_GAME
};
const std::string submenu[] = {
	"Place bet",
	"Show cards",
	"Continue (show cards first)",
	"End current game"
};
