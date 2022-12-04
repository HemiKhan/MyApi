namespace Domain.Dtos.PrioritiesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AddPriorityDTO
    (
    string Name,
    int PriorityLevel,
    string ColorCode
    );


public record UpdatePriorityDTO
    (
    long Id,
    string Name,
    int PriorityLevel,
    string ColorCode
    );

public record Update_PriorityDTO
    (
    long? Id,
    string? Name,
    int? PriorityLevel,
    string? ColorCode
    );

public record GetByIdPrioritiesDTO
    (
    )
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public int? PriorityLevel { get; set; }
    public string? ColorCode { get; set; }
}

public record GetAllPrioritiesDTOScroll
    (
    )
{
    public long? Id { get; set; }
    public string? Name { get; set; }
}

public record DeletePriorityDTO(long Id);