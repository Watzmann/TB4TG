module TigerMain

open Challonge.Lib.Config
open Challonge.Lib.Helpers
open Challonge.Lib.Agents
open Challonge.Lib.DataStructure

open FSharp.Net
open System

open WebSocket4Net

[<EntryPoint>]
let main argv =     
    let print str = Supervisor.Post(SupervisorMessages.Message(str))

    TigerMessageAgent.Error.Add(fun e -> Supervisor.Post(SupervisorMessages.Error(e)))
    ChallongeMessageAgent.Error.Add(fun e -> Supervisor.Post(SupervisorMessages.Error(e)))
        
    let h = tg_url;
    let ws = new WebSocket(h, "", null, null, "", "", WebSocketVersion.Rfc6455);
    let login ="login " + tg_username + " " + tg_password
    ws.Opened.Add(fun e -> ws.Send(login))

    //This must be better handled
    ws.Closed.Add(fun e -> print "Lost connection. Trying again"
                           ws.Open())

    let shout str = ws.Send("shout " + str)
//                    str
//    let shout str = ws.Send("tell zbilbo " + str)
    let tell u str = ws.Send("tell " + u + " " + str)
                     //str

    let tourneycreatedstr t = "Tourney '" + t.Name + "' is created. Register with 'tell tourneybot register " + t.Id.ToString() + "' or 'tell tourneybot register " + t.Name + "'. Brackets at " + t.FullUrl
    //let tourneycreatedstr t = "Tourney '".Conc(t.Name, "' is created. Register with 'tell tourneybot register ", t.Id.ToString(),  "' or 'tell tourneybot register ",  t.Name,  "'. Brackets at ",  t.FullUrl)
    let tourneydeletedstr t u = "Tourney '" + t.Name + "' is deleted by " + u + "."
    let tourneylist ts = ts |> Seq.fold(fun acc elem -> acc + elem.Name + " (" + elem.Id.ToString() + "), ") "List of tourneys pending: "
    let tourneyregisteredstr (p:Participant) (u:string) = let t = gettournamentinfo (p.TournamentId.ToString()) false false
                                                          "You have been registered in tourney '" + t.Name  + "' (" + t.Id.ToString() + ")."
    let tourneystartedstr t = "Tourney '" + t.Name + "' is started. Start your matches immediately!"
    let tourneyunregisteredstr (p:Participant) (u:string) = let t = gettournamentinfo (p.TournamentId.ToString()) false false
                                                            "You have been unregistered in tourney '" + t.Name  + "' (" + t.Id.ToString() + ")."
    
    ws.MessageReceived.Add(fun e -> let areply = TigerMessageAgent.PostAndAsyncReply(fun repl -> TigerMessage.Message(e.Message, repl))
                                    Async.StartWithContinuations(areply,
                                                                 (fun reply -> //print (sprintf "%s" e.Message)
                                                                               print (sprintf "%A" reply)
                                                                               match reply with
                                                                               | TigerReply.Created(t) -> tourneycreatedstr t |> shout
                                                                               | TigerReply.List(u, ts) -> (tourneylist ts) |> tell u
                                                                               | TigerReply.Deleted(u, t) -> (tourneydeletedstr t u)|> shout
                                                                               | TigerReply.Registered(u, p) -> tourneyregisteredstr p u |> tell u
                                                                               | TigerReply.Started(t) -> tourneystartedstr t |> shout
                                                                               | TigerReply.UnRegistered(u, p) -> tourneyunregisteredstr p u |> tell u
                                                                               | TigerReply.UserLoggedIn(u) -> ()
                                                                               | TigerReply.UserLoggedOut(u) -> ()
                                                                               | TigerReply.UserShouted(u,s) -> ()
                                                                               | TigerReply.GameResult(u1, u2, m, s1, s2) -> ()
                                                                               | TigerReply.UsersResumedGame(u1, u2, m) -> ()
                                                                               | TigerReply.UsersStartedGame(u1, u2, m) -> ()
                                                                               | TigerReply.UsersLeftGame(u1, u2) -> ()
                                                                               | _ -> reply |> ignore
                                                                               reply |> ignore),
                                                                  (exceptionhandler),
                                                                  (cancellationhandler)))

    ws.Open()

    while true do
        //Do timeing/quering/whatever here?
        () |> ignore
 
    0