using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.QUserDtos.QUserFileDTOs;
using Domain.Events.QUserEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Models.QUserModels
{
    public partial record QUserFile
    {
        public static QUserFile Create(long QUserId, string ImageName, string ImageData) => new QUserFile( QUserId,  ImageName,  ImageData);

        public Deleted<QUserFile> Delete()
        {
            var e = new QUserFile_Deleted(this);
            RegisterEvent(e);
            return new Deleted<QUserFile>(this, e);
        }

        public void Update(Update_QUserFile_DTO dto)
        {
           
            var OldValue = new Update_QUserFile_EventParameters();
            var NewValue = new Update_QUserFile_EventParameters();
            bool hasChanges = false;

            if (!ImageName!.Equals(dto.ImageName))
            {
                OldValue.ImageName = ImageName;
                NewValue.ImageName = dto.ImageName!;
                hasChanges = true;
            }

            if (!ImageData!.ToString()!.Equals(dto.ImageData!.ToString()))
            {
                OldValue.ImageData = ImageData!;
                NewValue.ImageData = Encoding.ASCII.GetBytes(dto.ImageData)!;
                hasChanges = true;
                
            }

            if (hasChanges)
            {
                var e = new QUserFile_Updated(dto.Id, OldValue, NewValue);
                RegisterEvent(e);
            }
        }
    }

   
}
