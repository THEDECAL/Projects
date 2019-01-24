#include "game.h"
#define START_RATE 20 //��������� ������
#define START_COINS 100 //��������� �������
#define DISTRIBUTION 5 //���������� ����������� ����

game::game(const unsigned& maxAmPlayers,const string& name):maxAmPlayers(maxAmPlayers){
	GameOver = false;
	cntGames = 1;
	players = new player[maxAmPlayers];
	for(size_t i = 0; i < maxAmPlayers; i++){
		string playerName = "Player #"; //��������� ���
		playerName += std::to_string(i+1); //��������� ���������� �����
		players[i].setName(playerName); //���������� ����� ����������� �������
		players[i].giveCoins(START_COINS); //���� ��������� �������
	}
	players[0].setName(name); //���������� ��� ��������� ������
	init();
}
void game::init(){
	string newGameText = "Game #";
	newGameText += std::to_string(cntGames);
	messages.push_back(newGameText);

	unsigned amPlayersOut = 0;
	for(size_t i = 0; i < maxAmPlayers; i++){
		if(players[i].getEndGame()) continue;

		unsigned startRate = players[i].takeCoins(START_RATE);
		string text = players[i].getName();
		if(startRate){ //���� ���������� �����
			bank += startRate; //����� c ������� ��������� ������ � �������� � ����
			text += "\t makes a starting bet ";
			text += std::to_string(START_RATE);
			text += " coins.";
			messages.push_back(text);

			for(size_t j = 0; j < DISTRIBUTION; j++){
				if(_deck.getCurrentCards()) //�������� ������� ���� � ������
					players[i].giveCard(_deck.getCard()); //����� � ������ ����� � ���� ������
				else break;
			}
			players[i].givePoints(getCombo(i)); //���� ���� �� ����������
		}
		else{ //���� �� ���������� �����
			players[i].endGame();
			text += "\t out. Bankrupt.";
			amPlayersOut++;
			//���� �������� ����� ��������, ��������� ��� ����
			if (!i){
				checkWinners();
				show(false);
				GameOver = true;

				return;
			}
		}
	}
	if(amPlayersOut == maxAmPlayers - 1) GameOver = true;
}
void game::newGame(){
	messages.clear();
	_deck.init();
	cntGames++;

	for(size_t i = 0; i < maxAmPlayers; i++)
		players[i].newGame();

	init();
}
void game::show(const bool& hide){
	if(GameOver){ cout << "\nGame Over (One player left).\n"; return; }

	cout << (char)218 << "Messages:" << (char)191 <<endl;
	for(auto i : messages) std::cout << i << '\n'; //�������� ���������
	cout << endl;

	cout << "Coins on the table: " << bank << "\n\n";

	for(size_t i = 0; i < maxAmPlayers; i++){
		if(!players[i].getEndGame()){ //���� ����� �� ����� ��������
			cout << (char)218 << players[i].getName() << (char)191;
			cout << "\t\t" << (char)218 << "Coins: " << players[i].getCoins() << (char)191 << '\n';
			deck::ShowCard((hide)?i:hide,players[i].getCards(),players[i].getAmCards()); //�������� �����
			if(i == 0 || !hide) cout << (char)192 << "Combo: " << showCombo(i) << (char)217 << endl; //�������� ����������
		}
	}
}
int game::getCombo(const unsigned& player){
	card *cards=players[player].getCards();
	unsigned SuitCoinc[SUIT_AMOUNT] = {};
	unsigned RankCoinc[RANK_AMOUNT] = {};

	//������� ������ � ������ ����
	for(size_t i = 0; i < DISTRIBUTION; i++){
		++SuitCoinc[cards[i]._suit-HEARTS];
		++RankCoinc[cards[i]._rank-TWO];
	}

	//�������� �� ����
	for(auto i : SuitCoinc){
		if(i == 5){
			if(cards[0]._rank == TEN){ return ROYAL_FLUSH; } //Royal Flush
			if(cards[0]._rank == cards[DISTRIBUTION - 1]._rank - 4){
				return STRAIGHT_FLUSH; //Straight Flush
			}
			return FLUSH; //Flush
		}
	}
	//�������� �� ����
	for(auto i : RankCoinc){ if(i == 4) return FOUR_OF_A_KIND; }
	//�������� �� �����
	unsigned straight = 0;
	for(size_t i = 0; i < DISTRIBUTION-1; i++){
		if(cards[i]._rank == cards[i + 1]._rank-1) straight++;
		else straight = 0;
		if(straight == 4) return STRAIGHT;
	}
	//�������� �� ������ ����������
	unsigned amPairs = 0;
	for(auto i : RankCoinc){ if(i == 3) amPairs++; }
	if(amPairs == 1){
		for(auto i : RankCoinc){ if(i == 2) amPairs++; }
		if(amPairs == 2) return FULL_HOUSE; //Full House
		else return THREE_OF_A_KIND; //Three of a Kind
	}

	amPairs = 0;
	for(auto i : RankCoinc){ if(i == 2) amPairs++; }
	if(amPairs == 1) return ONE_PAIR; //One pair
	if(amPairs == 2) return TWO_PAIRS; //Two pair

	return -cards[DISTRIBUTION-1]._rank; //���� ���������� ���, ������� ����� ����� (� ������������� ��������)
}
string game::showCombo(const unsigned& player){
	int combo = players[player].getPoints();
	if(combo > 0) return messCombo[combo-1];
	else return messCombo[HIGH_CARD-1];
}
void game::placeBet(){
	unsigned placeBet = 0;

	//������ ��������� ������
	while(true){
		cout << "Please enter your place bet: ";
		cin >> placeBet;

		if(placeBet <= players[0].getCoins()){
			bank += players[0].takeCoins(placeBet);
			string text = players[0].getName();
			text += "\t made a bet ";
			text += std::to_string(placeBet);
			text += " coins.";

			messages.push_back(text);
			break;
		}
		else if(placeBet > players[0].getCoins()){
			cout << "You don`t have enough coins.\n";
		}
		else throw "Invalid place bet";
	}
	//������ ����������� �������
	for(size_t i = 1; i < maxAmPlayers; i++){
		string text = players[0].getName();

		if(!players[i].getCoins()) text += " pass.";
		else{
			unsigned chance = rand() % 100;
			if(chance > 50 && chance < 100) //50% ����������� ��������� ��������
				placeBet = players[i].getCoins() / 2;
			else if(chance >= 0 && chance < 25)
				placeBet = players[i].getCoins(); //25% ����������� ��������� ��
			else
				placeBet = players[i].getCoins() / 100 * 10; //25% ����������� ��������� 10%

			bank += players[i].takeCoins(placeBet);
			text += "\t made a bet ";
			text += std::to_string(placeBet);
			text += " coins.";
		}

		messages.push_back(text);
	}
}
void game::checkWinners(){
	//���� ������������ ����������
	int maxCombo = players[0].getPoints();
	for(size_t i = 0; i < maxAmPlayers; i++){
		int currCombo = players[i].getPoints();
		if(maxCombo < currCombo ) maxCombo = currCombo;
	}
	//���� ���������� ��� (������ �����)
	if(maxCombo < 0){
		maxCombo = players[0].getPoints();
		for(size_t i = 0; i < maxAmPlayers; i++){
			int currCombo = players[i].getPoints();
			if(maxCombo > currCombo) maxCombo = currCombo;
		}
	}

	//�������� ����������� � ������� �� � ������
	vector<unsigned> winners;
	for(size_t i = 0; i < maxAmPlayers; i++){
		if(players[i].getPoints() == maxCombo)
			winners.push_back(i);
	}
	if(winners.size() == 0) throw "No winners";

	//����� ������� �� ����������� � ������ ���������
	unsigned sizeWin = bank / winners.size();
	bank = 0;
	auto it = winners.begin();
	while(it!=winners.end()){
		players[*it].giveCoins(sizeWin);
		string text = players[*it].getName();
		text += "\t winner! (";
		text += showCombo(*it);
		if(maxCombo < 0){
			text += "(";
			text += deck::getCardName(abs(maxCombo));
			text += ")";
		}
		text += ")";
		text += " the winning is ";
		text += std::to_string(sizeWin);
		text += " coins.";
		messages.push_back(text);
		it++;
	}
}
bool game::debug(){
	for(size_t i = 0; i < maxAmPlayers; i++){
		cout << showCombo(i) << endl;
		_deck.ShowCard(false,players[i].getCards(),DISTRIBUTION);
		//unsigned combo = players[i].getPoints();
		//for(size_t j = 1; j <= HIGH_CARD; j++){
		//	if(combo == j){
		//		_deck.ShowCard(false,players[i].getCards(),DISTRIBUTION);
		//		cout << messCombo[combo - 1] << endl;
		//		system("pause");
		//		return 1;
		//	}
		//}
	}
	checkWinners();
	for(auto i : messages) std::cout << i << '\n';
	system("pause");
	return 1;
}
game::~game(){
	delete[]players;
}
