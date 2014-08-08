namespace NamelessInteractive.AASA.JoyOfLiving.WebCore.Controllers.Api

open System.Web.Http

type AccountController() =
    inherit ApiController()

    member this.Get() = 
        Seq.empty<int>