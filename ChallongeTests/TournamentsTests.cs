using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challonge.Lib;
using System.Collections.Generic;
using System.IO;
using Helpers.Extensions;
using System.Linq;

namespace ChallongeTests
{
    [TestClass]
    public class Tournaments
    {
        [TestMethod]
        public void Get()
        {
            var q = HttpHelpers.defaultquery;
            //var ret = HttpHelpers.Get(HttpHelpers.urlstem + "tournaments.xml", q);
            var ret = Operations.tournaments(Operations.Result.Xml, Operations.State.Pending);
            LogXML("tournaments", "index", ret);
        }

        [TestMethod]
        public void Create()
        {
            //     "name": name,
            //"url": url,
            //"tournament_type": tournament_type,
            var t = Guid.NewGuid().ToString().Replace("-", "");
            var b = new List<Tuple<string, string>>
                        { 
                            //HttpHelpers.defaultquery.Head,
                            new Tuple<string, string>("tournament[name]", Guid.NewGuid().ToString().Replace("-", "")),
                            new Tuple<string, string>("tournament[url]",t),
                            new Tuple<string, string>("tournament[tournament_type]", "single elimination"),
                            //new Tuple<string, string>("url", "test4xxxx"),
                            //new Tuple<string, string>("tournament_type", "single elimination")
                        };

            var ret = Operations.tournamentcreate(Operations.Result.Xml, b);
            LogXML("tournaments", "create", ret);

        }

        [TestMethod]
        public void Delete()
        {
            var ret = Operations.tournamentdelete(Operations.Result.Xml, "724708");
            LogXML("tournaments", "delete", ret);
        }

        [TestMethod]
        public void Update()
        {

            var bv = new List<Tuple<string, string>>
                         {
                             new Tuple<string, string>("tournament[name]", "stupid test")
                         };

            var ret = Operations.tournamentupdate(Operations.Result.Xml, "724725", bv);
            LogXML("tournaments", "update", ret);
        }

        [TestMethod]
        public void Clean()
        {
            var x = Operations.tournaments(Operations.Result.Xml, Operations.State.Pending);
            var t = TournamentsData.getlistoftournamentinfo(x);

            foreach (var i in t)
            {
                var ret = Operations.tournamentdelete(Operations.Result.Xml, i.Id.ToString());
            }

            
        }

        [TestMethod]
        public void Participants()
        {
            var x = Operations.participants(Operations.Result.Xml, "736345");
            LogXML("participants", "get", x);
        }

        [TestMethod]
        public void Matches()
        {
            var x = Operations.matches(Operations.Result.Xml, "736345", Operations.State.All, "0");
            LogXML("matches", "get", x);
        }

        [TestMethod]
        public void StartTournament()
        {
            var x = Operations.tournamentstart(Operations.Result.Xml, "736345", true, true);
            LogXML("tournament", "start", x);
        }

        const string path = @"..\..\xml\";
        void LogXML(string id, string method, string r)
        {
            try
            {
                File.WriteAllText(path + method + "_" + id + ".xml", r);
            }
            catch
            {
                //just in case
            }
        }
    }
}
