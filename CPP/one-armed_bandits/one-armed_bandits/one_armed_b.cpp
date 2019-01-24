#include "one_armed_b.h"

void one_armed_b::rotation_barrel() {
	for(int i=0; i<CNT_BARRELS; i++) {
		unsigned speedRotation=rand()%10+1;
		for(int j=0; j<speedRotation; j++) {
			short tmp=barrels[i][0];
			for(int k=1; k<CNT_SIGNS; k++)
				barrels[i][k-1]=barrels[i][k];
			barrels[i][CNT_SIGNS-1]=tmp;
		}
	}
}
void one_armed_b::get() {
	std::cout<<"\t"<<(char)201<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)203;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)203<<(char)205;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)187<<"\n";
	for(int j=0; j<CNT_SHOW_LINE_BARRELS; j++) {
		std::cout<<"\t|";
		for(int i=0; i<CNT_BARRELS; i++) {
			std::cout<<"  "<<barrels[i][j]<<"  ";
			std::cout<<'|';
		}
		std::cout<<"\n";
	}
	std::cout<<"\t"<<(char)200<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)202;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)205<<(char)202<<(char)205;
	std::cout<<(char)205<<(char)205<<(char)205<<(char)205<<(char)188<<"\n";
}
unsigned one_armed_b::get_score() {
	return score;
}
void one_armed_b::add_score() {
	unsigned sign=0;
	unsigned cntOverlap=0;
	if(barrels[0][1]==barrels[2][1]) {
		sign=barrels[0][1];
		cntOverlap++;
	}
	for(int i=1; i<CNT_BARRELS; i++) {
		if(barrels[i][1]==barrels[i-1][1]) {
			sign=barrels[i][1];
			cntOverlap++;
		}
	}
	switch(sign) {
		case 0: { break; }
		case seven: { score+=100000*cntOverlap; break; }
		case star: { score+=10000*cntOverlap; break; }
		case dollar: { score+=1000*cntOverlap; break; }
		case grid: { score+=100*cntOverlap; break; }
		case at: { score+=10*cntOverlap; break; }
	}
}