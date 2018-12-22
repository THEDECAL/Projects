#pragma once
#include <iostream>
#include "suit_name.h"

class card{
	suit _suit;
	name _name;
public:
	card(const int& =0,const int& =0){ set(_name,_suit); };
	card(const card&);
	card& operator=(const card&);
	void set(const int&,const int&);
	void get(const bool& =false);
	int get_value()const;
};
