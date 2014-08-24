namespace NamelessInteractive.AASA.JoyOfLiving.Views.ViewModels

open System
open NamelessInteractive.AASA.JoyOfLiving.Core
open NamelessInteractive.AASA.JoyOfLiving.Core.Models


type AttendeeViewModel(attendee: Models.Attendee) =
    inherit ViewModelBase()
    let getResourceNameAttendeeType attendeeType = 
        match attendeeType with
        | Models.AttendeeType.AA -> Xamarin.Forms.ImageSource.FromResource "AA.png"
        | Models.AttendeeType.AACA -> Xamarin.Forms.ImageSource.FromResource "AACA.png"
        | Models.AttendeeType.AlAnon -> Xamarin.Forms.ImageSource.FromResource "AlAnon.png"
        | Models.AttendeeType.AlATeen -> Xamarin.Forms.ImageSource.FromResource "AlATeen.png"
        | Models.AttendeeType.Visitor -> Xamarin.Forms.ImageSource.FromResource "Visitor.png"
        | _ -> Xamarin.Forms.ImageSource.FromResource "AA.png"
    let mutable m_IsNew = true
    let mutable underlyingAttendee = attendee
    new() = AttendeeViewModel(Models.Attendee.Create())
    member this.FirstName
        with get() = underlyingAttendee.FirstName
        and  set value =
                underlyingAttendee.FirstName <- value
                base.OnChanged(null)
                base.OnChanged("DisplayName")
    member this.LastName
        with get() = underlyingAttendee.LastName
        and  set value =
                underlyingAttendee.LastName <- value
                base.OnChanged(null)
                base.OnChanged("DisplayName")
    member this.GroupName
        with get() = underlyingAttendee.GroupName
        and  set value =
                underlyingAttendee.GroupName <- value
                base.OnChanged(null)
    member this.EmailAddress
        with get() = underlyingAttendee.EmailAddress
        and  set value =
                underlyingAttendee.EmailAddress <- value
                base.OnChanged(null)
    member this.TelephoneNumber 
        with get() = underlyingAttendee.TelephoneNumber
        and  set value =
                underlyingAttendee.TelephoneNumber <- value
                base.OnChanged(null)
    member this.AttendeeType 
        with get() = underlyingAttendee.AttendeeType
        and set value =
                underlyingAttendee.AttendeeType <- value
                base.OnChanged(null)
                base.OnChanged("ImageSource")
    member this.DisplayName 
        with get() = this.FirstName + " " + this.LastName.FirstCharOrEmpty()
    member this.ImageSource 
        with get() = 
            getResourceNameAttendeeType underlyingAttendee.AttendeeType
    member this.IsNew 
        with get() = m_IsNew
        and  set value =
                m_IsNew <- value
                base.OnChanged(null)
    member this.IncludeShares
        with get() = underlyingAttendee.IncludeShares
        and  set value =
                underlyingAttendee.IncludeShares <- value
                base.OnChanged(null)
    member this.TShirtSize 
        with get() = underlyingAttendee.TShirtSize
        and  set value =
                underlyingAttendee.TShirtSize <- value
                base.OnChanged(null)
    member this.Attendee 
        with get() = underlyingAttendee
        and set value = 
                underlyingAttendee <- value
                base.OnChanged("FirstName")
                base.OnChanged("LastName")
                base.OnChanged("AttendeeType")
                base.OnChanged("GroupName")
                base.OnChanged("TelephoneNumber")
                base.OnChanged("EmailAddress")
                base.OnChanged("IncludeShares")
                base.OnChanged("TShirtSize")
                base.OnChanged("DisplayName")