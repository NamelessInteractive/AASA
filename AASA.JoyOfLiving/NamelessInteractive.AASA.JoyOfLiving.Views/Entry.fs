namespace NamelessInteractive.AASA.JoyOfLiving.Views

open Xamarin.Forms

type App() =
    static member GetMainPage() =
        let mainNav = NavigationPage(Views.StartPage())
        mainNav