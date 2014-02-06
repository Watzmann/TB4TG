using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challonge.Lib;

namespace Challonge.Tests
{
    [TestClass]
    public class MatchTest
    {
        [TestMethod]
        public void MatchUpdate()
        {
            var s = Operations.tournament(Operations.Result.Xml, "812528", true, true);

            //12331334: zbilbo
            //12331404: someone

            //<player1-id type="integer">12331334</player1-id>
            //<player2-id type="integer">12331404</player2-id>

            //Comma separated set/game scores with player 1 score first (e.g. "1-3,3-0,3-2")
            Operations.matchupdate(Operations.Result.Xml, "812528", "17642103", "12331404", "1-3");
            Operations.matchupdate(Operations.Result.Xml, "812528", "17642103", "12331334", "3-1");
        }
    }
}
