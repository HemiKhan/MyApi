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
        protected override void When(IDomainEvent @event)
        {
            switch (@event)
            {
                case QUserFile_Added e:
                    Apply(e);
                    break;
                case QUserFile_Updated e:
                    Apply(e);
                    break;
                case QUserFile_Deleted e:
                    break;
                default:
                    throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
            }
        }

        public void Apply(QUserFile_Added e)
        {
            QUserId = e.QUserId;
            ImageName = e.ImageName;
            ImageData = Encoding.ASCII.GetBytes(e.ImageData);
        }

        public void Apply(QUserFile_Deleted e)
        {
            QUserId = e.QUserFile.QUserId;
            ImageName = e.QUserFile.ImageName;
            ImageData = e.QUserFile.ImageData;
        }
        public void Apply(QUserFile_Updated e)
        {

            if (!ImageName!.Equals(e.NewValue.ImageName) && e.NewValue.ImageName != null)
                ImageName = e.NewValue.ImageName;
            if (!ImageData!.ToString()!.Equals(e.NewValue.ImageData!.ToString()) && e.NewValue.ImageData != null)
                ImageData = e.NewValue.ImageData;
        }
    }
}
