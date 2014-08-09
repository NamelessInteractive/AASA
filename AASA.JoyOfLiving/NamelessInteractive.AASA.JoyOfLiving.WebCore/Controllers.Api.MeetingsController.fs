namespace NamelessInteractive.AASA.JoyOfLiving.WebCore.Controllers.Api

open System
open System.Web.Http
open NamelessInteractive.AASA.JoyOfLiving.WebData.Repositories

type MeetingsController() = 
    inherit ApiController()
    member this.Get() =
        MeetingRepository().GetAll()