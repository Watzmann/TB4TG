module Challonge.Lib.Agents

open Challonge.Lib.Helpers
open Challonge.Lib.DataStructure
open Challonge.Lib.Operations
open Challonge.Lib.TournamentsData
open Challonge.Lib.ParticipantsData

open System
//thx to pck for regexps
type TGMessages = 
     | Tell of string * string
     | Shout of string * string
     | StartGame of string * string * int 
     | ResumeGame of string * string * int
     | WinGame of string * string * int * int * int
     | LeftGame of string * string
     | LogsOut of string
     | LogsIn of string
     | NotUsedForNow of string

let TGMessages str = match str with
                     | ParseRegex "^d02#(.*?)#(.*)" [u; s;] -> Tell(u,s)
                     | ParseRegex "^c02#(.*?) [^:]*: (.*)" [u; s;] -> Shout(u,s)
                     | ParseRegex "(\w*) and (\w*) start a (\d+) point match" [u1; u2; Int m;] -> StartGame(u1, u2, m)
                     | ParseRegex "(\w*) and (\w*) are resuming their (\d+) point match" [u1; u2; Int m] -> ResumeGame(u1, u2, m)
                     | ParseRegex "(\w*) wins a (\d+) point match against (\w*) .(\d+)-(\d+)" [u1; Int m; u2; Int s1; Int s2] -> WinGame(u1, u2, m, s1, s2)
                     | ParseRegex "(\w*) has left the game with (\w*)" [u1; u2] -> LeftGame(u1, u2) 
                     | ParseRegex "^b04#(.*)" [u;] -> LogsOut(u)
                     | ParseRegex "^b01#(.*)" [u;] -> LogsIn(u)
                     | _ -> NotUsedForNow(str)

let t2ts (str:string) = str.Replace("""<?xml version="1.0" encoding="UTF-8"?>""", """<?xml version="1.0" encoding="UTF-8"?><tournaments>""")  + "</tournaments>"
let p2ps (str:string) = str.Replace("""<?xml version="1.0" encoding="UTF-8"?>""", """<?xml version="1.0" encoding="UTF-8"?><participants>""")  + "</participants>"

type Agent<'T> =  MailboxProcessor<'T>

type ChallongeMessage = 
     | TourneysList of State * AsyncReplyChannel<ChallongeReply>
     | Tourney of string * bool * bool * AsyncReplyChannel<ChallongeReply>
     | TourneyCreate of seq<string * string> * AsyncReplyChannel<ChallongeReply>
     | TourneyDelete of string * AsyncReplyChannel<ChallongeReply>
     | TourneyUpdate of string * seq<string * string> * AsyncReplyChannel<ChallongeReply>
     | TourneyStart of string * bool * bool * AsyncReplyChannel<ChallongeReply>
     | TourneyFinalize of string * bool * AsyncReplyChannel<ChallongeReply>
     | TourneyReset of string * bool * AsyncReplyChannel<ChallongeReply>
     | ParticipantsList of string * AsyncReplyChannel<ChallongeReply>
     | ParticipantCreate of string * seq<string * string> * AsyncReplyChannel<ChallongeReply>
     | Participant of string * string * bool * AsyncReplyChannel<ChallongeReply>
     | ParticipantUpdate of string * string * seq<string * string> * AsyncReplyChannel<ChallongeReply>
     | ParticipantDelete of string * string * AsyncReplyChannel<ChallongeReply>
     | ParticipantRandomize of string * AsyncReplyChannel<ChallongeReply>
     | Matches of string * State * string * AsyncReplyChannel<ChallongeReply>
     | MatchOne of string * string * AsyncReplyChannel<ChallongeReply>
     | MatchUpdate of string * string * string * string * AsyncReplyChannel<ChallongeReply>
and ChallongeReply =
    | ReplyMessage of string //Generic one. Remove?
    | List of seq<Tournament>
    | Created of Tournament
    | Deleted of Tournament
    | Registered of seq<Participant>
    | Started of Tournament
    | UnRegistered of seq<Participant>
    | ParticipantList of seq<Participant>
    | Fail of obj

type TigerMessage = 
    | Message of string * AsyncReplyChannel<TigerReply>
