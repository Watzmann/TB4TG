﻿module  Challonge.Lib.TournamentsData

open System.Linq
open FSharp.Data

open DataStructure

type TournamentsXml = XmlProvider<"""
<tournaments type="array">
  <tournament>
  <accept-attachments type="boolean">false</accept-attachments>
  <allow-participant-match-reporting type="boolean">true</allow-participant-match-reporting>
  <anonymous-voting type="boolean">false</anonymous-voting>
  <category nil="true"/>
  <check-in-at type="datetime" nil="true"/>
  <completed-at type="datetime" nil="true"/>
  <created-at type="datetime">2013-12-14T16:45:27-05:00</created-at>
  <created-by-api type="boolean">true</created-by-api>
  <credit-capped type="boolean">false</credit-capped>
  <description></description>
  <enable-group-stage type="boolean">false</enable-group-stage>
  <game-id type="integer" nil="true"/>
  <hide-forum type="boolean">false</hide-forum>
  <hide-seeds type="boolean">false</hide-seeds>
  <hold-third-place-match type="boolean">false</hold-third-place-match>
  <id type="integer">736345</id>
  <max-predictions-per-user type="integer">1</max-predictions-per-user>
  <name>testing</name>
  <notify-users-when-matches-open type="boolean">true</notify-users-when-matches-open>
  <notify-users-when-the-tournament-ends type="boolean">true</notify-users-when-the-tournament-ends>
  <open-signup type="boolean">false</open-signup>
  <participant-count-to-advance-per-group type="integer" nil="true"/>
  <participants-count type="integer">5</participants-count>
  <prediction-method type="integer">0</prediction-method>
  <predictions-opened-at type="datetime" nil="true"/>
  <private type="boolean">false</private>
  <progress-meter type="integer">0</progress-meter>
  <pts-for-bye type="decimal">1.0</pts-for-bye>
  <pts-for-game-tie type="decimal">0.0</pts-for-game-tie>
  <pts-for-game-win type="decimal">0.0</pts-for-game-win>
  <pts-for-match-tie type="decimal">0.5</pts-for-match-tie>
  <pts-for-match-win type="decimal">1.0</pts-for-match-win>
  <ranked-by nil="true"/>
  <require-score-agreement type="boolean">false</require-score-agreement>
  <rr-pts-for-game-tie type="decimal">0.0</rr-pts-for-game-tie>
  <rr-pts-for-game-win type="decimal">0.0</rr-pts-for-game-win>
  <rr-pts-for-match-tie type="decimal">0.5</rr-pts-for-match-tie>
  <rr-pts-for-match-win type="decimal">1.0</rr-pts-for-match-win>
  <sequential-pairings type="boolean">false</sequential-pairings>
  <show-rounds type="boolean">false</show-rounds>
  <signup-cap type="integer" nil="true"/>
  <signup-requires-account type="boolean">false</signup-requires-account>
  <started-at type="datetime">2013-12-15T17:57:32-05:00</started-at>
  <state>underway</state>
  <swiss-rounds type="integer">0</swiss-rounds>
  <tournament-type>single elimination</tournament-type>
  <updated-at type="datetime">2013-12-15T17:57:32-05:00</updated-at>
  <url>77fd81e430394f38899ced3b6889bd0d</url>
  <description-source></description-source>
  <subdomain nil="true"/>
  <full-challonge-url>http://challonge.com/77fd81e430394f38899ced3b6889bd0d</full-challonge-url>
  <live-image-url>http://images.challonge.com/77fd81e430394f38899ced3b6889bd0d.png</live-image-url>
  <sign-up-url>http://challonge.com/tournaments/signup/ixud8avzev</sign-up-url>
  <review-before-finalizing type="boolean">true</review-before-finalizing>
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
    <participant>
      <active type="boolean">true</active>
      <checked-in type="boolean">false</checked-in>
      <created-at type="datetime">2013-12-14T16:49:34-05:00</created-at>
      <final-rank type="integer" nil="true"/>
      <group-id type="integer" nil="true"/>
      <icon nil="true"/>
      <id type="integer">11249876</id>
      <invitation-id type="integer" nil="true"/>
      <invite-email nil="true"/>
      <misc nil="true"/>
      <name>Zorba</name>
      <on-waiting-list type="boolean">false</on-waiting-list>
      <seed type="integer">3</seed>
      <tournament-id type="integer">736345</tournament-id>
      <updated-at type="datetime">2013-12-14T16:49:34-05:00</updated-at>
      <challonge-username nil="true"/>
      <challonge-email-address-verified nil="true"/>
    </participant>
    <participant>
      <active type="boolean">true</active>
      <checked-in type="boolean">false</checked-in>
      <created-at type="datetime">2013-12-14T16:52:23-05:00</created-at>
      <final-rank type="integer" nil="true"/>
      <group-id type="integer" nil="true"/>
      <icon nil="true"/>
      <id type="integer">11249966</id>
      <invitation-id type="integer" nil="true"/>
      <invite-email nil="true"/>
      <misc nil="true"/>
      <name>Amy</name>
      <on-waiting-list type="boolean">false</on-waiting-list>
      <seed type="integer">4</seed>
      <tournament-id type="integer">736345</tournament-id>
      <updated-at type="datetime">2013-12-14T16:52:23-05:00</updated-at>
      <challonge-username nil="true"/>
      <challonge-email-address-verified nil="true"/>
    </participant>
    <participant>
      <active type="boolean">true</active>
      <checked-in type="boolean">false</checked-in>
      <created-at type="datetime">2013-12-14T17:07:13-05:00</created-at>
      <final-rank type="integer" nil="true"/>
      <group-id type="integer" nil="true"/>
      <icon nil="true"/>
      <id type="integer">11250276</id>
      <invitation-id type="integer" nil="true"/>
      <invite-email nil="true"/>
      <misc nil="true"/>
      <name>hannes</name>
      <on-waiting-list type="boolean">false</on-waiting-list>
      <seed type="integer">5</seed>
      <tournament-id type="integer">736345</tournament-id>
      <updated-at type="datetime">2013-12-14T17:07:13-05:00</updated-at>
      <challonge-username nil="true"/>
      <challonge-email-address-verified nil="true"/>
    </participant>
  </participants>
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
</tournament>
  <tournament>
  <accept-attachments type="boolean">false</accept-attachments>
  <allow-participant-match-reporting type="boolean">true</allow-participant-match-reporting>
  <anonymous-voting type="boolean">false</anonymous-voting>
  <category nil="true"/>
  <check-in-at type="datetime" nil="true"/>
  <completed-at type="datetime" nil="true"/>
  <created-at type="datetime">2013-12-14T16:45:27-05:00</created-at>
  <created-by-api type="boolean">true</created-by-api>
  <credit-capped type="boolean">false</credit-capped>
  <description></description>
  <enable-group-stage type="boolean">false</enable-group-stage>
  <game-id type="integer" nil="true"/>
  <hide-forum type="boolean">false</hide-forum>
  <hide-seeds type="boolean">false</hide-seeds>
  <hold-third-place-match type="boolean">false</hold-third-place-match>
  <id type="integer">736345</id>
  <max-predictions-per-user type="integer">1</max-predictions-per-user>
  <name>testing</name>
  <notify-users-when-matches-open type="boolean">true</notify-users-when-matches-open>
  <notify-users-when-the-tournament-ends type="boolean">true</notify-users-when-the-tournament-ends>
  <open-signup type="boolean">false</open-signup>
  <participant-count-to-advance-per-group type="integer" nil="true"/>
  <participants-count type="integer">5</participants-count>
  <prediction-method type="integer">0</prediction-method>
  <predictions-opened-at type="datetime" nil="true"/>
  <private type="boolean">false</private>
  <progress-meter type="integer">0</progress-meter>
  <pts-for-bye type="decimal">1.0</pts-for-bye>
  <pts-for-game-tie type="decimal">0.0</pts-for-game-tie>
  <pts-for-game-win type="decimal">0.0</pts-for-game-win>
  <pts-for-match-tie type="decimal">0.5</pts-for-match-tie>
  <pts-for-match-win type="decimal">1.0</pts-for-match-win>
  <ranked-by nil="true"/>
  <require-score-agreement type="boolean">false</require-score-agreement>
  <rr-pts-for-game-tie type="decimal">0.0</rr-pts-for-game-tie>
  <rr-pts-for-game-win type="decimal">0.0</rr-pts-for-game-win>
  <rr-pts-for-match-tie type="decimal">0.5</rr-pts-for-match-tie>
  <rr-pts-for-match-win type="decimal">1.0</rr-pts-for-match-win>
  <sequential-pairings type="boolean">false</sequential-pairings>
  <show-rounds type="boolean">false</show-rounds>
  <signup-cap type="integer" nil="true"/>
  <signup-requires-account type="boolean">false</signup-requires-account>
  <started-at type="datetime">2013-12-15T17:57:32-05:00</started-at>
  <state>underway</state>
  <swiss-rounds type="integer">0</swiss-rounds>
  <tournament-type>single elimination</tournament-type>
  <updated-at type="datetime">2013-12-15T17:57:32-05:00</updated-at>
  <url>77fd81e430394f38899ced3b6889bd0d</url>
  <description-source></description-source>
  <subdomain nil="true"/>
  <full-challonge-url>http://challonge.com/77fd81e430394f38899ced3b6889bd0d</full-challonge-url>
  <live-image-url>http://images.challonge.com/77fd81e430394f38899ced3b6889bd0d.png</live-image-url>
  <sign-up-url>http://challonge.com/tournaments/signup/ixud8avzev</sign-up-url>
  <review-before-finalizing type="boolean">true</review-before-finalizing>
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
    <participant>
      <active type="boolean">true</active>
      <checked-in type="boolean">false</checked-in>
      <created-at type="datetime">2013-12-14T16:49:34-05:00</created-at>
      <final-rank type="integer" nil="true"/>
      <group-id type="integer" nil="true"/>
      <icon nil="true"/>
      <id type="integer">11249876</id>
      <invitation-id type="integer" nil="true"/>
      <invite-email nil="true"/>
      <misc nil="true"/>
      <name>Zorba</name>
      <on-waiting-list type="boolean">false</on-waiting-list>
      <seed type="integer">3</seed>
      <tournament-id type="integer">736345</tournament-id>
      <updated-at type="datetime">2013-12-14T16:49:34-05:00</updated-at>
      <challonge-username nil="true"/>
      <challonge-email-address-verified nil="true"/>
    </participant>
    <participant>
      <active type="boolean">true</active>
      <checked-in type="boolean">false</checked-in>
      <created-at type="datetime">2013-12-14T16:52:23-05:00</created-at>
      <final-rank type="integer" nil="true"/>
      <group-id type="integer" nil="true"/>
      <icon nil="true"/>
      <id type="integer">11249966</id>
      <invitation-id type="integer" nil="true"/>
      <invite-email nil="true"/>
      <misc nil="true"/>
      <name>Amy</name>
      <on-waiting-list type="boolean">false</on-waiting-list>
      <seed type="integer">4</seed>
      <tournament-id type="integer">736345</tournament-id>
      <updated-at type="datetime">2013-12-14T16:52:23-05:00</updated-at>
      <challonge-username nil="true"/>
      <challonge-email-address-verified nil="true"/>
    </participant>
    <participant>
      <active type="boolean">true</active>
      <checked-in type="boolean">false</checked-in>
      <created-at type="datetime">2013-12-14T17:07:13-05:00</created-at>
      <final-rank type="integer" nil="true"/>
      <group-id type="integer" nil="true"/>
      <icon nil="true"/>
      <id type="integer">11250276</id>
      <invitation-id type="integer" nil="true"/>
      <invite-email nil="true"/>
      <misc nil="true"/>
      <name>hannes</name>
      <on-waiting-list type="boolean">false</on-waiting-list>
      <seed type="integer">5</seed>
      <tournament-id type="integer">736345</tournament-id>
      <updated-at type="datetime">2013-12-14T17:07:13-05:00</updated-at>
      <challonge-username nil="true"/>
      <challonge-email-address-verified nil="true"/>
    </participant>
  </participants>
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
</tournament>
  <tournament>
    <accept-attachments type="boolean">false</accept-attachments>
    <allow-participant-match-reporting type="boolean">true</allow-participant-match-reporting>
    <anonymous-voting type="boolean">false</anonymous-voting>
    <category nil="true"/>
    <check-in-at type="datetime" nil="true"/>
    <completed-at type="datetime" nil="true"/>
    <created-at type="datetime">2013-12-18T14:15:13-05:00</created-at>
    <created-by-api type="boolean">true</created-by-api>
    <credit-capped type="boolean">false</credit-capped>
    <description></description>
    <enable-group-stage type="boolean">false</enable-group-stage>
    <game-id type="integer" nil="true"/>
    <hide-forum type="boolean">false</hide-forum>
    <hide-seeds type="boolean">false</hide-seeds>
    <hold-third-place-match type="boolean">false</hold-third-place-match>
    <id type="integer">741029</id>
    <max-predictions-per-user type="integer">1</max-predictions-per-user>
    <name>test</name>
    <notify-users-when-matches-open type="boolean">true</notify-users-when-matches-open>
    <notify-users-when-the-tournament-ends type="boolean">true</notify-users-when-the-tournament-ends>
    <open-signup type="boolean">false</open-signup>
    <participant-count-to-advance-per-group type="integer" nil="true"/>
    <participants-count type="integer">0</participants-count>
    <prediction-method type="integer">0</prediction-method>
    <predictions-opened-at type="datetime" nil="true"/>
    <private type="boolean">false</private>
    <progress-meter type="integer">0</progress-meter>
    <pts-for-bye type="decimal">1.0</pts-for-bye>
    <pts-for-game-tie type="decimal">0.0</pts-for-game-tie>
    <pts-for-game-win type="decimal">0.0</pts-for-game-win>
    <pts-for-match-tie type="decimal">0.5</pts-for-match-tie>
    <pts-for-match-win type="decimal">1.0</pts-for-match-win>
    <ranked-by nil="true"/>
    <require-score-agreement type="boolean">false</require-score-agreement>
    <rr-pts-for-game-tie type="decimal">0.0</rr-pts-for-game-tie>
    <rr-pts-for-game-win type="decimal">0.0</rr-pts-for-game-win>
    <rr-pts-for-match-tie type="decimal">0.5</rr-pts-for-match-tie>
    <rr-pts-for-match-win type="decimal">1.0</rr-pts-for-match-win>
    <sequential-pairings type="boolean">false</sequential-pairings>
    <show-rounds type="boolean">false</show-rounds>
    <signup-cap type="integer" nil="true"/>
    <signup-requires-account type="boolean">false</signup-requires-account>
    <started-at type="datetime" nil="true"/>
    <state>pending</state>
    <swiss-rounds type="integer">0</swiss-rounds>
    <tournament-type>single elimination</tournament-type>
    <updated-at type="datetime">2013-12-18T14:15:13-05:00</updated-at>
    <url>d57006c79ab545e1a5db142894cc2442</url>
    <description-source></description-source>
    <subdomain nil="true"/>
    <full-challonge-url>http://challonge.com/d57006c79ab545e1a5db142894cc2442</full-challonge-url>
    <live-image-url>http://images.challonge.com/d57006c79ab545e1a5db142894cc2442.png</live-image-url>
    <sign-up-url>something</sign-up-url>
    <review-before-finalizing type="boolean">true</review-before-finalizing>
  </tournament>
</tournaments>
""">

