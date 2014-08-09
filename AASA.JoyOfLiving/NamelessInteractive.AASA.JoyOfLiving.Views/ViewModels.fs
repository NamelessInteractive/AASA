module NamelessInteractive.AASA.JoyOfLiving.Views.ViewModels

open System.ComponentModel
open System.Collections.ObjectModel
open System.Runtime.CompilerServices
open NamelessInteractive.AASA.JoyOfLiving.Core
open NamelessInteractive.AASA.JoyOfLiving.Core.Models

type System.String with
    member this.FirstCharOrEmpty() =
        if (System.String.IsNullOrEmpty(this)) then
            EmptyString
        else
            this.Substring(0,1)

type ViewModelBase() =
    let propertyChanged = Event<_, _>()
    member this.OnChanged([<CallerMemberName>]property: string) =
        propertyChanged.Trigger(this, PropertyChangedEventArgs(property))
    interface System.ComponentModel.INotifyPropertyChanged with
        [<CLIEvent>]
        member this.PropertyChanged = propertyChanged.Publish

open System.Reflection;

type AttendeeViewModel(attendee: Models.Attendee) =
    inherit ViewModelBase()
    let getResourceNameAttendeeType attendeeType = 
        match attendeeType with
        | Models.AA -> Xamarin.Forms.ImageSource.FromResource "AA.png"
        | Models.AACA -> Xamarin.Forms.ImageSource.FromResource "AACA.png"
        | Models.AlAnon -> Xamarin.Forms.ImageSource.FromResource "AlAnon.png"
        | Models.AlATeen -> Xamarin.Forms.ImageSource.FromResource "AlATeen.png"
        | Models.Visitor -> Xamarin.Forms.ImageSource.FromResource "Visitor.png"
    let mutable m_IsNew = true
    new() = AttendeeViewModel(Models.Attendee.Create())
    member this.FirstName
        with get() = attendee.FirstName
        and  set value =
                attendee.FirstName <- value
                base.OnChanged(null)
                base.OnChanged("DisplayName")
    member this.LastName
        with get() = attendee.LastName
        and  set value =
                attendee.LastName <- value
                base.OnChanged(null)
                base.OnChanged("DisplayName")
    member this.GroupName
        with get() = attendee.GroupName
        and  set value =
                attendee.GroupName <- value
                base.OnChanged(null)
    member this.EmailAddress
        with get() = attendee.EmailAddress
        and  set value =
                attendee.EmailAddress <- value
                base.OnChanged(null)
    member this.TelephoneNumber 
        with get() = attendee.TelephoneNumber
        and  set value =
                attendee.TelephoneNumber <- value
                base.OnChanged(null)
    member this.AttendeeType 
        with get() = attendee.AttendeeType
        and set value =
                attendee.AttendeeType <- value
                base.OnChanged(null)
                base.OnChanged("ImageSource")
    member this.DisplayName 
        with get() = this.FirstName + " " + this.LastName.FirstCharOrEmpty()
    member this.ImageSource 
        with get() = 
            getResourceNameAttendeeType attendee.AttendeeType
    member this.IsNew 
        with get() = m_IsNew
        and  set value =
                m_IsNew <- value
                base.OnChanged(null)
    member this.IsPaid
        with get() = attendee.IsPaid
        and  set value =
                attendee.IsPaid <- value
                base.OnChanged(null)
    member this.IncludeShares
        with get() = attendee.IncludeShares
        and  set value =
                attendee.IncludeShares <- value
                base.OnChanged(null)
    member this.TShirtSize 
        with get() = attendee.TShirtSize
        and  set value =
                attendee.TShirtSize <- value
                base.OnChanged(null)

type AttendeesListViewModel() =
    inherit ViewModelBase()
    let attendeesList = ObservableCollection<AttendeeViewModel>()
    member this.AttendeesList 
        with get() = attendeesList
    member this.Add (attendee) =
        this.AttendeesList.Add(attendee)
    member this.Remove (attendee) =
        this.AttendeesList.Remove(attendee)
        