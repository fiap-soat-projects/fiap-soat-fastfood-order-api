using Business.Entities.Exceptions;
using Business.Entities.Interfaces;
using Domain.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace Business.Entities;

public class Customer : IBusinessEntity
{
    private string? _id;
    private string? _name;
    private string? _cpf;
    private string? _email;

    public string? Id
    {
        get => _id!;
        set
        {
            CustomerException.ThrowIfNullOrWhiteSpace(value, nameof(Id));

            _id = value;
        }
    }

    public string? Name
    {
        get => _name!;
        set
        {
            CustomerException.ThrowIfNullOrWhiteSpace(value, nameof(Name));

            _name = value;
        }
    }

    public Cpf Cpf
    {
        get => _cpf!;
        set
        {
            _cpf = value;
        }
    }

    public Email Email
    {
        get => _email!;
        set
        {
            _email = value;
        }
    }

    [SetsRequiredMembers]
    public Customer(string? id, string? name, Cpf cpf, Email email)
    {
        Id = id;
        Name = name;
        Cpf = cpf;
        Email = email;
    }
}
