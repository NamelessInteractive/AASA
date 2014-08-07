module NamelessInteractive.AASA.JoyOfLiving.Core.Views

open Xamarin.Forms
open System.Threading.Tasks
open System

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


let private CreateLabelledEntry (labelText) =
    let label = Label(Text=labelText)
    let entry = Entry(Placeholder=labelText)
    label,entry

let private CreateLabelledSwitch (labelText) =
    let stack = StackLayout(Orientation=StackOrientation.Horizontal)
    let label = Label(Text=labelText)
    label.VerticalOptions <- LayoutOptions.CenterAndExpand
    let entry = Switch()
    stack.Children.Add(label)
    stack.Children.Add(entry)
    stack, label, entry

let private WithBoolBinding (bindingPath: string) (stack,label,entry: Switch) =
    entry.SetBinding(Switch.IsToggledProperty, bindingPath)
    stack,label,entry

let private CreateLabelledLabel (labelText) (labelValue) =
    let label1 = Label(Text=labelText)
    label1.Font <- Font.SystemFontOfSize(NamedSize.Large)
    let label2 = Label(Text=labelValue)
    label1,label2

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

let private WithTextBinding (bindingPath: string )(label,entry: Entry) =
    entry.SetBinding(Entry.TextProperty, bindingPath)
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
    CreateLabelledDropDown ("Attendee Type") attendeeTypes |> AddToStack addAttendeeStack
    CreateLabelledEntry("First Name") |> WithTextBinding "FirstName" |> AddToStack addAttendeeStack
    CreateLabelledEntry("Last Name") |> WithTextBinding "LastName" |> AddToStack addAttendeeStack
    CreateLabelledDropDown("Group Name") tmpGroupNames |> AddToStack addAttendeeStack
    CreateEmailEntry() |> WithTextBinding "EmailAddress" |> AddToStack addAttendeeStack
    CreateTelephoneEntry() |> WithTextBinding "TelephoneNumber" |> AddToStack addAttendeeStack
    let includeShares = CreateLabelledSwitch ("Download Shares") |> WithBoolBinding "IncludeShares"
    let incSharesStack,_,_ = includeShares
    addAttendeeStack.Add(incSharesStack)
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
    CreateLabelledLabel "Date:" "2015-04-03 (April 3rd 2015)" |> AddToStack stack
    let conventionStartDate = DateTime(2015,04,03)
    let conventionEndDate = DateTime(2015,04,05)
    let daysToConvention =
        match DateTime.Now < conventionStartDate with
        | true -> ((int (DateTime(2015,04,03) - (DateTime.Now)).TotalDays).ToString())
        | false -> if DateTime.Now <= conventionEndDate then
                    "It's on now!"
                   else
                    "It's already finished"
    CreateLabelledLabel "Days To Convention:" daysToConvention |> AddToStack stack
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
    CreateLabelledLabel "Address:" "Education Campus" |> AddToStack stack
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