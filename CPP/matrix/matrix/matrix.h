#pragma once
class matrix{
	int width;
	int height;
	int **Matrix;
	public:
	matrix();
	matrix(const int&,const int&);
	matrix(const matrix&);
	void set(const int&,const int&);
	void get();
	bool matrix_check(const matrix&);
	matrix& operator=(const matrix&);
	matrix operator+(const matrix&);
	~matrix();
};
