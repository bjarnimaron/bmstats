using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteamWebAPI2.Models;
using SteamWebAPI2.Interfaces;

namespace bmstats.Models
{
    public class PlayerRow
    {
        public string ID { get; set; }
        public string SteamID { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public int Score { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int Suicides { get; set; }
        public int Teamkills { get; set; }
        public int ShotsFired { get; set; }
        public int ShotsHit { get; set; }
        public Decimal GetAccuracy()
        {
            Decimal result = (((Decimal)ShotsHit / (Decimal)ShotsFired) * 100);
            return System.Math.Ceiling((result * 100) / 100);
        }

        public int HeadShots { get; set; }
        public Decimal GetHeadPercentage()
        {

            Decimal result = (((Decimal)HeadShots / (Decimal)Kills) * 100);
            return System.Math.Ceiling((result * 100) / 100);
        }

        public int PlayTime { get; set; }
        public string GetPlayTime()
        {
            TimeSpan time = TimeSpan.FromSeconds(PlayTime);
            string str = time.ToString(@"hh\:mm\:ss\:fff");
            return str;
        }
        public int RoundsPlayedAsT { get; set; }
        public int RoundsPlayedAsCT { get; set; }

        public double GetADR()
        {
            return (Damage / (RoundsPlayedAsCT + RoundsPlayedAsT));
        }
        public int LastConnected { get; set; }

        public int KnifeKills { get; set; }
        public int GlockKills { get; set; }
        public int P2000Kills { get; set; }
        public int USPKills { get; set; }
        public int P250Kills { get; set; }
        public int DeagleKills { get; set; }
        public int EliteKills { get; set; }
        public int FivesevenKills { get; set; }
        public int Tec9Kills { get; set; }
        public int CZ75Kills { get; set; }
        public int RevolverKills { get; set; }
        public int NovaKills { get; set; }
        public int XM1014Kills { get; set; }
        public int Mag7Kills { get; set; }
        public int SawedoffKills { get; set; }
        public int BizonKills { get; set; }
        public int Mac10Kills { get; set; }
        public int Mp9Kills { get; set; }
        public int Mp7Kills { get; set; }
        public int Ump45Kills { get; set; }
        public int P90Kills { get; set; }
        public int GalilKills { get; set; }
        public int AK47Kills { get; set; }
        public int Scar20Kills { get; set; }
        public int FamasKills { get; set; }
        public int M4A4Kills { get; set; }
        public int M4A1SKills { get; set; }
        public int AugKills { get; set; }
        public int ScoutKills { get; set; }
        public int SG556Kills { get; set; }
        public int AWPKills { get; set; }
        public int G3SG1Kills { get; set; }
        public int M249Kills { get; set; }
        public int NegevKills { get; set; }
        public int GrenadeKills { get; set; }
        public int FlashbangKills { get; set; }
        public int SmokegrenadeKills { get; set; }
        public int MolotovKills { get; set; }
        public int DecoyKills { get; set; }
        public int TaserKills { get; set; }
        public int Mp5Kills { get; set; }
        public int BreachChargeKills { get; set; }

        public int HeadHits { get; set; }
        public int ChestHits { get; set; }
        public int StomachHits { get; set; }
        public int LeftArmHits { get; set; }
        public int RightArmHits { get; set; }
        public int LeftLegHits { get; set; }
        public int RightLegHits { get; set; }

        public int BombsPlanted { get; set; }
        public int BombsExploded { get; set; }
        public int BombsDefused { get; set; }

        public int RoundsWonCT { get; set; }
        public int RoundsWonT { get; set; }

        public int HostagesRescued { get; set; }
        public int VIPsKilled { get; set; }
        public int VIPsEscaped { get; set; }
        public int VIPsPlayed { get; set; }

        public int MVP { get; set; }
        public int Damage { get; set; }

        public int MatchesWon { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesLost { get; set; }

        public int FirstBlood { get; set; }

        public int NoScopes { get; set; }
        public int LongestNoScope { get; set; }

        public SteamId steamid { get; set; }

    }
}

    //`id`,
    //`steam`,
    //`name`,
    //`lastip`,
    //`score`,
    //`kills`,
    //`deaths`,
    //`assists`,
    //`suicides`,
    //`tk`,
    //`shots`,
    //`hits`,
    //`headshots`,
    //`connected`,
    //`rounds_tr`,
    //`rounds_ct`,
    //`lastconnect`,
    //`knife`,
    //`glock`,
    //`hkp2000`,
    //`usp_silencer`,
    //`p250`,
    //`deagle`,
    //`elite`,
    //`fiveseven`,
    //`tec9`,
    //`cz75a`,
    //`revolver`,
    //`nova`,
    //`xm1014`,
    //`mag7`,
    //`sawedoff`,
    //`bizon`,
    //`mac10`,
    //`mp9`,
    //`mp7`,
    //`ump45`,
    //`p90`,
    //`galilar`,
    //`ak47`,
    //`scar20`,
    //`famas`,
    //`m4a1`,
    //`m4a1_silencer`,
    //`aug`,
    //`ssg08`,
    //`sg556`,
    //`awp`,
    //`g3sg1`,
    //`m249`,
    //`negev`,
    //`hegrenade`,
    //`flashbang`,
    //`smokegrenade`,
    //`inferno`,
    //`decoy`,
    //`taser`,
    //`mp5sd`,
    //`breachcharge`,
    //`head`,
    //`chest`,
    //`stomach`,
    //`left_arm`,
    //`right_arm`,
    //`left_leg`,
    //`right_leg`,
    //`c4_planted`,
    //`c4_exploded`,
    //`c4_defused`,
    //`ct_win`,
    //`tr_win`,
    //`hostages_rescued`,
    //`vip_killed`,
    //`vip_escaped`,
    //`vip_played`,
    //`mvp`,
    //`damage`,
    //`match_win`,
    //`match_draw`,
    //`match_lose`,
    //`first_blood`,
    //`no_scope`,
    //`no_scope_dis`