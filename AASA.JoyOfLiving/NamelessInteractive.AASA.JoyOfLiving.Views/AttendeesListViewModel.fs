namespace NamelessInteractive.AASA.JoyOfLiving.Views.ViewModels

open System
open System.Collections.ObjectModel

type AttendeesListViewModel() =
    inherit ViewModelBase()
    let attendeesList = ObservableCollection<AttendeeViewModel>()
    member this.AttendeesList 
        with get() = attendeesList
    member this.Add (attendee) =
        this.AttendeesList.Add(attendee)
    member this.Remove (attendee) =
        this.AttendeesList.Remove(attendee)