module NamelessInteractive.AASA.JoyOfLiving.Core.ViewModels

open System.ComponentModel
open System.Collections.ObjectModel
open System.Runtime.CompilerServices


let EmptyString = System.String.Empty

type ViewModelBase() =
    let propertyChanged = Event<_, _>()
    member this.OnChanged([<CallerMemberName>]property: string) =
        propertyChanged.Trigger(this, PropertyChangedEventArgs(property))
    interface System.ComponentModel.INotifyPropertyChanged with
        [<CLIEvent>]
        member this.PropertyChanged = propertyChanged.Publish

type AttendeeViewModel() =
    inherit ViewModelBase()
    let mutable m_FirstName = EmptyString
    let mutable m_LastName = EmptyString
    let mutable m_GroupName = EmptyString
    let mutable m_EmailAddress = EmptyString
    let mutable m_TelephoneNumber = EmptyString
    let mutable m_AttendeeType = Models.AA
    member this.FirstName
        with get() = m_FirstName
        and  set value =
                m_FirstName <- value
                base.OnChanged(null)
    member this.LastName
        with get() = m_LastName
        and  set value =
                m_LastName <- value
                base.OnChanged(null)
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

type AttendeesListViewModel() =
    inherit ViewModelBase()
    let attendeesList = ObservableCollection<AttendeeViewModel>()
    member this.AttendeesList 
        with get() = attendeesList
        