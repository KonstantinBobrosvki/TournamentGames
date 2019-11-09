using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TournamentBL;

namespace TournamentBLUnitTestProjec
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var names = new List<string>(10);
            for (int i = 0; i < 10; i++)
            {
                names.Add(RandomString(7));
            }
            Tournament tournament = new Tournament(names.ToArray());
            tournament.CreateRound();

            int z = 0;
        }

        public static string RandomString(int length)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
