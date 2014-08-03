namespace NamelessInteractive.AASA.JoyOfLiving.WebCore.Controllers

open System.Web.Mvc

type HomeController() = 
    inherit Controller()
    member this.Index() = this.View()
