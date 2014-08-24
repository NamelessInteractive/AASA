namespace NamelessInteractive.AASA.JoyOfLiving.WebData

open System
open NamelessInteractive.AASA.JoyOfLiving.Core.Models

type RegistrationDataContract = 
    {
        Id: int
        UserId: int
        Attendees: Attendee list
        IsPaid: bool
        RegistrationDate: DateTimeOffset
    }