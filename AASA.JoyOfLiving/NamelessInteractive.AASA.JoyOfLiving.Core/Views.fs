module NamelessInteractive.AASA.JoyOfLiving.Core.Views

open Xamarin.Forms
open System.Threading.Tasks

let attendeesListViewModel = ViewModels.AttendeesListViewModel()

let private CreateTestAttendees() =
    let attendee = ViewModels.AttendeeViewModel()
    attendee.FirstName <- "Bill"
    attendee.LastName <- "Wilson"
    attendee.EmailAddress <- "billw@aa.org"
    attendee.AttendeeType <- Models.AA
    attendee.GroupName <- "New York"
    attendee.TelephoneNumber <- "555-555-5555"
    attendeesListViewModel.AttendeesList.Add(attendee)

let private CreateLabelledEntry (labelText) =
    let label = Label(Text=labelText)
    let entry = Entry(Placeholder=labelText)
    label,entry

let private CreateEmailEntry () =
    let email = CreateLabelledEntry("Email Address")
    let entryPart = snd email
    entryPart.Keyboard <- Keyboard.Email
    email

let private CreateTelephoneEntry () =
    let phone = CreateLabelledEntry("Telephone Number")
    let entryPart = snd phone
    entryPart.Keyboard <- Keyboard.Telephone
    phone

let private CreatePasswordEntry() =
    let password = CreateLabelledEntry("Password")
    let entryPart = snd password
    entryPart.IsPassword <- true
    password

let private CreateLabelledDropDown (labelText) (elements) =
    let label = Label(Text=labelText)
    let entry = Picker()
    elements |> Seq.iter entry.Items.Add
    label,entry

let AddToStack (stack: StackLayout) (v1,v2) =
    stack.Children.Add(v1)
    stack.Children.Add(v2)

type Xamarin.Forms.StackLayout with
    static member Create() = StackLayout()
    static member CreatePadded(padding) = StackLayout(Padding=Thickness(padding))
    static member CreatePadded(padding: int) = StackLayout(Padding=Thickness(float padding))
    static member CreatePaddedCentered(padding) = StackLayout(Padding=Thickness(padding),VerticalOptions = LayoutOptions.Center)
    static member CreatePaddedCentered(padding: int) = StackLayout(Padding=Thickness(float padding),VerticalOptions = LayoutOptions.Center)
    member this.Add(view:View) = this.Children.Add(view)

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
    let page = ContentPage.Create ("Add Attendee", 10)
    let addAttendeeScroll = ScrollView()
    let addAttendeeStack = StackLayout.CreatePadded(5)
    addAttendeeScroll.Content <- addAttendeeStack
    let attendeeTypes = [
                            Models.Constants.AAString
                            Models.Constants.AlAnonString
                            Models.Constants.AACAString
                            Models.Constants.AlATeenString
                            Models.Constants.VisitorString
                        ]
    // TODO: FIX this to use the DB.
    let tmpGroupNames = [
                            "Rosebank"
                            "St Francis"
                            "Pied Piper"
                            "Fellowship of the Spirit"
                        ]
    let attendeeType = CreateLabelledDropDown ("Attendee Type") attendeeTypes |> AddToStack addAttendeeStack
    let firstName = CreateLabelledEntry("First Name") |> AddToStack addAttendeeStack
    let lastName = CreateLabelledEntry("Last Name")|> AddToStack addAttendeeStack
    let group = CreateLabelledDropDown("Group Name") tmpGroupNames |> AddToStack addAttendeeStack
    let email = CreateEmailEntry()|> AddToStack addAttendeeStack
    let telNo = CreateTelephoneEntry()|> AddToStack addAttendeeStack
    let buttonStack = StackLayout.CreatePadded(10)
    buttonStack.Orientation <- StackOrientation.Horizontal
    buttonStack.HorizontalOptions <- LayoutOptions.CenterAndExpand
    let saveButton = Button(Text="Add")
    saveButton.Clicked.Add(fun t -> page.Navigation.PopAsync() |> ignore)
    let cancelButton = Button(Text="Cancel")
    cancelButton.Clicked.Add(fun t -> page.Navigation.PopAsync() |> ignore)
    buttonStack.Add(saveButton)
    buttonStack.Add(cancelButton)
    addAttendeeStack.Add(buttonStack)
    page.Content <- addAttendeeScroll
    page


let RegisterPage = 
    
    let page = ContentPage.Create("Registration",10)
    let content = Label(Text="Payment Part Would Happen Here",VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand)
    page.Content <- content
    page        

let AttendeesListPage = 
    CreateTestAttendees()
    let page = ContentPage.Create("Attendees List",10)
    page.BindingContext <- attendeesListViewModel
    let attendeesStack = StackLayout.CreatePadded(5)
    let attendeesList = ListView()
    attendeesList.SetBinding(ListView.ItemsSourceProperty, Binding("AttendeesList"))
    let addButton  = Button(Text="Add")
    let registerButton  = Button(Text="Register")
    let buttonStack = StackLayout.CreatePadded(5)
    buttonStack.HorizontalOptions <- LayoutOptions.CenterAndExpand
    buttonStack.Orientation <- StackOrientation.Horizontal
    buttonStack.Add(addButton)
    buttonStack.Add(registerButton)
    addButton.Clicked.Add(fun t -> page.Navigation.PushAsync(AddAttendeePage) |> ignore)
    registerButton.Clicked.Add(fun t -> page.Navigation.PushAsync(RegisterPage) |> ignore)
    attendeesStack.Children.Add(attendeesList)
    attendeesStack.Children.Add(buttonStack)
    page.Content <- attendeesStack
    page

   
let StartPage = 
    ContentPage(
        Content = Label(
            Text="Hello Xamarin.Forms!", 
            VerticalOptions = LayoutOptions.CenterAndExpand, 
            HorizontalOptions=LayoutOptions.CenterAndExpand
            )
    )
        
