#include "difference_of_squares.h"

unsigned int difference_of_squares(unsigned int number) {
  unsigned int a = square_of_sum(number);
  unsigned int b = sum_of_squares(number);

  return a - b;
}

unsigned int square_of_sum(unsigned int number) {
  unsigned int i;
  unsigned int sum = 0;

  if(number == 0) {
    return 0;
  }

  for(i = 1; i <= number; i++) {
    sum += i;
  }

  return sum*sum;
}

unsigned int sum_of_squares(unsigned int number) {
  unsigned int i;
  unsigned int sum = 0;

  if(number == 0) {
    return 0;
  }

  for(i = 1; i <= number; i++) {
    sum += i*i;
  }

  return sum;
}
