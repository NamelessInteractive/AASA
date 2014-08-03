module NamelessInteractive.AASA.JoyOfLiving.Core.Models

module internal Constants =
    [<Literal>]
    let AAString = "AA"
    [<Literal>]
    let AlAnonString = "Al-Anon"
    [<Literal>]
    let AlATeenString = "Al-Ateen"
    [<Literal>]
    let AACAString = "AACA"
    [<Literal>]
    let VisitorString = "Visitor"

type AttendeeType = 
    | AA
    | AlAnon
    | AACA
    | AlATeen
    | Visitor

[<AutoOpen>]
module internal Patterns = 
    let (|AAText|_|) value =
        match value with
        | Constants.AAString -> Some (AAText)
        | _ -> None
    let (|AlAnonText|_|) value =
        match value with
        | Constants.AlAnonString -> Some (AlAnonText)
        | _ -> None
    let (|AACAText|_|) value =
        match value with
        | Constants.AACAString -> Some (AACAText)
        | _ -> None
    let (|AlATeenText|_|) value =
        match value with
        | Constants.AlATeenString -> Some (AlATeenText)
        | _ -> None
    let (|VisitorText|_|) value =
        match value with
        | Constants.VisitorString -> Some(VisitorText)
        | _ -> None


module Utilities =
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