and TigerReply =
    //| ReplyMessage of obj //Generic one. Remove?
    | Created of Tournament
    | Deleted of string * Tournament
    | List of string * seq<Tournament> 
    | Registered of string * Participant
    | Started of Tournament
    | UnRegistered of string * Participant
    | UserLoggedOut of string
    | UserLoggedIn of string
    | UsersStartedGame of string * string * int
    | UsersResumedGame of string * string * int
    | UsersLeftGame of string * string 
    | GameResult of string * string * int * int * int
    | UserShouted of string * string 
    | Fail of obj
     
let handle (f,(reply:AsyncReplyChannel<ChallongeReply>)) =
                         try
                            f()
                         with
                         | e -> reply.Reply(ChallongeReply.Fail(e))  

//Secondary agent for doing stuff to challonge
let ChallongeMessageAgent = new Agent<ChallongeMessage>(fun inbox -> 
    let rec Loop() = 
        async {
            let! message = inbox.Receive()
            let handled = match message with
                          | TourneysList(state, replyChannel) -> handle ((fun f -> let res = tournaments Xml state
                                                                                   replyChannel.Reply(ChallongeReply.List(getlistoftournamentinfo res))
                                                                                   f), replyChannel)
                          | Tourney (tid, ip, im, replyChannel) -> handle ((fun f -> let res = tournament Xml tid ip im
                                                                                     replyChannel.Reply(ChallongeReply.ReplyMessage(res))
                                                                                     f), replyChannel)
                          | TourneyCreate(bv, replyChannel) -> handle ((fun f -> let res = tournamentcreate Xml bv
                                                                                 replyChannel.Reply(ChallongeReply.Created(Seq.head (getlistoftournamentinfo (t2ts res))))
                                                                                 f), replyChannel)
                          | TourneyDelete(tid, replyChannel) -> handle ((fun f -> let res = tournamentdelete Xml tid
                                                                                  replyChannel.Reply(ChallongeReply.Deleted(Seq.head(getlistoftournamentinfo (t2ts res))))
                                                                                  f), replyChannel)
                          | TourneyUpdate(tid, bv, replyChannel) -> handle ((fun f -> let res = tournamentupdate Xml tid bv 
                                                                                      replyChannel.Reply(ChallongeReply.ReplyMessage(res))
                                                                                      f), replyChannel)
                          | TourneyStart(tid, ip, im, replyChannel) -> handle ((fun f -> let res = tournamentstart Xml tid ip im
                                                                                         replyChannel.Reply(ChallongeReply.Started(Seq.head (getlistoftournamentinfo (t2ts res))))
                                                                                         f), replyChannel)
                          | TourneyFinalize(tid, ip, replyChannel) -> handle ((fun f -> let res = tournamentfinalize Xml tid ip
                                                                                        replyChannel.Reply(ChallongeReply.ReplyMessage(tid))
                                                                                        f), replyChannel)
                          | TourneyReset(tid, ip, replyChannel) -> handle ((fun f -> let res =  tournamentreset Xml tid ip
                                                                                     replyChannel.Reply(ChallongeReply.ReplyMessage(tid))
                                                                                     f), replyChannel)
                          | ParticipantsList(tid, replyChannel) -> handle ((fun f -> let res = participants Xml tid
                                                                                     replyChannel.Reply(ChallongeReply.ParticipantList(getlistofparticipantsinfo res))
                                                                                     f), replyChannel)
                          | ParticipantCreate(tid, bv, replyChannel) -> handle ((fun f -> let res = participantcreate Xml tid bv
                                                                                          replyChannel.Reply(ChallongeReply.Registered(getlistofparticipantsinfo (p2ps res)))
                                                                                          f), replyChannel)                                                                        
                          | Participant(tid, pid, im, replyChannel) -> handle ((fun f -> let res = participant Xml tid pid im
                                                                                         replyChannel.Reply(ChallongeReply.ParticipantList(getlistofparticipantsinfo (p2ps res)))
                                                                                         f), replyChannel)
                          | ParticipantUpdate(tid, pid, bv, replyChannel) -> handle ((fun f -> let res = participantupdate Xml tid pid bv
                                                                                               replyChannel.Reply(ChallongeReply.ReplyMessage(res))
                                                                                               f), replyChannel)
                          | ParticipantDelete(tid, pid, replyChannel) -> handle ((fun f -> let res = participantdelete Xml tid pid
                                                                                           replyChannel.Reply(ChallongeReply.UnRegistered(getlistofparticipantsinfo (p2ps res)))
                                                                                           f), replyChannel)
                          | ParticipantRandomize(tid, replyChannel) -> handle ((fun f -> let res = participantrandomize Xml tid
                                                                                         replyChannel.Reply(ChallongeReply.ReplyMessage(res))
                                                                                         f), replyChannel)
                          | Matches(tid, s, pid, replyChannel) -> handle ((fun f -> let res = matches Xml tid s pid
                                                                                    replyChannel.Reply(ChallongeReply.ReplyMessage(res))
                                                                                    f), replyChannel)
                          | MatchOne(tid, mid, replyChannel) -> handle ((fun f -> let res = matchone Xml tid mid
                                                                                  replyChannel.Reply(ChallongeReply.ReplyMessage(res))
                                                                                  f), replyChannel)
                          | MatchUpdate(tid, mid, wpid, s, replyChannel) -> handle ((fun f -> let res = matchupdate Xml tid mid wpid s 
                                                                                              replyChannel.Reply(ChallongeReply.ReplyMessage(res))
                                                                                              f), replyChannel)
            //return! handled                                           
            do! Loop()

            }
    Loop())

