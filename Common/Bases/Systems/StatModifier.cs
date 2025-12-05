
namespace RisingShot.Resources.Actors;
public struct StatModifier
{

    public static readonly StatModifier Default = new();
    public StatModifier() { }
    public StatModifier(float additive = 1f, float multiplier = 1f, float flat = 0f, float @base = 0f)
    {
        AdditiveValue = additive;
        MultiplierValue = multiplier;
        FlatValue = flat;
        BaseValue = @base;
    }

    public float BaseValue { get; set; } = 0f;
    public float AdditiveValue { get; set; } = 1f;
    public float MultiplierValue { get; set; } = 1f;
    public float FlatValue { get; set; } = 0f;

    public static StatModifier operator +(StatModifier modifier, float add) => new StatModifier(modifier.AdditiveValue + add, modifier.MultiplierValue, modifier.FlatValue, modifier.BaseValue);
    public static StatModifier operator -(StatModifier modifier, float subtract) => new StatModifier(modifier.AdditiveValue - subtract, modifier.MultiplierValue, modifier.FlatValue, modifier.BaseValue);
    public static StatModifier operator *(StatModifier modifier, float multiplier) => new StatModifier(modifier.AdditiveValue, modifier.MultiplierValue * multiplier, modifier.FlatValue, modifier.BaseValue);
    public static StatModifier operator /(StatModifier modifier, float division) => new StatModifier(modifier.AdditiveValue, modifier.MultiplierValue / division, modifier.FlatValue, modifier.BaseValue);

    public static StatModifier operator +(float add, StatModifier modifier) => modifier + add;
    public static StatModifier operator -(float subtract, StatModifier modifier) => modifier - subtract;

    public static StatModifier operator *(float multiplier, StatModifier modifier) => modifier * multiplier;
    public static StatModifier operator /(float division, StatModifier modifier) => modifier / division;

    public float ApplyTo(float BaseValue) => (BaseValue + this.BaseValue) * AdditiveValue * MultiplierValue + FlatValue;
    public float ApplyTo() => this.BaseValue * AdditiveValue * MultiplierValue + FlatValue;

}