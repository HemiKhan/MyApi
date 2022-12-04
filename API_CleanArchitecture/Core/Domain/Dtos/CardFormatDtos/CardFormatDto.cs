namespace Domain.Dtos.CardFormatDtos;

using Domain.Models.CardFormatsModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AddCardFormatDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int BitLength { get; set; }
    public bool IsEnable { get; set; }
    public ICollection<FormatItems>? CardFormatItems { get; set; }
};

public class UpdateCardFormatDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int BitLength { get; set; }
    public bool IsEnable { get; set; }
    public ICollection<UpdateFormatItems> CardFormatItems { get; set; } = default!;
};
public class FormatItems
{
    public string FieldMapName { get; set; } = string.Empty;
    public string EncodingRange { get; set; } = string.Empty;
    public string Encoding { get; set; } = string.Empty;
}
public record UpdateFormatItems(long Id,
     string FieldMapName,
     string EncodingRange,
     string Encoding
);
public class GetFormatItems
{
    public long Id { get; set; }
    public string FieldMapName { get; set; } = string.Empty;
    public string EncodingRange { get; set; } = string.Empty;
    public string Encoding { get; set; } = string.Empty;
}
public record GetAllCardFormatsDto(

)
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    //public string? Description { get; set; }
    //public int BitLength { get; set; }
}

public record DeleteCardFormatDto(long Id);
public record GetByIdCardFormatDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int BitLength { get; set; }
    public bool IsEnable { get; set; }
    public IEnumerable<GetFormatItems>? CardFormatItems { get; set; }
}