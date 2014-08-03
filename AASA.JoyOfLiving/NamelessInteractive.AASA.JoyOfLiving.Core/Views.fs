module NamelessInteractive.AASA.JoyOfLiving.Core.Views

open Xamarin.Forms

let private CreateLabelledEntry (labelText) =
    let label = Label(Text=labelText)
    let entry = Entry(Placeholder=labelText)
    label,entry

let private CreateEmailEntry () =
    let email = CreateLabelledEntry("Email Address")
    let entryPart = snd email
    entryPart.Keyboard <- Keyboard.Email
    email

let private CreatePasswordEntry() =
    let password = CreateLabelledEntry("Password")
    let entryPart = snd password
    entryPart.IsPassword <- true
    password

type Xamarin.Forms.StackLayout with
    static member Create() = StackLayout()
    static member CreatePadded(padding) = StackLayout(Padding=Thickness(padding))
    static member CreatePadded(padding: int) = StackLayout(Padding=Thickness(float padding))
    static member CreatePaddedCentered(padding) = StackLayout(Padding=Thickness(padding),VerticalOptions = LayoutOptions.Center)
    static member CreatePaddedCentered(padding: int) = StackLayout(Padding=Thickness(float padding),VerticalOptions = LayoutOptions.Center)

type Xamarin.Forms.ContentPage with
    static member Create() = ContentPage()
    static member Create title = ContentPage(Title=title)
    static member Create (title, padding) = ContentPage(Title=title, Padding=Thickness(padding))
    static member Create (title,padding:int) = ContentPage(Title=title, Padding=Thickness(float padding))
    static member Create (title,padding, content) = ContentPage(Title=title, Padding=Thickness(padding), Content=content)
    static member Create (title, padding:int, content) = ContentPage(Title=title, Padding=Thickness(float padding), Content=content)

let LoginPage =     
    let loginStack = StackLayout.CreatePaddedCentered(5)
    let email = CreateEmailEntry()
    loginStack.Children.Add(fst email)
    loginStack.Children.Add(snd email)
    let password = CreatePasswordEntry()
    loginStack.Children.Add(fst password)
    loginStack.Children.Add(snd password)
    let buttonStack = StackLayout()
    buttonStack.Orientation <- StackOrientation.Horizontal
    buttonStack.HorizontalOptions <- LayoutOptions.Center
    buttonStack.Children.Add(Button(Text="Login"))
    buttonStack.Children.Add(Button(Text="Register"))
    loginStack.Children.Add(buttonStack)
    ContentPage.Create ("Login", 5, loginStack)

let AddAttendeePage =
    let addAttendeeStack = StackLayout.CreatePadded(5)
    ContentPage.Create ("Add Attendee", 10, addAttendeeStack)
   
let StartPage = 
    ContentPage(
        Content = Label(
            Text="Hello Xamarin.Forms!", 
            VerticalOptions = LayoutOptions.CenterAndExpand, 
            HorizontalOptions=LayoutOptions.CenterAndExpand
            )
    )
        
