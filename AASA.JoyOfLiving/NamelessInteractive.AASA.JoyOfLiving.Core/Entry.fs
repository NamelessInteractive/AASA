namespace NamelessInteractive.AASA.JoyOfLiving.Core

open Xamarin.Forms

type App() =
    static member GetMainPage() =
        ContentPage(
            Content = 
                Label(
                    Text="Hello Xamarin.Forms!", 
                    VerticalOptions = LayoutOptions.CenterAndExpand, 
                    HorizontalOptions=LayoutOptions.CenterAndExpand
                    )
                )