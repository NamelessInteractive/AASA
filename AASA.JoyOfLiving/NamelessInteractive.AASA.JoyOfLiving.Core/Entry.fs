namespace NamelessInteractive.AASA.JoyOfLiving.Core

open Xamarin.Forms

type App() =
    static member GetMainPage() =
        let mainNav = NavigationPage(Views.StartPage())
        mainNav