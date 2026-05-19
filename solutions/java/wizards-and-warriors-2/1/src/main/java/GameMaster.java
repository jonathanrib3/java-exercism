public class GameMaster {

    public String describe(Character character) {
      return "You're a level "
              + String.valueOf(character.getLevel())
              + " "
              + character.getCharacterClass()
              + " with "
              + String.valueOf(character.getHitPoints())
              + " hit points.";
    }
    public String describe(Destination destination) {
      return "You've arrived at "
              + destination.getName()
              + ", which has "
              + destination.getInhabitants()
              + " "
              + "inhabitants.";
    }
    public String describe(TravelMethod method) {
      String methodPrefix = method == TravelMethod.WALKING ? "by" : "on";
      return "You're traveling to your destination "
              + methodPrefix
              + " "
              + method.toString().toLowerCase() + ".";
    }
    public String describe(Character character, Destination destination, TravelMethod method) {
      return describe(character) + " " + describe(method) + " " + describe(destination);
    }

    public String describe(Character character, Destination destination) {
      return describe(character) + " You're traveling to your destination by walking. " + describe(destination);
    }
}
