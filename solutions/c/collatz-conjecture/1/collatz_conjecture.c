#include "collatz_conjecture.h"

int steps(int start) {
  int steps = 0;
  int idx = start;
  if(start <= 0) {
    return ERROR_VALUE;
  }

  while(idx != 1) {
    if(idx % 2 == 0) {
      idx /= 2;
    } else {
      idx = idx * 3 + 1;
    }
    steps++;
  }

  return steps;
}