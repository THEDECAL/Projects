#pragma once
#include <iostream>
#include <string>
using namespace std;

class vehicle{
	string name; //Имя
	string color; //Цвет
	double velocity; //Скорость (км/ч)
	unsigned capacity; //Вместимость (человек)
	unsigned carrying; //Грузоподъёмность (кг)
	double fuelConsumption; //Расход топлива (л\100км)
public:
	vehicle(const string&,const string&,const double&,const unsigned&,const unsigned&,const double&);
	double getfuelConsumption();
	string getName();
	void show();
};
