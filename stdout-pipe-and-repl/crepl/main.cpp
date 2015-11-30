#include <Windows.h>
#include <iostream>
#include <string>

int wmain(int argc, const wchar_t** argv) {
    std::cout << "prompt>" << std::flush;

    char buf[3000];
    std::cin.getline(buf, 3000);

    std::cout << "echo " << buf << std::endl;
}
