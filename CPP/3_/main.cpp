#include <iostream>
using namespace std;

class point{
	double x;
	double y;
public:
	point(const double& x=0.0,const double& y=0.0){
		set(x,y);
	}
	void set(const double& x=0.0,const double& y=0.0){
		this->x=x;
		this->y=y;
	}
	void show(){
		cout<<"X("<<x<<") Y("<<y<<")"<<endl;
	}
};

class circle{
	point *_circle;
	unsigned cntPoints;
public:
	circle(const unsigned& radius){ //Принимает радиус окружности
		//Сдесь должен быть код генерации точек окружности
	}
	unsigned get_cntPoints(){
		return cntPoints;
	}
	void show(){
		for(int i=0; i<cntPoints; i++)
			_circle[i].show();
	}
	~circle(){
		if(_circle)
			delete[cntPoints]_circle;
	}
};

class square{
	point *_square;
	unsigned cntPoints; 
public:
	square(const unsigned& diagonal){ //Принимает диагональ квадрата
		//Сдесь должен быть код генерации точек квадрата
		//this->cntPoints=diagonal*4;
		//_square=new point[this->cntPoints];

		//unsigned cntPoints=0;
		//double x=diagonal/2;
		//double y=0;
		//do{
		//	_square[cntPoints].set(x,y);
		//	if(y<x) y++;
		//	else if(y>=x) x--;
		//	else if(y>=abs(x)) y--;

		//	cntPoints++;
		//}while(cntPoints!=this->cntPoints);
	}
	unsigned get_cntPoints(){
		return cntPoints;
	}
	void show(){
		for(int i=0; i<cntPoints; i++)
			_square[i].show();
	}
	~square(){
		if(_square)
			delete[cntPoints]_square;
	}
};

class circleInSquare:public circle,public square{
public:
	circleInSquare(const unsigned& radius):circle(radius),square(radius*2){} //Принимает радиус вписанной окружности
	void show(){
		circle::show();
		square::show();
	}
};

void main(){
	circleInSquare obj(10);
	obj.show();

	system("pause");
}
