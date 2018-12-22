#include "card.h"
#include "utility.h"

card::card(const card& o){
	this->_name=o._name;
	this->_suit=o._suit;
}
void card::set(const int &_name,const int &_suit){
	this->_name=(name)_name;
	this->_suit=(suit)_suit;
}
void card::get(const bool& hide){
	char tmp;
	switch(_name) {
		case jocker: tmp='J'; break;
		case jack: tmp='J'; break;
		case queen: tmp='Q'; break;
		case king: tmp='K'; break;
		case ace: tmp='A'; break;
	};
	std::cout<<(char)218<<(char)196<<(char)196<<(char)196<<(char)196<<(char)196;
	std::cout<<(char)196<<(char)196<<(char)196<<(char)196<<(char)191<<"\n";
	if(hide){
		std::cout<<(char)179<<" +++++++ "<<(char)179<<"\n";
		std::cout<<(char)179<<" +-----+ "<<(char)179<<"\n";
		std::cout<<(char)179<<" +-----+ "<<(char)179<<"\n";
		std::cout<<(char)179<<" +-----+ "<<(char)179<<"\n";
		std::cout<<(char)179<<" +-----+ "<<(char)179<<"\n";
		std::cout<<(char)179<<" +-----+ "<<(char)179<<"\n";
		std::cout<<(char)179<<" +++++++ "<<(char)179<<"\n";
	}
	else{
		if(_name==card10) std::cout<<(char)179<<" "<<(char)_suit<<_name<<"     "<<(char)179<<"\n";
		else if(_name<card10) std::cout<<(char)179<<" "<<(char)_suit<<_name<<"      "<<(char)179<<"\n";
		else std::cout<<(char)179<<" "<<(char)_suit<<tmp<<"      "<<(char)179<<"\n";
		std::cout<<(char)179<<"         "<<(char)179<<"\n";
		std::cout<<(char)179<<"         "<<(char)179<<"\n";
		std::cout<<(char)179<<"    "<<(char)_suit<<"    "<<(char)179<<"\n";
		std::cout<<(char)179<<"         "<<(char)179<<"\n";
		std::cout<<(char)179<<"         "<<(char)179<<"\n";
		if(_name==card10) std::cout<<(char)179<<"     "<<_name<<(char)_suit<<" "<<(char)179<<"\n";
		else if(_name<card10) std::cout<<(char)179<<"      "<<_name<<(char)_suit<<" "<<(char)179<<"\n";
		else std::cout<<(char)179<<"      "<<tmp<<(char)_suit<<" "<<(char)179<<"\n";
	}
	std::cout<<(char)192<<(char)196<<(char)196<<(char)196<<(char)196<<(char)196;
	std::cout<<(char)196<<(char)196<<(char)196<<(char)196<<(char)217<<"\n";
}
int card::get_value()const{
	if(_name==ace) return 11;
	else if(_name>card9) return 10;
	else return _name;
}
card& card::operator=(const card& o){
	this->_name=o._name;
	this->_suit=o._suit;

	return *this;
}
