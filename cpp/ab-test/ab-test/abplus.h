//
// Created by km on 5/11/21.
//


#ifndef AB_TEST_ABPLUS_H
#define AB_TEST_ABPLUS_H

#include <string>
class abplus {
public:
	abplus();
	~abplus();

	void setFile(const std::string& filename);
	void getData();
	void calculate();

private:
	std::string filename;
	int value = 0;
	int index = 0;

};


#endif //AB_TEST_ABPLUS_H
