module NamelessInteractive.AASA.JoyOfLiving.Core.Models



let EmptyString = System.String.Empty

module Constants =
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
    [<Literal>]
    let XSmallString = "E"
    [<Literal>]
    let SmallString = "S"
    [<Literal>]
    let MediumString = "M"
    [<Literal>]
    let LargeString = "L"
    [<Literal>]
    let XLargeString = "XL"
    [<Literal>]
    let XXLargeString = "XXL"

type AttendeeType = 
    | AA
    | AlAnon
    | AACA
    | AlATeen
    | Visitor

type ShirtSize =
    | ShirtSizeXS 
    | ShirtSizeS
    | ShirtSizeM
    | ShirtSizeL
    | ShirtSizeXL
    | ShirtSizeXXL

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

type Attendee = 
    {
        mutable FirstName : string
        mutable LastName : string
        mutable GroupName: string
        mutable EmailAddress: string
        mutable TelephoneNumber: string
        mutable AttendeeType: AttendeeType
        mutable IsPaid: bool
        mutable IncludeShares: bool
        mutable TShirtSize: ShirtSize
    }
    with 
        static member Create() = 
            { 
                FirstName = EmptyString
                LastName = EmptyString
                GroupName = EmptyString
                EmailAddress = EmptyString
                TelephoneNumber = EmptyString
                AttendeeType = AA
                IsPaid = false
                IncludeShares = true
                TShirtSize = ShirtSizeM
            }

let GenerateHash (value: string) =
    let buffer = Array.zeroCreate(10)
    System.Random().NextBytes(buffer)
    let salt = System.Text.UTF8Encoding.UTF8.GetString(buffer,0,buffer.Length)
    let saltLen = salt.Length.ToString()
    saltLen + ":" + salt + NamelessInteractive.Shared.Security.SHA512().ComputeString(value).ToString()


let CompareHash (value: string, actual: string) =
    let saltLen = int (actual.Substring(0, actual.IndexOf(":")))
    let actualUnsalted = actual.Substring(saltLen.ToString().Length + 1 + saltLen)
    let res = NamelessInteractive.Shared.Security.SHA512().ComputeString(value).ToString()
    res = actualUnsalted