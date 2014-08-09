namespace NamelessInteractive.AASA.JoyOfLiving.Core.Models

open System

type Identifier = Identifier of Guid 

type Identifier with
    static member Create () = Identifier(Guid.NewGuid())