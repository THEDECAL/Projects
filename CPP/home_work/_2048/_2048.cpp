#include "_2048.h"
#define MAX_NUM 4

_2048::_2048() {
	score=0;
	for(int col=0; col<SIZE; col++)
		for(int line=0; line<SIZE; line++)
			matrix[col][line]=0;
}
void _2048::init_ran_num() {
	for(int col=0; col<SIZE; col++)
		for(int line=0; line<SIZE; line++)
			matrix[col][line]=rand()%2048+1;
}
void _2048::get() {
	std::system("cls");
	std::cout<<(char)201<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)203;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)203<<(char)205;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)203<<(char)205<<(char)205;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)187<<"\n";
	for(int i=0; i<SIZE; i++) {
		for(int j=0; j<SIZE; j++) {
			if(j==0) std::cout<<(char)186;
			for(int k=0; k<MAX_NUM-cnt_num(matrix[i][j]); k++) std::cout<<' ';
			if(matrix[i][j])
				std::cout<<matrix[i][j]<<' ';
			else std::cout<<' ';
			std::cout<<(char)186;
		}
		std::cout<<"\n";
		if(i!=SIZE-1){
			std::cout<<(char)204<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)206;
			std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)206<<(char)205;
			std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)206<<(char)205<<(char)205;
			std::cout<<(char)205<<(char)205<<(char)205<<(char)185<<"\n";
		}
	}
	std::cout<<(char)200<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)202;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)202<<(char)205;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)202<<(char)205<<(char)205;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)188<<"\n";
}
unsigned _2048::gen_num() {
	if(rand()%100<90) return 2;
	else return 4;
}
unsigned _2048::cnt_num(unsigned number) {
	unsigned cnt=0;
	for(; number; number/=10) cnt++;

	return cnt;
}
bool _2048::check_matrix() {
	for(int i=0; i<SIZE; i++)
		for(int j=0; j<SIZE; j++)
			if(matrix[i][j]==0) return 1;
	return 0;
}
void _2048::random_num() {
	if(check_matrix()) {
		while(true) {
			unsigned x=rand()%SIZE;
			unsigned y=rand()%SIZE;
			if(matrix[x][y]==0) {
				matrix[x][y]=gen_num();
				break;
			}
		}
	}
}
unsigned _2048::get_score() {
	return score;
}
void _2048::up() {
	for(int i=0; i<SIZE-1; i++) {
		for(int col=0; col<SIZE; col++) {
			for(int line=1; line<SIZE; line++) {
				if(matrix[line-1][col]==0) {
					matrix[line-1][col]=matrix[line][col];
					matrix[line][col]=0;
				}
			}
		}
	}
	for(int col=0; col<SIZE; col++) {
		for(int line=1; line<SIZE; line++) {
			if(matrix[line-1][col]==matrix[line][col]) {
				matrix[line-1][col]+=matrix[line][col];
				matrix[line][col]=0;
				score+=matrix[line-1][col]+matrix[line][col];
			}
		}
	}
	for(int i=0; i<SIZE-1; i++) {
		for(int col=0; col<SIZE; col++) {
			for(int line=1; line<SIZE; line++) {
				if(matrix[line-1][col]==0) {
					matrix[line-1][col]=matrix[line][col];
					matrix[line][col]=0;
				}
			}
		}
	}
}
void _2048::down() {
	for(int i=0; i<SIZE-1; i++) {
		for(int col=0; col<SIZE; col++) {
			for(int line=SIZE-2; line>=0; line--) {
				if(matrix[line+1][col]==0) {
					matrix[line+1][col]=matrix[line][col];
					matrix[line][col]=0;
				}
			}
		}
	}
	for(int col=0; col<SIZE; col++) {
		for(int line=SIZE-2; line>=0; line--) {
			if(matrix[line+1][col]==matrix[line][col]) {
				matrix[line+1][col]+=matrix[line][col];
				matrix[line][col]=0;
				score+=matrix[line+1][col]+matrix[line][col];
			}
		}
	}
	for(int i=0; i<SIZE-1; i++) {
		for(int col=0; col<SIZE; col++) {
			for(int line=SIZE-2; line>=0; line--) {
				if(matrix[line+1][col]==0) {
					matrix[line+1][col]=matrix[line][col];
					matrix[line][col]=0;
				}
			}
		}
	}
}
void _2048::left() {
	for(int i=0; i<SIZE-1; i++) {
		for(int line=0; line<SIZE; line++) {
			for(int col=1; col<SIZE; col++) {
				if(matrix[line][col-1]==0) {
					matrix[line][col-1]=matrix[line][col];
					matrix[line][col]=0;
				}
			}
		}
	}
	for(int line=0; line<SIZE; line++) {
		for(int col=1; col<SIZE; col++) {
			if(matrix[line][col-1]==matrix[line][col]) {
				matrix[line][col-1]+=matrix[line][col];
				matrix[line][col]=0;
				score+=matrix[line][col-1]+matrix[line][col];
			}
		}
	}
	for(int i=0; i<SIZE-1; i++) {
		for(int line=0; line<SIZE; line++) {
			for(int col=1; col<SIZE; col++) {
				if(matrix[line][col-1]==0) {
					matrix[line][col-1]=matrix[line][col];
					matrix[line][col]=0;
				}
			}
		}
	}
}
void _2048::right() {
	for(int i=0; i<SIZE-1; i++) {
		for(int line=0; line<SIZE; line++) {
			for(int col=SIZE-2; col>=0; col--) {
				if(matrix[line][col+1]==0) {
					matrix[line][col+1]=matrix[line][col];
					matrix[line][col]=0;
				}
			}
		}
	}
	for(int line=0; line<SIZE; line++) {
		for(int col=SIZE-2; col>=0; col--) {
			if(matrix[line][col+1]==matrix[line][col]) {
				matrix[line][col+1]+=matrix[line][col];
				matrix[line][col]=0;
				score+=matrix[line][col+1]+matrix[line][col];
			}
		}
	}
	for(int i=0; i<SIZE-1; i++) {
		for(int line=0; line<SIZE; line++) {
			for(int col=SIZE-2; col>=0; col--) {
				if(matrix[line][col+1]==0) {
					matrix[line][col+1]=matrix[line][col];
					matrix[line][col]=0;
				}
			}
		}
	}
}
