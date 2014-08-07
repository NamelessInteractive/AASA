module NamelessInteractive.AASA.JoyOfLiving.Core.ViewModels

open System.ComponentModel
open System.Collections.ObjectModel
open System.Runtime.CompilerServices


let EmptyString = System.String.Empty

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



type AttendeeViewModel() =
    inherit ViewModelBase()
    let getResourceNameAttendeeType attendeeType = 
        match attendeeType with
        | Models.AA -> Xamarin.Forms.ImageSource.FromResource "AA.png"
        | Models.AACA -> Xamarin.Forms.ImageSource.FromResource "AACA.png"
        | Models.AlAnon -> Xamarin.Forms.ImageSource.FromResource "AlAnon.png"
        | Models.AlATeen -> Xamarin.Forms.ImageSource.FromResource "AlATeen.png"
        | Models.Visitor -> Xamarin.Forms.ImageSource.FromResource "Visitor.png"
    let mutable m_FirstName = EmptyString
    let mutable m_LastName = EmptyString
    let mutable m_GroupName = EmptyString
    let mutable m_EmailAddress = EmptyString
    let mutable m_TelephoneNumber = EmptyString
    let mutable m_AttendeeType = Models.AA
    let mutable m_IsNew = true
    let mutable m_IsPaid = false
    let mutable m_IncludeShares = false
    member this.FirstName
        with get() = m_FirstName
        and  set value =
                m_FirstName <- value
                base.OnChanged(null)
                base.OnChanged("DisplayName")
    member this.LastName
        with get() = m_LastName
        and  set value =
                m_LastName <- value
                base.OnChanged(null)
                base.OnChanged("DisplayName")
    member this.GroupName
        with get() = m_GroupName
        and  set value =
                m_GroupName <- value
                base.OnChanged(null)
    member this.EmailAddress
        with get() = m_EmailAddress
        and  set value =
                m_EmailAddress <- value
                base.OnChanged(null)
    member this.TelephoneNumber 
        with get() = m_TelephoneNumber
        and  set value =
                m_TelephoneNumber <- value
                base.OnChanged(null)
    member this.AttendeeType 
        with get() = m_AttendeeType
        and set value =
                m_AttendeeType <- value
                base.OnChanged(null)
                base.OnChanged("ImageSource")
    member this.DisplayName 
        with get() = this.FirstName + " " + this.LastName.FirstCharOrEmpty()
    member this.ImageSource 
        with get() = 
            getResourceNameAttendeeType m_AttendeeType
    member this.IsNew 
        with get() = m_IsNew
        and  set value =
                m_IsNew <- value
                base.OnChanged(null)
    member this.IsPaid
        with get() = m_IsPaid
        and  set value =
                m_IsPaid <- value
                base.OnChanged(null)
    member this.IncludeShares
        with get() = m_IncludeShares
        and  set value =
                m_IncludeShares <- value
                base.OnChanged(null)

type AttendeesListViewModel() =
    inherit ViewModelBase()
    let attendeesList = ObservableCollection<AttendeeViewModel>()
    member this.AttendeesList 
        with get() = attendeesList
        