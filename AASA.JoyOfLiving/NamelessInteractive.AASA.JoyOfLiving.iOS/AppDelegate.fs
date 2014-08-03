namespace NamelessInteractive.AASA.JoyOfLiving.iOS

open System
open MonoTouch.UIKit
open MonoTouch.Foundation
open Xamarin.Forms


[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit UIApplicationDelegate ()

    let window = new UIWindow (UIScreen.MainScreen.Bounds)

    // This method is invoked when the application is ready to run.
    override this.FinishedLaunching (app, options) =
        Xamarin.Forms.Forms.Init()
        let mainPage= NamelessInteractive.AASA.JoyOfLiving.Core.App.GetMainPage()
        window.RootViewController <- mainPage.CreateViewController()
        window.MakeKeyAndVisible ()
        true

module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main (args, null, "AppDelegate")
        0

