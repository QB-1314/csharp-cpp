#include <iostream>
#include <string>

#include "abplus.h"

int main(int a, char * arg[]) {
	std::cout << "Hello, World! int: " << a << ";char **: " << arg << std::endl;
	abplus* ab = new class abplus();
	std::string dd(arg[1]);
	ab->setFile(dd);
	ab->getData();
	ab->calculate();

	delete ab;
	return 0;
}