<<<<<<< HEAD
let getlistoftournamentinfo xml = TournamentsXml.Parse(xml).GetTournaments() |> Seq.choose(fun x-> let mf = match x.Description.IsSome with
                                                                                                            | true -> x.Description.Value.Split(",".ToCharArray())
                                                                                                            | false -> [|"0"; "0"; "";|]
                                                                                                   Some({Tournament.Id = x.Id.Value;
                                                                                                         Tournament.Name = x.Name;
                                                                                                         Tournament.FullUrl = x.FullChallongeUrl;
                                                                                                         Tournament.SignupUrl =  x.SignUpUrl;
                                                                                                         Tournament.GameLen = mf.[0].ToInt;
                                                                                                         Tournament.FinalLen = mf.[1].ToInt;
                                                                                                         Tournament.Owner = mf.[2];
                                                                                                         Participants = match x.Participants.IsSome with
                                                                                                                        | true -> x.Participants.Value.GetParticipants()
                                                                                                                                       |> Seq.choose(fun y-> Some({Participant.Id = y.Id.Value;
                                                                                                                                                                   Participant.Name = y.Name;
                                                                                                                                                                   Participant.TournamentId = y.TournamentId.Value}))
                                                                                                                        | false -> Seq.empty<Participant>
                                                                                                                        ;
                                                                                                         Matches = match x.Matches.IsSome with
                                                                                                                   | true ->  x.Matches.Value.GetMatches() |> Seq.choose(fun z-> Some({Match.Id = z.Id.Value;
                                                                                                                                                                                            Player1Id = z.Player1Id.Value;
                                                                                                                                                                                            Player2Id = z.Player2Id.Value;
                                                                                                                                                                                            Player1PrerequisiteMatchId = (match z.Player1PrereqMatchId.Nil with
                                                                                                                                                                                                                          | Some(true) -> 0
                                                                                                                                                                                                                          | _ -> z.Player1PrereqMatchId.Value);
                                                                                                                                                                                            Player2PrerequisiteMatchId = (match z.Player2PrereqMatchId.Nil with
                                                                                                                                                                                                                          | Some(true) -> 0
                                                                                                                                                                                                                          | _ -> z.Player2PrereqMatchId.Value);
                                                                                                                                                                                            TournamentId = z.TournamentId.Value}))
                                                                                                                   | false -> Seq.empty<Match>
                                                                                                                   ;
                                                                                                         }))