ChallongeMessageAgent.Start()

let tigerreply (re:AsyncReplyChannel<TigerReply>) (reply:Async<ChallongeReply>) (u:string) = 
   Async.StartWithContinuations(reply,
                                (fun reply ->  match reply with
                                               | ChallongeReply.Created(t) -> re.Reply(Created(t))
                                               | ChallongeReply.List(t) -> re.Reply(List(u,t))
                                               | ChallongeReply.Deleted(t) -> re.Reply(Deleted(u, t))
                                               | ChallongeReply.Registered(ps) -> re.Reply(Registered(u, ps |> Seq.find (fun x -> x.Name.ToLower().Equals(u.ToLower()))))
                                               | ChallongeReply.Started(t) -> re.Reply(Started(t))
                                               | ChallongeReply.UnRegistered(ps) -> re.Reply(UnRegistered(u, ps |> Seq.find (fun x -> x.Name.ToLower().Equals(u.ToLower()))))
                                               | _ -> re.Reply(TigerReply.Fail(reply))),
                                exceptionhandler,
                                cancellationhandler)

let gettournamentinfo tid ip im = let res = ChallongeMessageAgent.PostAndReply(fun reply -> ChallongeMessage.Tourney(tid, ip, im, reply))
                                  match res with
                                  | ChallongeReply.ReplyMessage(t) ->  Seq.head (getlistoftournamentinfo (t2ts t))
                                  | _ -> emptytournament

let gettourneylist = let res = ChallongeMessageAgent.PostAndReply(fun reply -> ChallongeMessage.TourneysList(Pending, reply))
                     match res with
                     | ChallongeReply.List(ts) -> ts
                     | _ -> Seq.empty<Tournament>

let findtourney (id:string) ip im = let i =  id.ToInt
                                    match i with
                                    | 0 -> gettourneylist |> Seq.find(fun x -> x.Name.ToLower().Equals(id.ToLower()))
                                    | _ -> gettournamentinfo id ip im

let getparticipantslist (tid:string) =  let t = findtourney tid false false
                                        let res = ChallongeMessageAgent.PostAndReply(fun reply -> ChallongeMessage.ParticipantsList(t.Id.ToString(), reply))
                                        match res with
                                        | ParticipantList(ps) -> ps
                                        | _ -> Seq.empty<Participant>

let getparticipantinfo tid pid = let res = ChallongeMessageAgent.PostAndReply(fun reply -> ChallongeMessage.Participant(tid, pid, false, reply))
                                 match res with
                                 | ParticipantList(ps) -> Seq.head ( ps)
                                 | _ -> emptyparticipant

let findparticipant tid (pid:string) = let i = pid.ToInt
                                       match i with
                                       | 0 -> getparticipantslist tid |> Seq.find(fun x -> x.Name.ToLower().Equals(pid.ToLower()))
                                       | _ -> getparticipantinfo tid pid

