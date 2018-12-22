#include <iostream>
#include <time.h>
using namespace std;

class point{
	double x;
	double y;
public:
	point(){ //ѕо умолчанию генерировать произвольную точку
		const int start=-25;
		const int end=25;
		set(rand()%end*2-abs(start),rand()%end*2-abs(start));
	}
	void set(const double& x,const double& y){
		this->x=x;
		this->y=y;
	}
	void show(){
		cout<<"x("<<x<<"), y("<<y<<")\n";
	}
};

class figure{
	point* _figure;
	unsigned cntPoints;
public:
	figure(){ //ѕо умолчанию генерировать произвольное количество точек в фигуре
		const unsigned start=10;
		const unsigned end=20;
		this->cntPoints=start+rand()%(end-start+1);
		this->_figure=new point[cntPoints];
	}
	figure(const point* points,const unsigned& cntPoints){
		set(points,cntPoints);
	}
	void set(const point* points,const unsigned& cntPoints){
		this->cntPoints=cntPoints;
		_figure=new point[cntPoints];

		for(int i=0; i<cntPoints; i++)
			_figure[i]=points[i];
	}
	void show(){
		for(int i=0; i<cntPoints; i++)
			_figure[i].show();
		cout<<endl;
	}
	~figure(){
		if(_figure)
			delete _figure;
	}
};

class composition{
	figure* _composition;
	unsigned cntFigures;
public:
	composition(){ //ѕо умолчанию генерировать произвольное количество фигур в композиции
		const unsigned start=2;
		const unsigned end=10;
		this->cntFigures=start+rand()%(end-start+1);
		this->_composition=new figure[cntFigures];
	}
	composition(const figure* figures,const unsigned& cntFigures){
		set(figures,cntFigures);
	}
	void set(const figure* figures,const unsigned& cntFigures){
		this->cntFigures=cntFigures;
		_composition=new figure[cntFigures];

		for(int i=0; i<cntFigures; i++)
			_composition[i]=figures[i];
	}
	void show(){
		for(int i=0; i<cntFigures;i++){
			cout<<"Figure #"<<i+1<<endl;
			_composition[i].show();
		}
	}
};

void main(){
	srand(time(0));

	composition obj;
	obj.show();

	system("pause");
}
