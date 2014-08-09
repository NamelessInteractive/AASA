namespace NamelessInteractive.AASA.JoyOfLiving.Core.Models

open System

type User = 
    {
        Id: Identifier
        mutable EmailAddress: string
        mutable Password: string
    }
    with
        static member Create(email, unhashedPassword) =
            {
                Id = Identifier.Create()
                EmailAddress = email
                Password = NamelessInteractive.AASA.JoyOfLiving.Core.Security.GenerateHash(unhashedPassword)
            }
