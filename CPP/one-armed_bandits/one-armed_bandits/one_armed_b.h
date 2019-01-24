#pragma once
#include <iostream>
#define CNT_BARRELS 3
#define CNT_SIGNS 5
#define CNT_SHOW_LINE_BARRELS 3

class one_armed_b {
	enum { seven=55,star=42,dollar=36,grid=35,at=64 };
	char barrels[CNT_BARRELS][CNT_SIGNS]={
		{seven,star,dollar,grid,at},
		{seven,star,dollar,grid,at},
		{seven,star,dollar,grid,at}
	};
	unsigned score=0;
	public:
	one_armed_b() {};
	void rotation_barrel();
	void get();
	unsigned get_score();
	void add_score();
};