namespace NamelessInteractive.AASA.JoyOfLiving.WebCore.Controllers.Api

open System.Web.Http
open NamelessInteractive.AASA.JoyOfLiving.WebData

type UserController() =
    inherit ApiController()

    member this.Get() = 
        Seq.empty<UserDataContract>

    [<HttpPost>]
    member this.Authenticate(email: string, hashedPassword:string) =
        true