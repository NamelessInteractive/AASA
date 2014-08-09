module NamelessInteractive.AASA.JoyOfLiving.Core.Helpers

open System

open NamelessInteractive.AASA.JoyOfLiving.Core.Models



let AttendeeTypeToString attendeeType =     
        match attendeeType with
        | AA -> Constants.AAString
        | AlAnon -> Constants.AlAnonString
        | AACA -> Constants.AACAString
        | AlATeen -> Constants.AlATeenString
        | Visitor -> Constants.VisitorString

let StringToAttendeeType (attendeeTypeString:string) = 
    match attendeeTypeString with
    | AAText -> AA
    | AlAnonText -> AlAnon
    | AACAText -> AACA
    | AlATeenText -> AlATeen
    | VisitorText -> Visitor
    | _ -> failwith "Unknown attendee type string"