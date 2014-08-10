namespace NamelessInteractive.AASA.JoyOfLiving.Views

open Xamarin.Forms

type App() =
    static member GetMainPage(setPageFunction: Page -> unit) =
        Views.LoginPage(setPageFunction)

