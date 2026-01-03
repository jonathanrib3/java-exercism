import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

class GottaSnatchEmAll {
    static Set<String> newCollection(List<String> cards) {
        return new HashSet<String>(cards);
    }

    static boolean addCard(String card, Set<String> collection) {
        return collection.add(card);
    }

    static boolean canTrade(Set<String> myCollection, Set<String> theirCollection) {
        return !myCollection.isEmpty() && !theirCollection.isEmpty()
                && !(myCollection.containsAll(theirCollection) || theirCollection.containsAll(myCollection));
    }

    static Set<String> commonCards(List<Set<String>> collections) {
        Set<String> commonCardsReducer = new HashSet<String>();
        for (Set<String> collection : collections) {
            commonCardsReducer.addAll(collection);
        }
        for(Set<String> collection: collections) {
            commonCardsReducer.retainAll(collection);
        }
    
        return commonCardsReducer;
    }

    static Set<String> allCards(List<Set<String>> collections) {
        Set<String> allCards = new HashSet<String>();
        for(Set<String> cardSet: collections) {
            allCards.addAll(cardSet);
        }

        return allCards;
    }
}
