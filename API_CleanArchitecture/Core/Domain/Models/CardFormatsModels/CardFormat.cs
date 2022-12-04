namespace Domain.Models.CardFormatsModels;


using System.Collections.Generic;


public partial record CardFormat : AggregateRoot<long>, IMustHaveOrganization, IMustHaveToken
{
    CardFormat() { }

    CardFormat(string name, string description, int bitLength, bool isEnable)
    {
        var e = new CardForrmat_Added(name, description, bitLength, isEnable);
        RegisterEvent(e);
    }

    public long OrganizationId { get; private set; }
    public string Token { get; private set; } = string.Empty;
    public List<CardFormatItems> CardFormatItems { get; } = new();
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public int BitLength { get; private set; } = default!;
    public bool IsEnable { get; private set; }
}

