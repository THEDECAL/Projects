#pragma once
#include <iostream>
#include <string>
using namespace std;

class vehicle{
	string name; //���
	string color; //����
	double velocity; //�������� (��/�)
	unsigned capacity; //����������� (�������)
	unsigned carrying; //���������������� (��)
	double fuelConsumption; //������ ������� (�\100��)
public:
	vehicle(const string&,const string&,const double&,const unsigned&,const unsigned&,const double&);
	double getfuelConsumption();
	string getName();
	void show();
};
