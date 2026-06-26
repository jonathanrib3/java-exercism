using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
            var GreekAlphabet = new char[] {'α', 'β', 'Γ', 'γ', 'Δ', 'δ', 'ε', 'ζ', 'η', 'Θ', 'θ', 'ι', 'κ', 'Λ', 'λ', 'μ', 'ν', 'Ξ', 'ξ', 'Π', 'π','ρ', 'Σ', 'σ', 'ς', 'τ','υ', 'Φ' ,'φ', 'χ', 'Ψ', 'ψ', 'Ω', 'ω'};
        var builder = new StringBuilder();
        var shouldConvertToKebab = false;
        foreach(char something in identifier) 
        {
            if(something == '\0')
            {
                builder.Append("CTRL");
                continue;
            }
            if(something == ' ')
            {
                builder.Append('_');
                continue;
            }
            if(something == '-')
            {
                shouldConvertToKebab = true;
                continue;
            }
            if(shouldConvertToKebab)
            {
                builder.Append(Char.ToUpper(something));
                shouldConvertToKebab = false;
                continue;
            }
            if(!Char.IsLetter(something) || Array.Exists(GreekAlphabet, letter => something == letter))
            {
                continue;
            }
            builder.Append(something);
        }
        return builder.ToString();
    }
}
