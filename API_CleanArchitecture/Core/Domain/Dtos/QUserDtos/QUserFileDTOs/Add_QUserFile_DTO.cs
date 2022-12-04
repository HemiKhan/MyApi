using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.QUserDtos.QUserFileDTOs
{
    public record Add_QUserFile_DTO(string? ImageName, string? ImageData);
    public record Get_QUserFile_DTO(long? Id,string? ImageName, byte[]? ImageData);
    public record Update_QUserFile_DTO(long? Id,string? ImageName, string ImageData);


    public class Update_QUserFile_EventParameters {

        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
    }
   
}
