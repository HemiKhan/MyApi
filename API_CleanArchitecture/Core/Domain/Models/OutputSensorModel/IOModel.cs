namespace Domain.Models.OutputSensorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IOModel
{
    public long Id { get; set; } = default!;
    public long ControllerId { get; set; } = 0;
    public string IO { get; set; } = default!;
    public string Name { get; set; } = default!;
    public PortType PortType { get; set; } = default!;
    public State State { get; set; } = default!;
    public string? Status { get; set; }
    public int IONumber { get; set; } = default!;
}
