[<AutoOpen>]
module NamelessInteractive.AASA.JoyOfLiving.Views.ViewModels.Helpers

open System
open NamelessInteractive.AASA.JoyOfLiving.Core
open NamelessInteractive.AASA.JoyOfLiving.Core.Models

type System.String with
    member this.FirstCharOrEmpty() =
        if (System.String.IsNullOrEmpty(this)) then
            EmptyString
        else
            this.Substring(0,1)