let matchupdate (re:AsyncReplyChannel<TigerReply>) u1 u2 m s1 s2 = 
       let ts1 = gettourneylist State.In_progress //not empty
       if not (Seq.isEmpty ts1) then
          let ts2 = ts1 |> Seq.map(fun x -> gettournamentinfo (x.Id.ToString()) true true) |> Seq.head //should not be more than one though!                                                                       
          if ts2.GameLen = m then
             let ps = ts2.Participants
              //players in tourneys? must find both
             let fp u = Seq.tryFind (fun (x:Participant) -> x.Name = u)
             let p1 = ps |> fp u1
             let p2 = ps |> fp u2
             match p1, p2 with
             | Some(p1), Some(p2) -> 
                  //update matchresults
                let ms = ts2.Matches
                try
                 let m1 = ms |> Seq.find(fun x -> (x.Player1Id = p1.Id && x.Player2Id = p2.Id) ||
                                                  (x.Player1Id = p2.Id && x.Player2Id = p1.Id))
                                                 //matchupdate Xml tid mid wpid s

              //Comma separated set/game scores with player 1 score first (e.g. "1-3,3-0,3-2")
             //Operations.matchupdate(Operations.Result.Xml, "812528", "17642103", "12331404", "1-3");
             //Operations.matchupdate(Operations.Result.Xml, "812528", "17642103", "12331334", "3-1");
                 let csv = match m1.Player1Id with 
                           | x when x = p1.Id -> s1.ToString() + "-" + s2.ToString()
                           | y when y = p2.Id -> s2.ToString() + "-" + s1.ToString()
                           | _ -> ""
                                                                           
                 let res = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> ChallongeMessage.MatchUpdate(ts2.Id.ToString(), m1.Id.ToString(), p1.Id.ToString(), csv, replyC))

                   //check next matches
                    //inform players
                 re.Reply(GameResult(u1, u2, m, s1, s2)) //update match results
                with 
                | e -> Supervisor.Post(SupervisorMessages.Error(e))
                       re.Reply(Fail(e))  
             |_,_-> re.Reply(DontCare("not tourneyresult!"))

                                   
//The main loop and statehandler
let TigerMessageAgent = new Agent<TigerMessage>(fun inbox ->
    let rec Loop() = 
        async {
            let! message = inbox.Receive()
            match message with
            | Message(s,    re) -> match TGMessages s with
                                   //Tell is a string message for commanding the bot woth instructions (c, i)
<<<<<<< HEAD
                                   | Tell(u,s) -> let (c, i, m, f) = command s
                                                  match c,i, m, f with                                                  
                                                  | Some("list"),None,None,None -> let ts = gettourneylist Pending
                                                                                   re.Reply(List(u, ts))
//                                                  | Some("testres1"),None,None,None -> matchupdate re "zbilbo" "someone" 1 3 1
//                                                  | Some("testres2"),None,None,None -> matchupdate re "someone" "zbilbo" 1 3 1
                                                  | Some(i), None, None, None -> re.Reply(CommandWrong(sprintf "not implementer yet? wut? %s" s))                                                                              
                                                  | Some("create"),Some(i),Some(m), Some(f) -> match m, f with
                                                                                               | Int x, Int y -> let bv = [("tournament[name]", i);
                                                                                                                          ("tournament[subdomain]", subdomain);
                                                                                                                          ("tournament[url]", newguidtostring);
                                                                                                                          ("tournament[tournament_type]", "single elimination");
                                                                                                                          ("tournament[description]", m + "," + f + "," + u)]
                                                                                                                 let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> TourneyCreate(bv, replyC))
                                                                                                                 tigerreply re reply u
                                                                                               | _,_ -> re.Reply(CommandWrong("create"))
                                                  | Some(c), Some(i), None, None -> match c with
                                                                                    | "delete" -> let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> TourneyDelete(i, u, replyC)) 
                                                                                                  tigerreply re reply u
