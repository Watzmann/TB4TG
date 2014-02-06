module Challonge.Lib.Helpers

open System.Text.RegularExpressions
open System

let incl i s = match i with
               | true -> [ (s, "1") ]
               | false -> [ ]


let (|ParseRegex|_|) regex str =
   let m = Regex(regex).Match(str)
   if m.Success
   then Some (List.tail [ for x in m.Groups -> x.Value ])
   else None


let (|Int|_|) str =
   match System.Int32.TryParse(str) with
   | (true,int) -> Some(int)
   | _ -> None

//let (|IntOrZero|_|) (i: int option) = match i with
//                                      | Some(a) -> a
//                                      | None -> 0

let command s = match s with
                | ParseRegex "(\w*)\s(\w*)" [c; i;] -> Some(c), Some(i)
                | _ -> None, None

let newguidtostring = Guid.NewGuid().ToString().Replace("-", "")

type System.String with
 member this.ToInt = match this with
                     | Int i ->  i
                     | _ -> 0


type System.String with
 member this.Conc([<ParamArray>] args: string[]) = args |> Seq.fold (fun acc elem -> acc + elem) this

let conc ([<ParamArray>] args: string[]) = args |> Seq.fold (fun acc elem -> acc + elem) String.Empty

let exceptionhandler _ =  printfn "was exception"
                          //()

let cancellationhandler _ = printfn "was cancelled"
                            //()


//let (|Error|_|) m = match m with
//                    | Fail e -> Some(e)
//                    | _ -> None