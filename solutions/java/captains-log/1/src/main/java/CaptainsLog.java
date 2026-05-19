import java.util.Random;

class CaptainsLog {

    private static final char[] PLANET_CLASSES = new char[]{'D', 'H', 'J', 'K', 'L', 'M', 'N', 'R', 'T', 'Y'};

    private Random random;

    CaptainsLog(Random random) {
        this.random = random;
    }

    char randomPlanetClass() {
        int randomIndex = random.nextInt(PLANET_CLASSES.length);

        return PLANET_CLASSES[randomIndex];
    }

    String randomShipRegistryNumber() {
        final int REGISTRY_NUMBER_LOWER_BOUND = 1000;
        final int REGISTRY_NUMBER_UPPER_BOUND = 10000 - REGISTRY_NUMBER_LOWER_BOUND;

        return "NCC-" + String.valueOf(REGISTRY_NUMBER_LOWER_BOUND + random.nextInt(REGISTRY_NUMBER_UPPER_BOUND));
    }

    double randomStardate() {
        final double STARDATE_NUMBER_LOWER_BOUND = 41000.0;
        final double STARDATE_SCALE = 1000.0;

        return STARDATE_NUMBER_LOWER_BOUND + STARDATE_SCALE * random.nextDouble();
    }
}
