#include <iostream>

int main()
{
	char toPrint[] = "  \0";
	int cols = 0, rows = 0;

	std::cin >> cols >> rows;

	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			if (j == 0 || i == 0 || i == rows - 1 || j == cols - 1)
				toPrint[0] = '*';
			else
				toPrint[0] = ' ';

			std::cout << toPrint;
		}
		std::cout << '\n';
	}
}