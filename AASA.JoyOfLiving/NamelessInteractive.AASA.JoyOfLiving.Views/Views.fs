module NamelessInteractive.AASA.JoyOfLiving.Views.Views

open Xamarin.Forms
open System.Threading.Tasks
open System
open NamelessInteractive.Shared
open NamelessInteractive.Shared.Controls
open NamelessInteractive.AASA.JoyOfLiving.Core

let attendeesListViewModel = ViewModels.AttendeesListViewModel()

let private CreateTestAttendees() =
    let aa = new ViewModels.AttendeeViewModel()
    aa.FirstName <- "Bill"
    aa.LastName <- "Wilson"
    aa.EmailAddress <- "billw@aa.org"
    aa.AttendeeType <- Models.AA
    aa.GroupName <- "New York"
    aa.TelephoneNumber <- "555-555-5555"
    aa.IncludeShares <- true
    attendeesListViewModel.AttendeesList.Add(aa)

    let alanon = new ViewModels.AttendeeViewModel()
    alanon.FirstName <- "Lois"
    alanon.LastName <- "Wilson"
    alanon.EmailAddress <- "billw@aa.org"
    alanon.AttendeeType <- Models.AlAnon
    alanon.GroupName <- "Akron"
    alanon.TelephoneNumber <- "555-555-5555"
    attendeesListViewModel.AttendeesList.Add(alanon)

    let alateen = new ViewModels.AttendeeViewModel()
    alateen.FirstName <- "John"
    alateen.LastName <- "Wilson"
    alateen.EmailAddress <- "billw@aa.org"
    alateen.AttendeeType <- Models.AlATeen
    alateen.GroupName <- "Boston"
    alateen.TelephoneNumber <- "555-555-5555"
    attendeesListViewModel.AttendeesList.Add(alateen)

    let aaca = new ViewModels.AttendeeViewModel()
    aaca.FirstName <- "Woodrow"
    aaca.LastName <- "Wilson"
    aaca.EmailAddress <- "billw@aa.org"
    aaca.AttendeeType <- Models.AACA
    aaca.GroupName <- "Boston"
    aaca.TelephoneNumber <- "555-555-5555"
    attendeesListViewModel.AttendeesList.Add(aaca)

    let visitor = new ViewModels.AttendeeViewModel()
    visitor.FirstName <- "Sandy"
    visitor.LastName <- "Wilson"
    visitor.EmailAddress <- "billw@aa.org"
    visitor.AttendeeType <- Models.Visitor
    visitor.GroupName <- "Boston"
    visitor.TelephoneNumber <- "555-555-5555"
    attendeesListViewModel.AttendeesList.Add(visitor)

let private CreateEmailEntry () =
    let email = CreateLabelledEntry("Email Address")
    let entryPart = email.Children.[1] :?> Entry
    entryPart.Keyboard <- Keyboard.Email
    email

let private CreateTelephoneEntry () =
    let phone = CreateLabelledEntry("Telephone Number")
    let entryPart = phone.Children.[1] :?> Entry
    entryPart.Keyboard <- Keyboard.Telephone
    phone

let private CreatePasswordEntry() =
    let password = CreateLabelledEntry("Password")
    let entryPart = password.Children.[1] :?> Entry
    entryPart.IsPassword <- true
    password

let LoginPage =     
    let loginStack = StackLayout.CreatePaddedCentered(5)
    CreateEmailEntry() |> AndAddToStack loginStack
    CreatePasswordEntry() |> AndAddToStack loginStack
    let buttonStack = StackLayout()
    buttonStack.Orientation <- StackOrientation.Horizontal
    buttonStack.HorizontalOptions <- LayoutOptions.Center
    buttonStack.Add(Button(Text="Login"))
    buttonStack.Add(Button(Text="Register"))
    loginStack.Add(buttonStack)
    ContentPage.Create ("Login", 5, loginStack)

let thrd (_,_,x) = x

let awaitTask (t: Task) = t |> Async.AwaitIAsyncResult |> Async.Ignore |> Async.Start

let AddAttendeePage(attendee: ViewModels.AttendeeViewModel option) =
    let boundAttendee = 
        match attendee with
        | Some(attendee) -> attendee
        | None -> ViewModels.AttendeeViewModel()
    let page = ContentPage.Create ("Add / Edit Attendee", 10)
    page.BindingContext <- boundAttendee
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
    CreateLabelledDropDown ("Attendee Type") attendeeTypes |> AndAddToStack addAttendeeStack
    CreateLabelledEntry("First Name") |> WithTextEntryBinding "FirstName" |> AndAddToStack addAttendeeStack
    CreateLabelledEntry("Last Name") |> WithTextEntryBinding "LastName" |> AndAddToStack addAttendeeStack
    CreateLabelledDropDown("Group Name") tmpGroupNames |> AndAddToStack addAttendeeStack
    CreateEmailEntry() |> WithTextEntryBinding "EmailAddress" |> AndAddToStack addAttendeeStack
    CreateTelephoneEntry() |> WithTextEntryBinding "TelephoneNumber" |> AndAddToStack addAttendeeStack
    CreateLabelledSwitch ("Download Shares") |> WithSwitchBinding "IncludeShares" |> AndAddToStack addAttendeeStack
    let buttonStack = StackLayout.CreatePadded(10)
    buttonStack.Orientation <- StackOrientation.Horizontal
    buttonStack.HorizontalOptions <- LayoutOptions.CenterAndExpand
    let saveButton = Button(Text="Save")
    saveButton.Clicked.Add(fun t -> awaitTask (page.Navigation.PopAsync()))
    let cancelButton = Button(Text="Cancel")
    cancelButton.Clicked.Add(fun t -> awaitTask (page.Navigation.PopAsync()))
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

