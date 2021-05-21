//
// Created by km on 5/11/21.
//

#include "../include/abplus.h"
#include <fstream>
#include <iostream>
abplus::abplus() = default;
abplus::~abplus() {}

void abplus::setFile(const std::string &filename) {
  this->filename = filename;
}

void abplus::calculate() {
  this->value += 1;
}
void abplus::getData() {
  std::ifstream ifs;
  ifs.open(this->filename, std::ios::in );

  if(ifs.fail()) {
    std::cout << "fail";
    return;
  }

  int fileSize = 0;
  ifs.seekg(0, std::ios_base::end);
  fileSize = (int)ifs.tellg();
  ifs.seekg(0, std::ios_base::beg);

  std::cout << "file: " << this->filename << ", size: " << fileSize << std::endl;

  ifs.close();

}
