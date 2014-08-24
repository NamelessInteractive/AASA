namespace NamelessInteractive.AASA.JoyOfLiving.WebData

open System
open NamelessInteractive.AASA.JoyOfLiving.Core.Models

type AttendeeDataContract = 
    {
        Id : int
        RegistrationId: int
        Attendee: Attendee
    }
