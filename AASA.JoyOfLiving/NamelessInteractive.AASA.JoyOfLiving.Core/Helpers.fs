module NamelessInteractive.AASA.JoyOfLiving.Core.Helpers

open System

open NamelessInteractive.AASA.JoyOfLiving.Core.Models

let AttendeeTypeToString attendeeType =     
        match attendeeType with
        | AttendeeType.AA -> Constants.AAString
        | AttendeeType.AlAnon -> Constants.AlAnonString
        | AttendeeType.AACA -> Constants.AACAString
        | AttendeeType.AlATeen -> Constants.AlATeenString
        | AttendeeType.Visitor -> Constants.VisitorString
        | _ -> failwith "Unknown Attendee type."

let StringToAttendeeType (attendeeTypeString:string) = 
    match attendeeTypeString with
    | AAText -> AttendeeType.AA
    | AlAnonText -> AttendeeType.AlAnon
    | AACAText -> AttendeeType.AACA
    | AlATeenText -> AttendeeType.AlATeen
    | VisitorText -> AttendeeType.Visitor
    | _ -> failwith "Unknown attendee type string"