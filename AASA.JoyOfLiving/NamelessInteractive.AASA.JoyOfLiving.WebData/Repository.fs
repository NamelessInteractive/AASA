module NamelessInteractive.AASA.JoyOfLiving.WebData.Repositories

open System
open System.Data.SqlServerCe
open NamelessInteractive.AASA.JoyOfLiving.Core.Models

type Repository() =
    member this.Connection() =
        let connectionString = Configuration.ConfigurationManager.ConnectionStrings.["JoyOfLiving"].ConnectionString
        let db = new SqlCeConnection(connectionString)
        db.Open()
        db

type MeetingRepository() =
    inherit Repository()
    member this.GetAll() =
        let result = ResizeArray<Meeting>()
        use connection = base.Connection()
        use command = new SqlCeCommand("Select * from Meetings",connection)
        use reader = command.ExecuteReader()
        while reader.Read() do
            result.Add(
                { 
                    Meeting.Id = reader.GetInt32(reader.GetOrdinal("Id"))
                    Meeting.Name = reader.GetString(reader.GetOrdinal("GroupName"))
                })
        result

type UserRepository() =
    inherit Repository()
    member this.GetAll() =
        let result = ResizeArray<UserDataContract>()
        use connection = base.Connection()
        use command = new SqlCeCommand("Select * from Users", connection)
        use reader = command.ExecuteReader()
        while reader.Read() do
            result.Add(
                {
                    UserDataContract.Id = reader.GetInt32(reader.GetOrdinal("Id"))
                    UserDataContract.EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"))
                })
        result
    member this.GetByEmailAddress(emailAddress: string) =   
        use connection = base.Connection()
        use command = new SqlCeCommand("Select * from Users where emailaddress = @emailAddress", connection)
        command.Parameters.AddWithValue("emaiAddress", emailAddress) |> ignore
        use reader = command.ExecuteReader()
        if reader.HasRows then
            reader.Read() |> ignore
            let result: UserDataContract = 
                    { 
                            Id = reader.GetInt32(reader.GetOrdinal("Id"))
                            EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"))
                    }
            result |> Some
        else
            None

type AttendeRepository() =
    inherit Repository()
    member this.GetAll() =
        let result = ResizeArray<Attendee>()
        use connection = base.Connection()
        use command = new SqlCeCommand("Select * From Attendees")
        use reader = command.ExecuteReader()
        while reader.Read() do
            //TODO: Add Items
            ()
        result

    member this.GetForRegistration(registrationId:int) =
        let result = ResizeArray<AttendeeDataContract>()
        use connection = base.Connection()
        use command = new SqlCeCommand("Select * from Attendees where RegistrationId = @RegistrationId")
        command.Parameters.AddWithValue("RegistrationId", registrationId) |> ignore
        use reader = command.ExecuteReader()
        while reader.Read() do
            // TODO: Add Items
            ()
        result


type RegistrationRepository() =
    inherit Repository()
    member this.GetRegistrationsByEmailAddress(emailAddress) =
        let userRepo = UserRepository()
        match userRepo.GetByEmailAddress(emailAddress) with
        | None -> None
        | Some(user) -> 
            use connection = base.Connection()
            use command = new SqlCeCommand("Select * from Registrations where UserId = @UserId", connection)
            command.Parameters.AddWithValue("UserId", user.Id) |> ignore
            use reader = command.ExecuteReader()
            if reader.HasRows then
                let result = ResizeArray<RegistrationDataContract>()
                while reader.Read() do
                    ()
                Some (result)
            else
                None
                    
