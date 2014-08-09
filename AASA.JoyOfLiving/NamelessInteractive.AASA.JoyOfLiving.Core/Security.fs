module NamelessInteractive.AASA.JoyOfLiving.Core.Security

open System

let GenerateHash (value: string) =
    let rand = System.Random()
    let buffer = Array.zeroCreate(rand.Next(5,10))
    rand.NextBytes(buffer)
    let salt = System.Text.UTF8Encoding.UTF8.GetString(buffer,0,buffer.Length)
    let saltLen = salt.Length.ToString()
    saltLen + ":" + salt + NamelessInteractive.Shared.Security.SHA512().ComputeString(value).ToString()


let CompareHash (value: string, actual: string) =
    let saltLen = int (actual.Substring(0, actual.IndexOf(":")))
    let actualUnsalted = actual.Substring(saltLen.ToString().Length + 1 + saltLen)
    let res = NamelessInteractive.Shared.Security.SHA512().ComputeString(value).ToString()
    res = actualUnsalted

