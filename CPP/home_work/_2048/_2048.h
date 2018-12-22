#pragma once
#include <iostream>
#define SIZE 4

class _2048 {
	unsigned matrix[SIZE][SIZE];
	unsigned score;
	public:
	_2048();
	void get();
	unsigned gen_num();
	void random_num();
	unsigned cnt_num(unsigned);
	void init_ran_num();
	bool check_matrix();
	unsigned get_score();
	void up();
	void down();
	void left();
	void right();
};
