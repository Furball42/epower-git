using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePower.Core.Models
{
    public enum HistoryType
    {
        Created = 1,
        Transitioned = 2,
        Commented = 3,
        Edited = 4,
        Deleted = 5,
        Completed = 6,
        Communication = 7,
    }

    public enum ActionEntityType
    {
        SuperUser = 1,
        User = 2,
        Client = 3,
    }

    #region Base

    public class Base
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class BaseExtended : Base
    {
        public string Icon { get; set; }
        public string Color { get; set; }
    }

    public class BaseIdDescription : Base
    {
        public string Description { get; set; }
    }

    #endregion

    #region Universal

    public class Address : Base
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string GPS { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public bool IsDefault { get; set; }
        public ActionEntityType ActionEntityType { get; set; }

        public virtual AddressType AddressType { get; set; }
    }

    public class AddressType : BaseIdDescription
    {

    }

    public class EmailAddress : Base
    {
        public string Email { get; set; }
        public bool IsDefault { get; set; }
        public ActionEntityType ActionEntityType { get; set; }
    }

    public class PhoneNumber : Base
    {
        public string Number { get; set; }
        public bool IsDefault { get; set; }
        public ActionEntityType ActionEntityType { get; set; }

        public virtual PhoneNumberType PhoneNumberType { get; set; }
    }

    public class PhoneNumberType : BaseIdDescription
    {

    }

    public class Person : Base
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IDNumber { get; set; }       
    }

    #endregion

    #region Core - Organization

    public class Organization : Base
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public Guid CreatorId { get; set; }
    }

    public class Level : BaseExtended
    {
        public string Description { get; set; }
        public int SortOrder { get; set; }
    }

    #endregion

    #region Core - Clients

    public class Client : Base
    {
        public string Name { get; set; }
        //multiple email addresses
        //multiple phone numbers
    }

    public class ClientContacts : Base
    {
        //client id
        //person id
        //is main contact
    }

    #endregion

    #region Core - Project

    public class Project : BaseExtended
    {
        public string Description { get; set; }
        public string ShortCode { get; set; }
        public bool IsActive { get; set; }
    }

    public class Task : BaseExtended
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateDue { get; set; }
        public bool IsCompleted { get; set; }
        public string Version { get; set; }
        public bool IsArchived { get; set; }
        public bool IsFlagged { get; set; }

        public virtual Status Status { get; set; }
        public virtual Project Project { get; set; }

        //many to many - users
        //many to many - tags
    }

    public class SubTask : Base
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public virtual Task Task { get; set; }
    }

    public class Tag : BaseExtended
    {
        public string Description { get; set; }
    }

    public class Status : Base
    {
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsCommunicationTrigger { get; set; }
        public bool IsCommentTrigger { get; set; }
        public bool IsAlertTrigger { get; set; }
    }

    public class Document : Base
    {
        public byte[] Data { get; set; }

        public virtual Task Task { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }

    public class DocumentType : BaseExtended
    {
        public string Description { get; set; }
    }

    public class History : Base
    {       
        public HistoryType Type { get; set; }

        //link to user virtually?
        public Guid UserId { get; set; } 
    }

    public class Comment : Base
    {
        public string Description { get; set; }

        public virtual Task Task { get; set; }
        //link to user virtually?
        public Guid UserId { get; set; }
    }

    #endregion
}
