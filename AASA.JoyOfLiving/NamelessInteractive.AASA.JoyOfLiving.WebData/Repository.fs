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
