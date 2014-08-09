[<AutoOpen>]
module internal NamelessInteractive.AASA.JoyOfLiving.Core.Models.Patterns

open System

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

