class Fighter {

    boolean isVulnerable() {
        return true;
    }

    int getDamagePoints(Fighter fighter) {
        return 1;
    }
}

class Warrior extends Fighter {
    @Override
    boolean isVulnerable() {
        return false;
    }

    @Override
    int getDamagePoints(Fighter fighter) {
        return fighter.isVulnerable() ? 10 : 6;
    }

    @Override
    public String toString() {
        return "Fighter is a " + this.getClass().getName();
    }
}

// TODO: define the Wizard class
class Wizard extends Fighter {
    private boolean hasSpellBeenCastedInAdvance;

    public Wizard() {
        this.hasSpellBeenCastedInAdvance = false;
    }

    public void prepareSpell() {
        this.hasSpellBeenCastedInAdvance = true;
    }

    @Override
    boolean isVulnerable() {
        return !this.hasSpellBeenCastedInAdvance;
    }

    @Override
    int getDamagePoints(Fighter fighter) {
        return this.hasSpellBeenCastedInAdvance ? 12 : 3;
    }

    @Override
    public String toString() {
        return "Fighter is a " + this.getClass().getName();
    }
}
