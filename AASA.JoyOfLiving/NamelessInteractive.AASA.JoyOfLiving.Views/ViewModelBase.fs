namespace NamelessInteractive.AASA.JoyOfLiving.Views.ViewModels

open System
open System.Runtime.CompilerServices
open System.ComponentModel

type ViewModelBase() =
    let propertyChanged = Event<_, _>()
    member this.OnChanged([<CallerMemberName>]property: string) =
        propertyChanged.Trigger(this, PropertyChangedEventArgs(property))
    interface System.ComponentModel.INotifyPropertyChanged with
        [<CLIEvent>]
        member this.PropertyChanged = propertyChanged.Publish