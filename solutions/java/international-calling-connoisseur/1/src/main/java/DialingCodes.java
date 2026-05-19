import java.util.HashMap;
import java.util.Map;

public class DialingCodes {
    private Map<Integer, String> codes;

    public DialingCodes() {
        this.codes = new HashMap<>();
    }

    public Map<Integer, String> getCodes() {
        return this.codes;
    }

    public void setDialingCode(Integer code, String country) {
        this.codes.put(code, country);
    }

    public String getCountry(Integer code) {
        return this.codes.get(code);
    }

    public void addNewDialingCode(Integer code, String country) {
        if (!this.codes.containsKey(code) && !this.codes.containsValue(country)) {
            this.codes.put(code, country);
        }
    }

    public Integer findDialingCode(String country) {
        for (Map.Entry<Integer, String> codeEntry: this.codes.entrySet()) {
            if (codeEntry.getValue().equals(country)) {
                return codeEntry.getKey();
            }
        }

        return null;
    }

    public void updateCountryDialingCode(Integer code, String country) {
        for(Map.Entry<Integer, String> codeEntry: this.codes.entrySet()) {
            if (codeEntry.getValue().equals(country)) {
                this.codes.remove(codeEntry.getKey());
            }
        }

        this.codes.put(code, country);
    }
}
