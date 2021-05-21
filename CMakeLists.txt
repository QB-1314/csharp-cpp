cmake_minimum_required(VERSION 3.19)
project(ab_test)

set(CMAKE_CXX_STANDARD 11)

add_executable(ab_test main.cpp
        include/abplus.h
        src/abplus.cpp)