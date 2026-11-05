#include "resistor_color.h"

int color_code(resistor_band_t colorIdentifier) {
  return (int) colorIdentifier;
}

resistor_band_t* colors() {
  static resistor_band_t s[] = { BLACK, BROWN, RED, ORANGE, YELLOW, GREEN, BLUE, VIOLET, GREY, WHITE };
  
  return s;
}