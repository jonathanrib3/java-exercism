abstract class Character
{
    public string characterType;
    private bool _isVulnerable;

    protected Character(string characterType)
    {
        this.characterType = characterType;
        this._isVulnerable = false;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => _isVulnerable;

    public override string ToString()
    {
        return $"Character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    public bool hasCastSpellInAdvance;

    public Wizard() : base("Wizard")
    {
        this.hasCastSpellInAdvance = false;
    }

    public override int DamagePoints(Character target) => hasCastSpellInAdvance ? 12 : 3;

    public void PrepareSpell()
    {
        hasCastSpellInAdvance = true;
    }

    public override bool Vulnerable() => !hasCastSpellInAdvance;
}
