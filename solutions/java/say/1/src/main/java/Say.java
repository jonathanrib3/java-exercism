import java.util.HashMap;
import java.util.Map;
import java.util.Stack;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Say {
    private final EnglishNumbersDictionary dictionary;

    public Say() {
        this.dictionary = new EnglishNumbersDictionary();
    }

    public String say(long number) {
        EnglishNumbersDictionary dictionary = new EnglishNumbersDictionary();
        Stack<NumberChunk> separatedChunksOfNumber = separateNumberIntoChunks(number);

        if (number < 0 || number > 999_999_999_999L) {
            throw new IllegalArgumentException();
        }

        return buildNumberInEnglish(separatedChunksOfNumber);
    }

    private String buildNumberInEnglish(Stack<NumberChunk> separatedChunksOfNumber) {
        StringBuilder convertedNumber = new StringBuilder();

        while(!separatedChunksOfNumber.isEmpty()) {
            NumberChunk chunk = separatedChunksOfNumber.pop();
            if (chunk.isScaleZero()) {
                continue;
            }
            convertedNumber.append(convertDigitsToEnglish(chunk.digits))
                    .append(" ")
                    .append(powerOfTenToEnglishScale(chunk.exponent))
                    .append(" ");
        }

        return convertedNumber.toString().trim();
    }

    private Stack<NumberChunk> separateNumberIntoChunks(long number) {
        char[] numberAsCharArr = String.valueOf(number).toCharArray();
        Stack<NumberChunk> separatedChunksOfNumber = new Stack<>();
        StringBuilder chunkStringAcc = new StringBuilder();
        int numberExponent = (int) Math.ceil(Math.log10(number));
        int currentChunkExponent = 0;
        for(int i = numberAsCharArr.length - 1; i >= 0; i--) {
            chunkStringAcc.append(numberAsCharArr[i]);
            if (chunkStringAcc.length() == 3 || i == 0) {
                separatedChunksOfNumber.add(new NumberChunk(currentChunkExponent, chunkStringAcc.reverse().toString()));
                chunkStringAcc.delete(0, chunkStringAcc.length());
            }
            currentChunkExponent++;
        }

        return separatedChunksOfNumber;
    }

    private String powerOfTenToEnglishScale(Integer exponent) {
        if (exponent >= 3 && exponent <= 5) {
            return "thousand";
        } else if (exponent >= 6 && exponent <= 8) {
            return "million";
        } else if (exponent >= 9) {
            return "billion";
        }
        return "";
    }
    private String convertDigitsToEnglish(String number) {
        int parsedNumber = Integer.parseInt(number);
        int moduleNumber = parsedNumber % 10;

        if (parsedNumber > 20 && parsedNumber < 100) {
            return dictionary
                .INTEGER_TO_ENGLISH
                .get(parsedNumber - moduleNumber) + getTensEnglishSuffix(moduleNumber);
        }
        if (parsedNumber >= 100) {
            String lastTwoDigitsInEnglish = parsedNumber % 100 == 0
                    ? ""
                    : " " + convertDigitsToEnglish(number.substring(1));
            return dictionary.INTEGER_TO_ENGLISH
                    .get(Integer.parseInt(String.valueOf(number.charAt(0))))
                    + " "
                    + dictionary.INTEGER_TO_ENGLISH.get(100)
                    + lastTwoDigitsInEnglish;
        }

        return dictionary.INTEGER_TO_ENGLISH.get(parsedNumber);
    }

    private String getTensEnglishSuffix(Integer moduleNumber) {
        return moduleNumber == 0 ? "" : "-" + dictionary.INTEGER_TO_ENGLISH.get(moduleNumber);
    }
}

class EnglishNumbersDictionary {
    private final String[] primitiveNumbers = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"};
    private final String[] irregularTeens = {"eleven", "twelve"};
    private final String[] regularTeens = {"thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
    private final String[] regularTens = {"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
    public final Map<Integer, String> INTEGER_TO_ENGLISH;

    public EnglishNumbersDictionary() {
        this.INTEGER_TO_ENGLISH = new HashMap<>();
        initializeIntegerToEnglish();
    }

    public void initializeIntegerToEnglish() {
        for(int i = 0; i < primitiveNumbers.length; i++) {
            this.INTEGER_TO_ENGLISH.put(i, primitiveNumbers[i]);
        }
        for(int i = 0; i < irregularTeens.length; i++) {
            this.INTEGER_TO_ENGLISH.put(11  + i, irregularTeens[i]);
        }
        for(int i = 0; i < regularTeens.length; i++) {
            this.INTEGER_TO_ENGLISH.put(i + 13, regularTeens[i]);
        }

        for(int i = 20, j = 0; j < regularTens.length; i += 10, j++) {
            this.INTEGER_TO_ENGLISH.put(i , regularTens[j] );
        }
        this.INTEGER_TO_ENGLISH.put(100, "hundred");
    }
}

class NumberChunk {
    public final int exponent;
    public final String digits;

    public NumberChunk(int exponent, String digits) {
        this.exponent = exponent;
        this.digits = digits;
    }

    public boolean isScaleZero() {
        final String SCALE_ZERO_REGEX = "^0{2,3}$";
        Pattern ptn = Pattern.compile(SCALE_ZERO_REGEX);
        Matcher mtc = ptn.matcher(digits);

        return mtc.matches();
    }
}