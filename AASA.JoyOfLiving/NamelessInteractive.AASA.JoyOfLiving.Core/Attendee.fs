namespace NamelessInteractive.AASA.JoyOfLiving.Core.Models

open System

type Attendee = 
    {
        Id: Identifier
        mutable FirstName : string
        mutable LastName : string
        mutable GroupName: string
        mutable EmailAddress: string
        mutable TelephoneNumber: string
        mutable AttendeeType: AttendeeType
        mutable IncludeShares: bool
        mutable TShirtSize: ShirtSize
    }
    with 
        static member Create() = 
            { 
                Id = Identifier.Create()
                FirstName = EmptyString
                LastName = EmptyString
                GroupName = EmptyString
                EmailAddress = EmptyString
                TelephoneNumber = EmptyString
                AttendeeType = AttendeeType.AA
                IncludeShares = true
                TShirtSize = ShirtSize.ShirtSizeM
            }