=======
let getlistoftournamentinfo xml = TournamentsXml.Parse(xml).GetTournaments() |> Seq.choose(fun x->   Some({Tournament.Id = x.Id.Value;
                                                                                                   Tournament.Name = x.Name;
                                                                                                   Tournament.FullUrl = x.FullChallongeUrl;
                                                                                                   Tournament.SignupUrl =  x.SignUpUrl;
                                                                                                   Tournament.Owner = "";
                                                                                                   Participants = match x.Participants.IsSome with
                                                                                                                  | true -> x.Participants.Value.GetParticipants()
                                                                                                                                 |> Seq.choose(fun y-> Some({Participant.Id = y.Id.Value;
                                                                                                                                                             Participant.Name = y.Name;
                                                                                                                                                             Participant.TournamentId = y.TournamentId.Value}))
                                                                                                                  | false -> Seq.empty<Participant>
                                                                                                                  ;
                                                                                                   Matches = match x.Matches.IsSome with
                                                                                                             | true ->  x.Matches.Value.GetMatches() |> Seq.choose(fun z-> Some({Match.Id = z.Id.Value;
                                                                                                                                                                                      Player1Id = z.Player1Id.Value;
                                                                                                                                                                                      Player2Id = z.Player2Id.Value;
                                                                                                                                                                                      Player1PrerequisiteMatchId = z.Player1PrereqMatchId.Value;
                                                                                                                                                                                      Player2PrerequisiteMatchId = z.Player2PrereqMatchId.Value;
                                                                                                                                                                                      TournamentId = z.TournamentId.Value}))
                                                                                                             | false -> Seq.empty<Match>
                                                                                                             ;
                                                                                                   }))
>>>>>>> parent of 17f6a2c... Added some offline changes
