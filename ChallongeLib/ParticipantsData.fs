module Challonge.Lib.ParticipantsData
open System.Linq
open FSharp.Data

open DataStructure

type ParticipantsXml = XmlProvider<"""
<participants type="array">
  <participant>
    <active type="boolean">true</active>
    <checked-in type="boolean">false</checked-in>
    <created-at type="datetime">2013-12-14T16:46:14-05:00</created-at>
    <final-rank type="integer" nil="true"/>
    <group-id type="integer" nil="true"/>
    <icon nil="true"/>
    <id type="integer">11249557</id>
    <invitation-id type="integer" nil="true"/>
    <invite-email nil="true"/>
    <misc nil="true"/>
    <name>zbilbo</name>
    <on-waiting-list type="boolean">false</on-waiting-list>
    <seed type="integer">1</seed>
    <tournament-id type="integer">736345</tournament-id>
    <updated-at type="datetime">2013-12-14T16:46:14-05:00</updated-at>
    <challonge-username nil="true"/>
    <challonge-email-address-verified nil="true"/>
  </participant>
  <participant>
    <active type="boolean">true</active>
    <checked-in type="boolean">false</checked-in>
    <created-at type="datetime">2013-12-14T16:49:25-05:00</created-at>
    <final-rank type="integer" nil="true"/>
    <group-id type="integer" nil="true"/>
    <icon nil="true"/>
    <id type="integer">11249871</id>
    <invitation-id type="integer" nil="true"/>
    <invite-email nil="true"/>
    <misc nil="true"/>
    <name>pck</name>
    <on-waiting-list type="boolean">false</on-waiting-list>
    <seed type="integer">2</seed>
    <tournament-id type="integer">736345</tournament-id>
    <updated-at type="datetime">2013-12-14T16:49:25-05:00</updated-at>
    <challonge-username nil="true"/>
    <challonge-email-address-verified nil="true"/>
  </participant>
</participants>
""">

let getlistofparticipantsinfo xml = ParticipantsXml.Parse(xml).GetParticipants() |> Seq.choose(fun x-> Some({
                                                                                                                Participant.Id = x.Id.Value;
                                                                                                                Participant.Name = x.Name;
                                                                                                                Participant.TournamentId = x.TournamentId.Value;
                                                                                                            }))


