#include "grains.h"
#include "math.h"

#define NUMBER_OF_SQUARES 64

uint64_t square(uint8_t index) {
  if(index == 0 || index > NUMBER_OF_SQUARES) {
    return 0;
  }
  uint8_t grainsExponent = index - 1;

  return (uint64_t) pow(2.0, (double) grainsExponent);
}

uint64_t total(void) {
  uint64_t i;
  uint64_t acc = 0;
  for(i = 1; i <= NUMBER_OF_SQUARES; i++) {
    acc += square(i);
  }

  return acc;
}