//                                                                                    | "list" -> let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> TourneysList(Pending, replyC))
//                                                                                                tigerreply re reply u
                                                                                    | "register" -> let bv = [("participant[name]", u);]
                                                                                                    let tid = findtourney i false false 
                                                                                                    let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> ParticipantCreate(tid.Id.ToString(), bv, replyC))
                                                                                                    tigerreply re reply u
                                                                                    | "start" -> let tid = findtourney i false false 
                                                                                                 let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> TourneyStart(tid.Id.ToString(), true, true, replyC))
=======
                                   | Tell(u,s) -> let (c, i) = command s
                                                  match c,i with 
                                                  | Some(c), Some(i) -> match c,i with
                                                                        | "list",_ -> let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> TourneysList(Pending, replyC))
                                                                                      tigerreply re reply u
                                                                        | _,"" -> re.Reply(Fail("missing info"))
                                                                        | "",_ -> re.Reply(Fail("missing info"))
                                                                        | _,_ -> match c with
                                                                                 | "create" -> let bv = [("tournament[name]", i);
                                                                                                         ("tournament[subdomain]", subdomain);
                                                                                                         ("tournament[url]", newguidtostring);
                                                                                                         ("tournament[tournament_type]", "single elimination") ]
                                                                                               let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> TourneyCreate(bv, replyC))
                                                                                               tigerreply re reply u
                                                                                 | "delete" -> let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> TourneyDelete(i, replyC)) 
                                                                                               tigerreply re reply u
                                                                                 
                                                                                 | "register" -> let bv = [("participant[name]", u);
                                                                                                           ]
                                                                                                 let tid = findtourney i false false 
                                                                                                 let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> ParticipantCreate(tid.Id.ToString(), bv, replyC))
>>>>>>> parent of 17f6a2c... Added some offline changes
                                                                                                 tigerreply re reply u
                                                                                 | "start" -> let tid = findtourney i false false 
                                                                                              let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> TourneyStart(tid.Id.ToString(), true, true, replyC))
                                                                                              tigerreply re reply u
                                                                                              //Do stuff for starting it
                                                                                              // - send messages to contestant
                                                                                              // - send contestants to timer 
                                                                                 | "unregister" -> let pid = findparticipant i u 
                                                                                                   let reply = ChallongeMessageAgent.PostAndAsyncReply(fun replyC -> ParticipantDelete(pid.TournamentId.ToString(), pid.Id.ToString(), replyC))
                                                                                                   tigerreply re reply u
                                                                                 | _ -> re.Reply(Fail(null))
                                                  | _ -> re.Reply(Fail(null))

                                   //The following are "fibs" messages
                                   | Shout(u,s) -> re.Reply(UserShouted(u,s))
                                   | StartGame(u1, u2, m) -> re.Reply(UsersStartedGame(u1, u2, m)) // check for real game or not. warn & start timer if not
                                   | ResumeGame(u1, u2, m) -> re.Reply(UsersResumedGame(u1, u2, m)) // if on timer stop timer
<<<<<<< HEAD
                                   | WinGame(u1, u2, m, s1, s2) ->  matchupdate re u1 u2 m s1 s2 //any tourneys running? u1 wins m-length over u2 (s1-s2)
                                                                    

=======
                                   | WinGame(u1, u2, m, s1, s2) ->  re.Reply(GameResult(u1, u2, m, s1, s2)) //update match results
>>>>>>> parent of 17f6a2c... Added some offline changes
                                   | LogsOut(u) -> re.Reply(UserLoggedOut(u)) //if in tourney start timer
                                   | LogsIn(u) -> re.Reply(UserLoggedIn(u)) //if in tourney warn 
                                   | LeftGame(u1, u2) -> re.Reply(TigerReply.UsersLeftGame(u1, u2))
                                   | _ -> re.Reply(Fail("not used"))
            do! Loop()
            }
    Loop())

TigerMessageAgent.Start()

type SupervisorMessages = 
 | Error of Exception
 | Message of string

let Supervisor = 
   Agent<SupervisorMessages>.Start(fun inbox ->
            let rec Loop() = 
                    async { 
                        let! msg = inbox.Receive()
                        match msg with
                        | Error(err) -> printfn "Supervisor: an error occurred in an agent: %A" err
                        | Message (str) -> printfn "Supervisor: %s" str
                        do! Loop()
                    }
            Loop())
