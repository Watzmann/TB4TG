module Challonge.Lib.Operations

open Challonge.Lib.HttpHelpers
open Challonge.Lib.Helpers

type Result = 
         | Xml
         | Json

type State =
         | All
         | Pending
         | Open
         | In_progress
         | Ended

let resulttype t = match t with
                   | Xml -> ".xml"
                   | Json -> ".json"

let incl ip im = defaultquery |> Seq.append (incl ip "include_participants" )|> Seq.append (incl im "include_matches")

let stateq t = match t with
               | All -> [("state", "all")]
               | Pending -> [("state", "pending")]
               | Open -> [("state", "open")]
               | In_progress -> [("state", "in_progress")]
               | Ended -> [("state", "ended")]


let tournaments t s = let url = urlstem + "tournaments" + (resulttype t)
#if DEBUG
                      printfn "%s" url
#endif                 
                      let q = defaultquery |> Seq.append (stateq s)
                      let res = Get url defaultquery
                      res

let tournament t tid ip im = let url = urlstem + "tournaments/" + tid + (resulttype t)                            
#if DEBUG
                             printfn "%s" url
#endif                 
                             let res = Get url (incl ip im)
                             res

let tournamentcreate t bv = let url = urlstem + "tournaments" + (resulttype t)
#if DEBUG
                            printfn "%s" url
#endif                 
                            let res = Post url bv
                            res

let tournamentdelete t tid = let url = urlstem + "tournaments/" + tid + (resulttype t)
#if DEBUG
                             printfn "%s" url
#endif                 
                             let res = Delete url
                             res

let tournamentupdate t tid bv = let url = urlstem + "tournaments/" + tid + (resulttype t)
#if DEBUG
                                printfn "%s" url
#endif                 
                                let res = Put url bv
                                res

let tournamentstart t tid ip im = let url = urlstem + "tournaments/" + tid + "/start" + (resulttype t)
#if DEBUG
                                  printfn "%s" url
#endif                 
                                  let res = Post url (incl ip im)
                                  res

let tournamentfinalize t tid ip = let url = urlstem + "tournaments/" + tid + "/finalize" + (resulttype t)
#if DEBUG
                                  printfn "%s" url
#endif                 
                                  let res = Get url (incl ip false)
                                  res

let tournamentreset t tid ip =  let url = urlstem + "tournaments/" + tid + "/reset" + (resulttype t)
#if DEBUG
                                printfn "%s" url
#endif                 
                                let res = Get url (incl ip false)
                                res

let participants t tid =  let url = urlstem + "tournaments/" + tid + "/participants" + (resulttype t)
#if DEBUG
                          printfn "%s" url
#endif                 
                          let res = Get url defaultquery
                          res

let participantcreate t tid bv = let url = urlstem + "tournaments/" + tid + "/participants" + (resulttype t)
#if DEBUG
                                 printfn "%s" url
#endif                 
                                 let res = Post url bv
                                 res

let participant t tid pid im = let url = urlstem + "tournaments/" + tid + "/participants/" + pid + (resulttype t)
#if DEBUG
                               printfn "%s" url
#endif                 
                               let res = Get url (incl false im)
                               res

let participantupdate t tid pid bv = let url = urlstem + "tournaments/" + tid + "/participants/" + pid + (resulttype t)
#if DEBUG
                                     printfn "%s" url
#endif                 
                                     let res = Put url bv
                                     res

let participantdelete t tid pid = let url = urlstem + "tournaments/" + tid + "/participants/" + pid + (resulttype t)
#if DEBUG
                                  printfn "%s" url
#endif                 
                                  let res = Delete url
                                  res

let participantrandomize t tid  = let url = urlstem + "tournaments/" + tid + "/participants/randomize" + (resulttype t)
#if DEBUG
                                  printfn "%s" url
#endif                 
                                  let res = Get url defaultquery
                                  res

let matches t tid s pid = let url = urlstem + "tournaments/" + tid + "/matches" + (resulttype t)
#if DEBUG
                          printfn "%s" url
#endif                 
                          let res = Get url (defaultquery 
                                             |> Seq.append (match pid with
                                                            | "0" -> []
                                                            | _ -> [ ("participant_id", pid) ] )
                                             |> Seq.append (stateq s))
                          res

let matchone t tid mid = let url = urlstem + "tournaments/" + tid + "/matches/" +  mid + (resulttype t)
#if DEBUG
                         printfn "%s" url
#endif                 
                         let res = Get url defaultquery 
                         res 

let matchupdate t tid mid wpid s = let url = urlstem + "tournaments/" + tid + "/matches/" +  mid + (resulttype t)
#if DEBUG
                                   printfn "%s" url
#endif                 
                                   let res = Put url [ ("match[scores_csv", s); ("match[winner_id]", wpid) ]
                                   res

let subdomain = subdomain