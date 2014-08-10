namespace NamelessInteractive.AASA.JoyOfLiving.Views.ViewModels

open System
open NamelessInteractive.AASA.JoyOfLiving.Core.Models

type LoginViewModel() = 
    inherit ViewModelBase()
    let mutable m_EmailAddress = EmptyString
    let mutable m_Password = EmptyString
    member this.EmailAddress
        with get() = m_EmailAddress
        and set value = 
            m_EmailAddress <- value
            base.OnChanged(null)
    member this.Password 
        with get() = m_Password
        and set value =
            m_Password <- value
            base.OnChanged(null)
