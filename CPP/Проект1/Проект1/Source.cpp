#include <stdio.h>
#include <stdlib.h>
int main(){
	extern char** environ;
	int i = 0;
	while(environ[i]){
		printf("%s\n",environ[i++]);
	}

	system("pause");
	return 0;
}
