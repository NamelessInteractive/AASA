namespace NamelessInteractive.AASA.JoyOfLiving.Android

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

[<Activity (Label = "AA - Jozi 2015", MainLauncher = true)>]
type MainActivity () =
    inherit Xamarin.Forms.Platform.Android.AndroidActivity ()
    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        Xamarin.Forms.Forms.Init(this,bundle)
        this.SetPage(NamelessInteractive.AASA.JoyOfLiving.Views.App.GetMainPage(this.SetPage))