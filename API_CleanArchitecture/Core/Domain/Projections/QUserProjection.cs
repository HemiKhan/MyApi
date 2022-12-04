using Domain.Events.QUserEvents;
using Domain.Models.CardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.QUserModels
{
    public partial record QUser
    {
        protected override void When(IDomainEvent @event)
        {
            switch (@event)
            {
                case QUser_Added e:
                    Apply(e);
                    break;
                case QUser_Updated e:
                    Apply(e);
                    break;
                case Quser_Deleted e:
                    break;
                default:
                    throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
            }
        }


        public void Apply(QUser_Added e)
        {
            FirstName = e.firstName;
            LastName = e.lastName;
            EmployeeId = e.employeeId;
            MiddleName = e.middleName;
            DepartmentName = e.department;
            CompanyName = e.company;
            Gender = e.gender;
            Phone = e.phone;
            LastUse = e.lastUse;
            LastLocation = e.lastLocation;
            Nationality = e.nationality;
            QUserType = e.qUserType;
            Email = e.email;

        }
        public void Apply(QUser_Updated e)
        {
            if (!FirstName.Equals(e.NewValue.firstName) && e.NewValue.firstName != null)
            {
                FirstName = e.NewValue.firstName;
            }

            if (!LastName.Equals(e.NewValue.lastName) && e.NewValue.lastName != null)
            {
                LastName = e.NewValue.lastName;
            }

            if (!MiddleName!.Equals(e.NewValue.middleName) && e.NewValue.middleName != null)
            {
                MiddleName = e.NewValue.middleName;
            }

            if (!EmployeeId.Equals(e.NewValue.employeeId) && e.NewValue.employeeId != null)
            {
                EmployeeId = e.NewValue.employeeId;
            }

            if (!Email!.Equals(e.NewValue.email) && e.NewValue.email != null)
            {
                Email = e.NewValue.email;
            }

            if (!DepartmentName!.Equals(e.NewValue.department) && e.NewValue.department != null)
            {
                DepartmentName = e.NewValue.department;

            }

            if (!CompanyName!.Equals(e.NewValue.company) && e.NewValue.company != null)
            {
                CompanyName = e.NewValue.company;

            }

            if (!Gender.Equals(e.NewValue.gender) && e.NewValue.gender != null)
            {
                Gender = e.NewValue.gender;

            }

            if (!QUserType.Equals(e.NewValue.qUserType) && e.NewValue.qUserType != null)
            {
                QUserType = e.NewValue.qUserType;

            }

            if (!Phone.Equals(e.NewValue.phone) && e.NewValue.phone != null)
            {
                Phone = e.NewValue.phone;

            }

            if (!LastArea.Equals(e.NewValue.lastArea) && e.NewValue.lastArea != null)
            {
                LastArea = e.NewValue.lastArea;
            }

            if (!LastUse.Equals(e.NewValue.lastUse) && e.NewValue.lastUse != null)
            {
                LastUse = e.NewValue.lastUse;

            }

            if (!LastLocation.Equals(e.NewValue.lastLocation) && e.NewValue.lastLocation != null)
            {
                LastLocation = e.NewValue.lastLocation;

            }

            if (!Nationality.Equals(e.NewValue.nationality) && e.NewValue.nationality != null)
            {
                Nationality = e.NewValue.nationality;

            }




        }

    }
}
