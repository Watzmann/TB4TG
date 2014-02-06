module Challonge.Lib.DataStructure

type Participant = { 
                     Name: string;
                     Id: int;
                     TournamentId: int;
                   }

type Match = {
                Id: int;
                Player1Id: int;
                Player2Id: int;
                Player1PrerequisiteMatchId: int;
                Player2PrerequisiteMatchId: int;
                TournamentId: int;
             }

type Tournament = {
                    Id: int;
                    Name: string;
                    FullUrl: string;
                    SignupUrl: string;
                    Owner: string;
                    Participants: seq<Participant>;
                    Matches: seq<Match>;
                  }

let emptytournament = {
                        Tournament.Id=0;
                        Tournament.FullUrl = "";
                        Tournament.Matches = Seq.empty<Match>;
                        Tournament.Name = "";
                        Tournament.Owner = "";
                        Tournament.Participants = Seq.empty<Participant>;
                        Tournament.SignupUrl = "";
                      }

let emptyparticipant = {Participant.Id = 0; Participant.Name=""; Participant.TournamentId=0}