type AttendeeDT() = 
    inherit ViewCell()
    do 
        let stack = StackLayout(Orientation=StackOrientation.Horizontal)
        let innerStack = StackLayout()
        let name = Label()      
        name.Font <- Font.SystemFontOfSize(NamedSize.Large)
        let groupName = Label()
        let img = Image(WidthRequest=60.0, HeightRequest=60.0)
        innerStack.Add(name)    
        innerStack.Add(groupName)
        stack.Add(img)
        stack.Add(innerStack)
        img.SetBinding(Image.SourceProperty,"ImageSource")
        groupName.SetBinding(Label.TextProperty,"GroupName")
        name.SetBinding(Label.TextProperty, "DisplayName")
        base.View <- stack

let AttendeesListPage() = 
    CreateTestAttendees()
    let page = ContentPage.Create("Attendees List",10)
    page.BindingContext <- attendeesListViewModel
    let attendeesStack = StackLayout.CreatePadded(5)
    let attendeesList = ListView()
    if (Device.OS = TargetPlatform.WinPhone) then
        attendeesList.RowHeight <- 100
    else
        attendeesList.RowHeight <- 60
    let addButton  = Button(Text="Add")
    let registerButton  = Button(Text="Register")
    let buttonStack = StackLayout.CreatePadded(5)
    buttonStack.HorizontalOptions <- LayoutOptions.CenterAndExpand
    buttonStack.Orientation <- StackOrientation.Horizontal
    buttonStack.Add(addButton)
    buttonStack.Add(registerButton)
    addButton.Clicked.Add(fun t -> (awaitTask (page.Navigation.PushAsync(AddAttendeePage None))))
    registerButton.Clicked.Add(fun t -> awaitTask (page.Navigation.PushAsync(RegisterPage)))
    attendeesStack.Children.Add(attendeesList)
    attendeesStack.Children.Add(buttonStack)
    page.Content <- attendeesStack
    attendeesList.ItemsSource <- attendeesListViewModel.AttendeesList
    attendeesList.ItemTemplate <- DataTemplate(typeof<AttendeeDT>)
    attendeesList.ItemTapped.Add(fun t -> awaitTask (page.Navigation.PushAsync(t.Item :?> ViewModels.AttendeeViewModel |> Some |> AddAttendeePage)))
    page

let InformationPage() =
    let blurb = "In 2015, the Johannesburg West Rand Area (JWRA) of Alcoholics Anonymous South Africa will be hosting the Annual South African Convention of Alcoholics Anonymous (Jozi 2015). The convention will take place over the Easter weekend (3rd to the 5th of April). The convention is an opportunity to bring together members from AA, Al-Anon, Al-ATeen, AACA and members of the public for fellowship, sharing and fun, embracing the theme of the convention, which will be 'The Joy of Living'.
    \n\
    2015 will also be the 80th aniversary of the founding of Alcoholics Anonymous.
    \n\
    We are pleased to provide you with this app to provide you with the means to register, download shares and receive information on the convention, accomodation as well as the address of the convention."
    let page = ContentPage.Create("Information")
    let stack = StackLayout.CreatePadded(20)
    CreateLabelledLabel "Date:" "2015-04-03 (April 3rd 2015)" |> AndAddToStack stack
    let conventionStartDate = DateTime(2015,04,03)
    let conventionEndDate = DateTime(2015,04,05)
    let daysToConvention =
        match DateTime.Now < conventionStartDate with
        | true -> ((int (DateTime(2015,04,03) - (DateTime.Now)).TotalDays).ToString())
        | false -> if DateTime.Now <= conventionEndDate then
                    "It's on now!"
                   else
                    "It's already finished"
    CreateLabelledLabel "Days To Convention:" daysToConvention |> AndAddToStack stack
    let blurbLabel = Label(Text=blurb)
    blurbLabel.TranslationY <- 10.0
    stack.Add(blurbLabel)
    page.Content <- ScrollView(Content=stack)
    page

let VenuePage() =
    let page = ContentPage.Create("Venue")
    let stack = StackLayout.CreatePadded(20)
    let scroll = ScrollView()
    scroll.Content <- stack
    CreateLabelledLabel "Address:" "Education Campus" |> AndAddToStack stack
    stack.Add(Label(Text="University of the Witwatersrand"))
    stack.Add(Label(Text="27 St Andrews Road,"))
    stack.Add(Label(Text="Parktown,"))
    stack.Add(Label(Text="2193"))
    stack.Add(Label(Text="Map To Venue", Font=Font.SystemFontOfSize(NamedSize.Large)))
    stack.Add(Label(Text="Map Of Venue", Font=Font.SystemFontOfSize(NamedSize.Large)))
    let venueMapImg = Image()
    venueMapImg.Source <- ImageSource.FromResource("VenueMap.png")
    stack.Add(venueMapImg)
    page.Content <- scroll
    page

let SharesPage() =
    let page = ContentPage.Create("Shares")
    page.Content <- Label(Text="No shares available for download yet. Please wait until the convention starts.")
    page
   
let StartPage() = 
    let tabPage = TabbedPage()
    let informationTab = InformationPage()
    let attendeesTab = AttendeesListPage()
    let venueTab = VenuePage()
    let sharesTab = SharesPage()
    tabPage.Children.Add(informationTab)
    tabPage.Children.Add(attendeesTab)
    tabPage.Children.Add(sharesTab)
    tabPage.Children.Add(venueTab)
    tabPage

