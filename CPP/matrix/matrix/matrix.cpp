#include <iostream>
#include "matrix.h"
matrix::matrix(){
	width=0;
	height=0;
	Matrix=NULL;
}
matrix::matrix(const int& w,const int& h){
	set(w,h);
}
matrix::matrix(const matrix& o){
	set(o.width,o.height);
	for(int i=0; i<this->height; i++){
		for(int j=0; j<this->width; j++){
			this->Matrix[i][j]=o.Matrix[i][j];
		}
	}
}
void matrix::set(const int& w,const int& h){
	width=abs(w);
	height=abs(h);
	Matrix=new int*[height];
	for(int i=0; i<height; i++)
		Matrix[i]=new int[width];

	for(int i=0; i<height; i++)
		for(int j=0; j<width; j++)
			Matrix[i][j]=rand()%4;
}
void matrix::get(){
	for(int i=0; i<height; i++){
		for(int j=0; j<width; j++)
			std::cout<<Matrix[i][j]<<" ";
		std::cout<<"\n";
	}
}
bool matrix::matrix_check(const matrix& o){
	if(width==o.width && height==o.height) return 1;
	return 0;
}
matrix& matrix::operator=(const matrix& o){
	if(Matrix){
		for(int i=0; i<height; i++)
			delete[]Matrix[i];
		delete[]Matrix;
	}
	set(o.width,o.height);
	for(int i=0; i<this->height; i++){
		for(int j=0; j<this->width; j++){
			this->Matrix[i][j]=o.Matrix[i][j];
		}
	}

	return *this;
}
matrix matrix::operator+(const matrix& o){
	if(matrix_check(o)){
		matrix temp(o);
		for(int i=0; i<height;i++){
			for(int j=0; j<width;j++){
				temp.Matrix[i][j]+=Matrix[i][j];
			}
		}
		return temp;
	}
	return o;
}
matrix::~matrix(){
	if(Matrix){
		for(int i=0; i<height; i++)
			delete[]Matrix[i];
		delete[]Matrix;
	}
}
