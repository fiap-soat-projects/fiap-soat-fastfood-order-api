using Business.ValueObjects.Exceptions;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace Domain.ValueObjects;

public readonly partial struct Cpf
{
    const short CPF_LENGTH = 11;

    public string Number { get; }

    public static implicit operator Cpf(string? value) => new(value);
    public static implicit operator string(Cpf cpf) => cpf.Number;

    private static readonly Regex CpfReplaceRegex = new Regex(@"[^\d]", RegexOptions.Compiled);

    private static readonly Regex CpfRegex = new Regex(@"^\d{11}$", RegexOptions.Compiled);

    public Cpf(string? number)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(number, "Cpf cannot be null or white space");

        number = CpfReplaceRegex.Replace(number, string.Empty);

        if (number.Length != CPF_LENGTH || CpfRegex.IsMatch(number) is false)
        {
            throw new InvalidCpfException(number);
        }

        Number = number;
    }

    public override string ToString()
    {
        return Number;
    }
}
