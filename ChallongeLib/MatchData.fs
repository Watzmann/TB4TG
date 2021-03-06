﻿module  Challonge.Lib.MatchData

open System.Linq
open FSharp.Data

open DataStructure


type MatchesXml = XmlProvider<"""
<matches type="array">
  <match>
    <attachment-count type="integer" nil="true"/>
    <created-at type="datetime">2013-12-15T17:57:32-05:00</created-at>
    <group-id type="integer" nil="true"/>
    <has-attachment type="boolean">false</has-attachment>
    <id type="integer">16204905</id>
    <identifier>A</identifier>
    <loser-id type="integer" nil="true"/>
    <player1-id type="integer">11249966</player1-id>
    <player1-is-prereq-match-loser type="boolean">false</player1-is-prereq-match-loser>
    <player1-prereq-match-id type="integer" nil="true"/>
    <player1-votes type="integer" nil="true"/>
    <player2-id type="integer">11250276</player2-id>
    <player2-is-prereq-match-loser type="boolean">false</player2-is-prereq-match-loser>
    <player2-prereq-match-id type="integer" nil="true"/>
    <player2-votes type="integer" nil="true"/>
    <round type="integer">1</round>
    <started-at type="datetime">2013-12-15T17:57:32-05:00</started-at>
    <state>open</state>
    <tournament-id type="integer">736345</tournament-id>
    <updated-at type="datetime">2013-12-15T17:57:32-05:00</updated-at>
    <winner-id type="integer" nil="true"/>
    <prerequisite-match-ids-csv></prerequisite-match-ids-csv>
    <scores-csv></scores-csv>
  </match>
  <match>
    <attachment-count type="integer" nil="true"/>
    <created-at type="datetime">2013-12-15T17:57:32-05:00</created-at>
    <group-id type="integer" nil="true"/>
    <has-attachment type="boolean">false</has-attachment>
    <id type="integer">16204906</id>
    <identifier>B</identifier>
    <loser-id type="integer" nil="true"/>
    <player1-id type="integer">11249557</player1-id>
    <player1-is-prereq-match-loser type="boolean">false</player1-is-prereq-match-loser>
    <player1-prereq-match-id type="integer" nil="true"/>
    <player1-votes type="integer" nil="true"/>
    <player2-id type="integer" nil="true"/>
    <player2-is-prereq-match-loser type="boolean">false</player2-is-prereq-match-loser>
    <player2-prereq-match-id type="integer">16204905</player2-prereq-match-id>
    <player2-votes type="integer" nil="true"/>
    <round type="integer">2</round>
    <started-at type="datetime" nil="true"/>
    <state>pending</state>
    <tournament-id type="integer">736345</tournament-id>
    <updated-at type="datetime">2013-12-15T17:57:32-05:00</updated-at>
    <winner-id type="integer" nil="true"/>
    <prerequisite-match-ids-csv>16204905</prerequisite-match-ids-csv>
    <scores-csv></scores-csv>
  </match>
  <match>
    <attachment-count type="integer" nil="true"/>
    <created-at type="datetime">2013-12-15T17:57:32-05:00</created-at>
    <group-id type="integer" nil="true"/>
    <has-attachment type="boolean">false</has-attachment>
    <id type="integer">16204907</id>
    <identifier>C</identifier>
    <loser-id type="integer" nil="true"/>
    <player1-id type="integer">11249871</player1-id>
    <player1-is-prereq-match-loser type="boolean">false</player1-is-prereq-match-loser>
    <player1-prereq-match-id type="integer" nil="true"/>
    <player1-votes type="integer" nil="true"/>
    <player2-id type="integer">11249876</player2-id>
    <player2-is-prereq-match-loser type="boolean">false</player2-is-prereq-match-loser>
    <player2-prereq-match-id type="integer" nil="true"/>
    <player2-votes type="integer" nil="true"/>
    <round type="integer">2</round>
    <started-at type="datetime">2013-12-15T17:57:32-05:00</started-at>
    <state>open</state>
    <tournament-id type="integer">736345</tournament-id>
    <updated-at type="datetime">2013-12-15T17:57:32-05:00</updated-at>
    <winner-id type="integer" nil="true"/>
    <prerequisite-match-ids-csv></prerequisite-match-ids-csv>
    <scores-csv></scores-csv>
  </match>
  <match>
    <attachment-count type="integer" nil="true"/>
    <created-at type="datetime">2013-12-15T17:57:32-05:00</created-at>
    <group-id type="integer" nil="true"/>
    <has-attachment type="boolean">false</has-attachment>
    <id type="integer">16204908</id>
    <identifier>D</identifier>
    <loser-id type="integer" nil="true"/>
    <player1-id type="integer" nil="true"/>
    <player1-is-prereq-match-loser type="boolean">false</player1-is-prereq-match-loser>
    <player1-prereq-match-id type="integer">16204906</player1-prereq-match-id>
    <player1-votes type="integer" nil="true"/>
    <player2-id type="integer" nil="true"/>
    <player2-is-prereq-match-loser type="boolean">false</player2-is-prereq-match-loser>
    <player2-prereq-match-id type="integer">16204907</player2-prereq-match-id>
    <player2-votes type="integer" nil="true"/>
    <round type="integer">3</round>
    <started-at type="datetime" nil="true"/>
    <state>pending</state>
    <tournament-id type="integer">736345</tournament-id>
    <updated-at type="datetime">2013-12-15T17:57:32-05:00</updated-at>
    <winner-id type="integer" nil="true"/>
    <prerequisite-match-ids-csv>16204906,16204907</prerequisite-match-ids-csv>
    <scores-csv></scores-csv>
  </match>
</matches>
"""
>

let getlistofmatchesinfo xml = MatchesXml.Parse(xml).GetMatches() |> Seq.choose(fun z-> Some({Match.Id = z.Id.Value;
                                                                                                Player1Id = z.Player1Id.Value;
                                                                                                Player2Id = z.Player2Id.Value;
                                                                                                Player1PrerequisiteMatchId = z.Player1PrereqMatchId.Value;
                                                                                                Player2PrerequisiteMatchId = z.Player2PrereqMatchId.Value;
                                                                                                TournamentId = z.TournamentId.Value; }))

