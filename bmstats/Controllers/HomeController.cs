using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Mvc;
using bmstats.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SteamWebAPI2;
using SteamWebAPI2.Utilities;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Models;

namespace bmstats.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Scoreboard()
        {
            PopulateMasterList();
            await GetAvatars();

            return View(MasterList);
        }

        public List<PlayerRow> MasterList = new List<PlayerRow>();
        List<ulong> AvatarList = new List<ulong>();

        public void PopulateMasterList()
        {
            string constr = ConfigurationManager.AppSettings["MySQLConnStr"];
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM `rankme`";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            MasterList.Add(new PlayerRow
                            {
                                TableID = rdr["id"].ToString(),
                                LegacySteamID = rdr["steam"].ToString(),
                                Steam64 = ConvertToSteam64(rdr["steam"].ToString()),
                                Name = rdr["name"].ToString(),
                                IP = rdr["lastip"].ToString(),
                                Score = Convert.ToInt32(rdr["score"]),
                                Kills = Convert.ToInt32(rdr["kills"]),
                                Deaths = Convert.ToInt32(rdr["deaths"]),
                                Assists = Convert.ToInt32(rdr["assists"]),
                                Suicides = Convert.ToInt32(rdr["suicides"]),
                                Teamkills = Convert.ToInt32(rdr["tk"]),
                                ShotsFired = Convert.ToInt32(rdr["shots"]),
                                ShotsHit = Convert.ToInt32(rdr["hits"]),
                                HeadShots = Convert.ToInt32(rdr["headshots"]),
                                PlayTime = Convert.ToInt32(rdr["connected"]),
                                RoundsPlayedAsT = Convert.ToInt32(rdr["rounds_tr"]),
                                RoundsPlayedAsCT = Convert.ToInt32(rdr["rounds_ct"]),
                                LastConnected = Convert.ToInt32(rdr["lastconnect"]),

                                KnifeKills = Convert.ToInt32(rdr["knife"]),
                                GlockKills = Convert.ToInt32(rdr["glock"]),
                                P2000Kills = Convert.ToInt32(rdr["hkp2000"]),
                                USPKills = Convert.ToInt32(rdr["usp_silencer"]),
                                P250Kills = Convert.ToInt32(rdr["p250"]),
                                DeagleKills = Convert.ToInt32(rdr["deagle"]),
                                EliteKills = Convert.ToInt32(rdr["elite"]),
                                FivesevenKills = Convert.ToInt32(rdr["fiveseven"]),
                                Tec9Kills = Convert.ToInt32(rdr["tec9"]),
                                CZ75Kills = Convert.ToInt32(rdr["cz75a"]),
                                RevolverKills = Convert.ToInt32(rdr["revolver"]),
                                NovaKills = Convert.ToInt32(rdr["nova"]),
                                XM1014Kills = Convert.ToInt32(rdr["xm1014"]),
                                Mag7Kills = Convert.ToInt32(rdr["mag7"]),
                                SawedoffKills = Convert.ToInt32(rdr["sawedoff"]),
                                BizonKills = Convert.ToInt32(rdr["bizon"]),
                                Mac10Kills = Convert.ToInt32(rdr["mac10"]),
                                Mp9Kills = Convert.ToInt32(rdr["mp9"]),
                                Mp7Kills = Convert.ToInt32(rdr["mp7"]),
                                Ump45Kills = Convert.ToInt32(rdr["ump45"]),
                                P90Kills = Convert.ToInt32(rdr["p90"]),
                                GalilKills = Convert.ToInt32(rdr["galilar"]),
                                AK47Kills = Convert.ToInt32(rdr["ak47"]),
                                Scar20Kills = Convert.ToInt32(rdr["scar20"]),
                                FamasKills = Convert.ToInt32(rdr["famas"]),
                                M4A4Kills = Convert.ToInt32(rdr["m4a1"]),
                                M4A1SKills = Convert.ToInt32(rdr["m4a1_silencer"]),
                                AugKills = Convert.ToInt32(rdr["aug"]),
                                ScoutKills = Convert.ToInt32(rdr["ssg08"]),
                                SG556Kills = Convert.ToInt32(rdr["sg556"]),
                                AWPKills = Convert.ToInt32(rdr["awp"]),
                                G3SG1Kills = Convert.ToInt32(rdr["g3sg1"]),
                                M249Kills = Convert.ToInt32(rdr["m249"]),
                                NegevKills = Convert.ToInt32(rdr["negev"]),
                                GrenadeKills = Convert.ToInt32(rdr["hegrenade"]),
                                FlashbangKills = Convert.ToInt32(rdr["flashbang"]),
                                SmokegrenadeKills = Convert.ToInt32(rdr["smokegrenade"]),
                                MolotovKills = Convert.ToInt32(rdr["inferno"]),
                                DecoyKills = Convert.ToInt32(rdr["decoy"]),
                                TaserKills = Convert.ToInt32(rdr["taser"]),
                                Mp5Kills = Convert.ToInt32(rdr["mp5sd"]),
                                BreachChargeKills = Convert.ToInt32(rdr["breachcharge"]),

                                HeadHits = Convert.ToInt32(rdr["head"]),
                                ChestHits = Convert.ToInt32(rdr["chest"]),
                                StomachHits = Convert.ToInt32(rdr["stomach"]),
                                LeftArmHits = Convert.ToInt32(rdr["left_arm"]),
                                RightArmHits = Convert.ToInt32(rdr["right_arm"]),
                                LeftLegHits = Convert.ToInt32(rdr["left_leg"]),
                                RightLegHits = Convert.ToInt32(rdr["right_leg"]),

                                BombsPlanted = Convert.ToInt32(rdr["c4_planted"]),
                                BombsExploded = Convert.ToInt32(rdr["c4_exploded"]),
                                BombsDefused = Convert.ToInt32(rdr["c4_defused"]),

                                RoundsWonCT = Convert.ToInt32(rdr["ct_win"]),
                                RoundsWonT = Convert.ToInt32(rdr["tr_win"]),

                                HostagesRescued = Convert.ToInt32(rdr["hostages_rescued"]),
                                VIPsKilled = Convert.ToInt32(rdr["vip_killed"]),
                                VIPsEscaped = Convert.ToInt32(rdr["vip_escaped"]),
                                VIPsPlayed = Convert.ToInt32(rdr["vip_played"]),

                                MVP = Convert.ToInt32(rdr["mvp"]),
                                Damage = Convert.ToInt32(rdr["damage"]),

                                MatchesWon = Convert.ToInt32(rdr["match_win"]),
                                MatchesDrawn = Convert.ToInt32(rdr["match_draw"]),
                                MatchesLost = Convert.ToInt32(rdr["match_lose"]),

                                FirstBlood = Convert.ToInt32(rdr["first_blood"]),

                                NoScopes = Convert.ToInt32(rdr["no_scope"]),
                                LongestNoScope = Convert.ToInt32(rdr["no_scope_dis"])
                            });
                        }
                    }
                    con.Close();
                }
            }
        }

        //Courtesy of user Styles on AlliedMods https://forums.alliedmods.net/showpost.php?p=735452&postcount=115
        /// <summary>
        /// Converts a legacy Steam ID to the Steam64 format.
        /// </summary>
        /// <param name="LegacyFormat">The LegacyFormat string should be in the STEAM_X:Y:Z format.</param>
        /// <returns></returns>
        public string ConvertToSteam64(string LegacyFormat)
        {
            string[] split = LegacyFormat.Replace("STEAM_", "").Split(':');

            var test = (76561197960265728 + (Convert.ToInt64(split[2]) * 2) + Convert.ToInt64(split[1]));
            
            return test.ToString();
        }

        
        public async Task GetAvatars()
        {
            List<PlayerSummary> stringList = new List<PlayerSummary>();
            string Key = ConfigurationManager.AppSettings["SteamAPIKey"];

            var webInterfaceFactory = new SteamWebInterfaceFactory(Key);
            var steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());

            foreach (PlayerRow i in MasterList)
                AvatarList.Add(Convert.ToUInt64(i.Steam64));

            var playerSummariesResponse = await steamInterface.GetPlayerSummariesAsync(AvatarList);
            var playerSummariesData = playerSummariesResponse.Data;

            foreach (var i in playerSummariesData)
            {
                foreach (var n in MasterList)
                {
                    if (i.SteamId.ToString() == n.Steam64)
                    {
                        n.AvatarUrl = i.AvatarUrl;
                        n.Name = i.Nickname;
                    }
                }
            }
        }
    }
}
