#!/bin/sh

[ ! -d "bin" ] && mkdir bin
cc main.c -o bin/unametest
./bin/unametest
